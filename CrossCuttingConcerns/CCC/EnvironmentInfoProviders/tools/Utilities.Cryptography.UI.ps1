if ($PSScriptRoot -eq $null) {
	$PSScriptRoot = Split-Path -Parent $MyInvocation.MyCommand.Definition;
}
Import-Module (Join-Path $PSScriptRoot Utilities.Cryptography.psm1);

Add-Type -AssemblyName System.Windows.Forms;
Add-Type -AssemblyName System.Drawing;

$largeFont = New-Object Drawing.Font("Microsoft Sans Serif", 9.75, [Drawing.FontStyle]::Bold, [Drawing.GraphicsUnit]::Point, 204);

$inputlabel = New-Object Windows.Forms.Label;
$inputlabel.Font = $largeFont;
$inputlabel.Text = "Input text:";
$inputlabel.Location = New-Object Drawing.Point(12, 9);
$inputlabel.Size = New-Object Drawing.Size(73, 16);

$encryptedlabel = New-Object Windows.Forms.Label;
$encryptedlabel.Font = $largeFont;
$encryptedlabel.Text = "Encrypted text:";
$encryptedlabel.Location = New-Object Drawing.Point(397, 9);
$encryptedlabel.Size = New-Object Drawing.Size(73, 16);

$inputTextBox = New-Object Windows.Forms.TextBox;
$inputTextBox.Multiline = $true;
$inputTextBox.AcceptsReturn = $true;
$inputTextBox.Dock = [Windows.Forms.DockStyle]::Left;
$inputTextBox.Location = New-Object Drawing.Point(0, 0);
$inputTextBox.ScrollBars = [Windows.Forms.ScrollBars]::Vertical;
$inputTextBox.Size = New-Object Drawing.Size(375, 540);
$inputTextBox.TabIndex = 0;

$encryptedTextBox = New-Object Windows.Forms.TextBox;
$encryptedTextBox.Multiline = $true;
$encryptedTextBox.ReadOnly = $true;
$encryptedTextBox.Dock = [Windows.Forms.DockStyle]::Right;
$encryptedTextBox.Location = New-Object Drawing.Point(385, 0);

$encryptedTextBox.Name = "encryptedTextBox";

$encryptedTextBox.ScrollBars = [Windows.Forms.ScrollBars]::Vertical;
$encryptedTextBox.Size = New-Object Drawing.Point(375, 540);
$encryptedTextBox.TabIndex = 1;

$textBoxPanel = New-Object Windows.Forms.Panel;
$textBoxPanel.AutoScroll = $true;
$textBoxPanel.Location = New-Object Drawing.Point(12, 28);
$textBoxPanel.Size = New-Object Drawing.Size(760, 540);
$textBoxPanel.Controls.Add($inputTextBox);
$textBoxPanel.Controls.Add($encryptedTextBox);

$encryptButton = New-Object Windows.Forms.Button;
$encryptButton.Font = $largeFont;
$encryptButton.Location = New-Object Drawing.Point(301, 575);
$encryptButton.Size = New-Object Drawing.Size(182, 40);
$encryptButton.TabIndex = 2;
$encryptButton.Text = "Encrypt";

$mainForm = New-Object Windows.Forms.Form;
$mainForm.Text = "Text Encryptor";
$mainForm.Size = New-Object Drawing.Size(800, 660);
$mainForm.FormBorderStyle = [Windows.Forms.FormBorderStyle]::FixedToolWindow;
$mainForm.StartPosition = [Windows.Forms.FormStartPosition]::CenterScreen;

$mainForm.Controls.Add($inputlabel);
$mainForm.Controls.Add($encryptedlabel);
$mainForm.Controls.Add($textBoxPanel);
$mainForm.Controls.Add($encryptButton);

$inputTextBox.Add_TextChanged({ $encryptedTextBox.Text = $inputTextBox.Text; });

$encryptButton.Add_Click({
    $encryptedLines = @();
    foreach ($line in $inputTextBox.Lines) {
        $encryptedLines += $line | Get-Encrypted;
    }
    $encryptedTextBox.Lines = $encryptedLines;
});

[Windows.Forms.Application]::EnableVisualStyles();
$mainForm.ShowDialog();