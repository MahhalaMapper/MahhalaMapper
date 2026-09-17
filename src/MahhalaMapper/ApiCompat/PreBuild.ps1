param([string]$version)
echo $version
$versionNumbers = $version.Split("-")[0].Split(".")
if($versionNumbers[1] -eq "0" -AND $versionNumbers[2] -eq "0")
{
    $oldVersion = $versionNumbers[0] - 1
}else{
    $oldVersion = $versionNumbers[0]
}
$oldVersion = $oldVersion.ToString() +".0.0"
echo $oldVersion
if($oldVersion -eq "0.0.0")
{
    echo "No previous major version exists yet (this is the first major version) - skipping ApiCompat baseline download."
    exit 0
}
& ..\..\nuget install MahhalaMapper -Version $oldVersion -OutputDirectory ..\LastMajorVersionBinary 2>$null
if(-not (Test-Path "..\LastMajorVersionBinary\MahhalaMapper.$oldVersion\lib"))
{
    echo "MahhalaMapper $oldVersion has not been published yet - skipping ApiCompat baseline download."
    exit 0
}
& copy ..\LastMajorVersionBinary\MahhalaMapper.$oldVersion\lib\net*.0\MahhalaMapper.dll ..\LastMajorVersionBinary
