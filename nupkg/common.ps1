# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
$rootFolder = Join-Path $packFolder "../"
$nupkgsFolder = Join-Path $packFolder "/nupkgs"

# List of solutions
$solutions = (
    #"DangKe.Archive.Shared"
    #"DangKe.Archive.Identity"
    #"DangKe.Archive.SettingManagement",
    "DangKe.Archive.PhysicalManagement"
    #"DangKe.Archive.TaskManagement"
)

# List of projects
$projects = (
    # Shared
    "DangKe.Archive.Shared/src/DangKe.Archive.Application.Shared",
    "DangKe.Archive.Shared/src/DangKe.Archive.Domain.Shared",
    "DangKe.Archive.Shared/src/DangKe.Archive.EntityFrameworkCore.Shared",
    "DangKe.Archive.Shared/src/DangKe.Archive.Host.Shared",
    "DangKe.Archive.Shared/src/DangKe.Archive.HttpApi.Shared",
    "DangKe.Archive.Shared/src/DangKe.Archive.Shared",
    # Identity
    "DangKe.Archive.Identity/src/DangKe.Archive.Identity.Application",
    "DangKe.Archive.Identity/src/DangKe.Archive.Identity.Application.Contracts",
    "DangKe.Archive.Identity/src/DangKe.Archive.Identity.Domain",
    "DangKe.Archive.Identity/src/DangKe.Archive.Identity.Domain.Shared",
    "DangKe.Archive.Identity/src/DangKe.Archive.Identity.EntityFrameworkCore",
    "DangKe.Archive.Identity/src/DangKe.Archive.Identity.HttpApi",
    # SettingManagement
    "DangKe.Archive.SettingManagement/src/DangKe.Archive.SettingManagement.Application",
    "DangKe.Archive.SettingManagement/src/DangKe.Archive.SettingManagement.Application.Contracts",
    "DangKe.Archive.SettingManagement/src/DangKe.Archive.SettingManagement.Domain",
    "DangKe.Archive.SettingManagement/src/DangKe.Archive.SettingManagement.Domain.Shared",
    "DangKe.Archive.SettingManagement/src/DangKe.Archive.SettingManagement.EntityFrameworkCore",
    "DangKe.Archive.SettingManagement/src/DangKe.Archive.SettingManagement.HttpApi",
     # PhysicalManagement
    "DangKe.Archive.PhysicalManagement/src/DangKe.Archive.PhysicalManagement.Application",
    "DangKe.Archive.PhysicalManagement/src/DangKe.Archive.PhysicalManagement.Application.Contracts",
    "DangKe.Archive.PhysicalManagement/src/DangKe.Archive.PhysicalManagement.Domain",
    "DangKe.Archive.PhysicalManagement/src/DangKe.Archive.PhysicalManagement.Domain.Shared",
    "DangKe.Archive.PhysicalManagement/src/DangKe.Archive.PhysicalManagement.EntityFrameworkCore",
    "DangKe.Archive.PhysicalManagement/src/DangKe.Archive.PhysicalManagement.HttpApi",
     # TaskManagement
    "DangKe.Archive.TaskManagement/src/DangKe.Archive.TaskManagement.Application",
    "DangKe.Archive.TaskManagement/src/DangKe.Archive.TaskManagement.Application.Contracts",
    "DangKe.Archive.TaskManagement/src/DangKe.Archive.TaskManagement.Domain",
    "DangKe.Archive.TaskManagement/src/DangKe.Archive.TaskManagement.Domain.Shared",
    "DangKe.Archive.TaskManagement/src/DangKe.Archive.TaskManagement.EntityFrameworkCore",
    "DangKe.Archive.TaskManagement/src/DangKe.Archive.TaskManagement.HttpApi"
)