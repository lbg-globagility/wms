$server = Read-Host 'server';
$database = Read-Host 'database';
$port = Read-Host 'port';
$pwd = Read-Host 'password' -AsSecureString;

$pwd = [Runtime.InteropServices.Marshal]::PtrToStringAuto([Runtime.InteropServices.Marshal]::SecureStringToBSTR($pwd));

Get-ChildItem -Recurse ./DatabaseObjects |
Where-Object {(!$_.PsIsContainer)} |
Foreach-Object {
    $filename = $_.FullName;

    If (!$server) {
        Get-Content $filename |
            mysql --user=root --password=$pwd --database=$database --port=$port --comments;
    }
    Else {
        Get-Content $filename |
            mysql --user=root --host=$server --password=$pwd --database=$database --port=$port --comments;
    }

    Write-Output $filename;
}
