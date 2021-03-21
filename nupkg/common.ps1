# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName  # path of nupkg folder
$rootFolder = Join-Path $packFolder "../" # path of root folder
$distFolder = Join-Path $rootFolder "dist" # path of dist folder

# List of solutions
$solutions = (
  ""  
)

# List of projects
$projects = (
    "src/Lantern",
    "src/Lantern.Utils",
    "src/Lantern.Windows",
    "src/Lantern.WinForm"
)