#!/bin/bash
version=$1
echo $version
readarray -d . -t versionNumbers <<< "${version%%-*}"
if [[ ${versionNumbers[1]} -eq "0" && ${versionNumbers[2]} -eq "0" ]]
then
    oldVersion=$(({versionNumbers[0]} - 1))
else
    oldVersion=${versionNumbers[0]}
fi
oldVersion="$oldVersion.0.0"
echo $oldVersion
if [[ "$oldVersion" == "0.0.0" ]]
then
    echo "No previous major version exists yet (this is the first major version) - skipping ApiCompat baseline download."
    exit 0
fi
rm -rf ../LastMajorVersionBinary
curl -f https://globalcdn.nuget.org/packages/mahhalamapper.$oldVersion.nupkg --create-dirs -o ../LastMajorVersionBinary/mahhalamapper.$oldVersion.nupkg
if [[ ! -f ../LastMajorVersionBinary/mahhalamapper.$oldVersion.nupkg ]]
then
    echo "MahhalaMapper $oldVersion has not been published yet - skipping ApiCompat baseline download."
    exit 0
fi
unzip -j ../LastMajorVersionBinary/mahhalamapper.$oldVersion.nupkg lib/netstandard2.1/MahhalaMapper.dll -d ../LastMajorVersionBinary
