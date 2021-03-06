param ([string] $ProjectDir, [string] $ProjectFileName, [string] $SolutionDir);

Set-Variable ComponentId "ProductComponents_NuGet_AutoGenerated" -Option Constant
Set-Variable ComponentGroupId "ProductComponents" -Option Constant
Set-Variable CommentText " This Component section was autogenerated by WiX Setup NuGet collector. " -Option Constant
Set-Variable SupportedFrameworks @("451", "45", "40", "35", "30", "20") -Option Constant

Set-Variable ProjectFilePath (Join-Path $ProjectDir $ProjectFileName) -Option Constant
Set-Variable WixProjectProductFilePath (Join-Path $ProjectDir "Product.wxs") -Option Constant
Set-Variable SolutionPackagesDir (Join-Path $SolutionDir "packages") -Option Constant

function GetProjectNuGetDependencies {
	param([string] $ProjectDir)
	$projectNuGetLibFolders = @();
	$projectPackagesFilePath = Join-Path $ProjectDir "packages.config";
	if (Test-Path $projectPackagesFilePath) {
		[xml] $projectPackages = Get-Content $projectPackagesFilePath;		
		foreach ($package in $projectPackages.packages.package) {            
			$packageTargetFrameworkCleanName = $package.targetFramework.ToLower().Replace("net", [string]::Empty).Replace(".", [string]::Empty);
			$supportedTargetFrameworkIndex = -1;
			$supportedTargetLibFolderIndex = -1;

			$packageLibFolder = Join-Path $SolutionPackagesDir ("{0}.{1}\lib" -f $package.id, $package.version);
			$projectNuGetLibFolders += $packageLibFolder;
			if (!(Test-Path $projectPackagesFilePath)) {
				return $projectNuGetLibFolders;
			}
			$targetedLibFolders = @() + (Get-ChildItem $packageLibFolder -Directory| Select-Object FullName, @{ Name="CleanName"; Expression={ $_.Name.ToLower().Replace("net", [string]::Empty) } });

			$supportedTargetFramework = $SupportedFrameworks | where { $packageTargetFrameworkCleanName.StartsWith($_) } | select -First 1;
			if ($supportedTargetFramework -ne $null) {
				$supportedTargetFrameworkIndex = $SupportedFrameworks.IndexOf($supportedTargetFramework);
			}
			
			for ($index = $supportedTargetFrameworkIndex; $index -lt $SupportedFrameworks.Count -and $supportedTargetLibFolderIndex -eq -1; $index++) {
				$supportedTargetedLibFolder = $targetedLibFolders | where { $_.CleanName.StartsWith($SupportedFrameworks[$index]) } | select -First 1;
				if ($supportedTargetedLibFolder -ne $null) {
					$supportedTargetLibFolderIndex = $targetedLibFolders.IndexOf($supportedTargetedLibFolder);
				}
			}			
			if ($supportedTargetFrameworkIndex -ne -1 -and $supportedTargetLibFolderIndex -ne -1) {
				$projectNuGetLibFolders += $targetedLibFolders[$supportedTargetLibFolderIndex].FullName;				
			}
		}
	}
	return $projectNuGetLibFolders;
}

if ((Test-Path $ProjectFilePath) -and (Test-Path $WixProjectProductFilePath) -and (Test-Path $SolutionPackagesDir)) {
	$nuGetLibFolders = @();
	[xml] $wixProjectXml = Get-Content $ProjectFilePath;
	$wixProjectXml.GetElementsByTagName("ProjectReference") | foreach {
		$refProjectFileUri = New-Object Uri(Join-Path $ProjectDir $_.Include);
		$refProjectDir = [IO.Path]::GetDirectoryName($refProjectFileUri.LocalPath);		
		$nuGetLibFolders += GetProjectNuGetDependencies $refProjectDir;
	};
	$nuGetLibFolders += GetProjectNuGetDependencies $ProjectDir;

	[xml] $wixProductXml =  Get-Content $WixProjectProductFilePath;
	$wixElement = $wixProductXml.DocumentElement;
	$componentGroup = $wixElement.Fragment | where { $_.ComponentGroup -ne $null -and $_.ComponentGroup.Id -eq $ComponentGroupId } | select ComponentGroup;

	$componentSetup = $wixProductXml.CreateElement([string]::Empty, "Component", $wixElement.NamespaceURI);
	$componentSetup.SetAttribute("Guid", [string]::Empty, [Guid]::NewGuid());
	$componentSetup.SetAttribute("Id", [string]::Empty, $ComponentId);

	if (!$componentGroup.ComponentGroup.HasAttribute("Directory")) {
		$componentSetup.SetAttribute("Directory", [string]::Empty, "INSTALLFOLDER");	
	}
	$filesAdded = 0;
	$nuGetLibFolders | Select-Object -Unique | Get-ChildItem -File | where { $_.Extension -in (".dll", ".config") } | foreach {
		$componentSetupFile = $wixProductXml.CreateElement("", "File", $wixElement.NamespaceURI);
		
		$componentSetupFile.SetAttribute("Id", [string]::Empty, "_" + $_.Name.Replace(".", "_"));
		$componentSetupFile.SetAttribute("Name", [string]::Empty, $_.Name);
		
		$uriTarget = New-Object Uri($_.FullName);
		$uriRoot = New-Object Uri($WixProjectProductFilePath);
		$componentSetupFile.SetAttribute("Source", [string]::Empty, $uriRoot.MakeRelative($uriTarget).Replace("/", [IO.Path]::DirectorySeparatorChar));
		
		$componentSetup.AppendChild($componentSetupFile);
		$filesAdded++;
	};
	
	
	
	$modifyWixProductXml = $false;

	$availableComponent = $componentGroup.ComponentGroup.ChildNodes | where { $_.Id -eq $ComponentId };
	if ($availableComponent -eq $null) {
		$modifyWixProductXml = $true;
	} else {
		$availableComponentGuid = $availableComponent.Guid;
		$componentSetupGuid = $componentSetup.Guid;

		$availableComponent.SetAttribute("Guid", [string]::Empty, [Guid]::Empty);
		$componentSetup.SetAttribute("Guid", [string]::Empty, [Guid]::Empty);

		$modifyWixProductXml = $availableComponent.OuterXml.Trim() -ne $componentSetup.OuterXml.Trim();

		$availableComponent.SetAttribute("Guid", [string]::Empty, $availableComponentGuid);
		$componentSetup.SetAttribute("Guid", [string]::Empty, $componentSetupGuid);
	}
	
	if ($modifyWixProductXml) {
		$componentGroup.ComponentGroup.ChildNodes | where { $_.Id -eq $ComponentId } | foreach { $componentGroup.ComponentGroup.RemoveChild($_); };
		$componentGroup.ComponentGroup.ChildNodes | where { $_.Data -eq $CommentText } | foreach { $componentGroup.ComponentGroup.RemoveChild($_); };

		if ($filesAdded -ne 0) {
			$componentGroup.ComponentGroup.AppendChild($wixProductXml.CreateComment($CommentText));
			$componentGroup.ComponentGroup.AppendChild($componentSetup);
		}

		$wixProductXml.Save($WixProjectProductFilePath);
	}
}
