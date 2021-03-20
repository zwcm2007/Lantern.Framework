. ".\common.ps1"

# Publish all packages
foreach($solution in $solutions){

    foreach($project in $projects) {

       if($project.Contains($solution)){
              
            Set-Location $rootFolder
            # Get the version
            [xml]$commonPropsXml = Get-Content (Join-Path $project.Substring(0, $project.IndexOf("/")) "common.props")
            $version = $commonPropsXml.Project.PropertyGroup.Version
            # Get the projectName
            $projectName = $project.Substring($project.LastIndexOf("/") + 1)
    
            Set-Location $nupkgsFolder
            # Push
            & dotnet nuget push ($projectName + "." + $version + ".nupkg") -s http://32v2537v11.zicp.vip:24388/nuget --api-key "dangke123" 
            #& dotnet nuget push ($projectName + "." + $version + ".nupkg") -s http://192.168.0.5:9000/nuget --api-key "dangke123" 
       }
    }
}

# Go back to the pack folder
Set-Location $packFolder
