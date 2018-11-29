function Get-Encrypted {
    [CmdletBinding()]
    param (
        [parameter(Mandatory=$true, ValueFromPipeline=$true)]
        [string] $Value
    )
    process {
		$utilCryptoAsm = Join-Path $PSScriptRoot "..\lib" | Get-ChildItem -Recurse -Filter Utilities.Cryptography.dll | Sort-Object LastWriteTime -Descending | Select-Object -First 1; 
		Add-Type -Path $utilCryptoAsm.FullName;
        $encryptorDecryptor = New-Object Utilities.Cryptography.EncryptorDecryptor;
        Write-Output $encryptorDecryptor.Encrypt($Value);
    }
}