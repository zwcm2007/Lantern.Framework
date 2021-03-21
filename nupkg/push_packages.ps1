. ".\common.ps1"

$apiKey = $args[0]

# Get the version
[xml]$commonPropsXml = Get-Content (Join-Path $rootFolder "common.props")
$version = $commonPropsXml.Project.PropertyGroup.Version

# Go to the dist folder
Set-Location $distFolder

# Publish all packages
foreach($project in $projects) {
    # Get the projectName
    $projectName = $project.Substring($project.LastIndexOf("/") + 1)  
    & dotnet nuget push ($projectName + "." + $version + ".nupkg") -s http://localhost:9000/v3/index.json --api-key "$apiKey"   
}

# Go back to the pack folder
Set-Location $packFolder
