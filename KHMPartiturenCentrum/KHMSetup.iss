#define ApplicationName "KHM Partituren Centrum"
#define Manufactured "KHM"
#define Developer "Herbert Nijkamp"
#define Publisher "HN Software Development"
#define CurrentYear GetDateTimeString('yyyy', '', '')
#define AppVersion GetVersionNumbersString("c:\Users\hnijk\OneDrive\DevOps\hnsoftwaredevelopment\KHMPartiturenCentrum\KHMPartiturenCentrum\bin\Publish\KHM.exe")

; requires netcorecheck.exe and netcorecheck_x64.exe (see CodeDependencies.iss)
;#define public Dependency_Path_NetCoreCheck "c:\Program Files (x86)\Inno Setup 6\dependencies\"

; requires dxwebsetup.exe (see CodeDependencies.iss)
;#define public Dependency_Path_DirectX "dependencies\"

;#include "c:\Program Files (x86)\Inno Setup 6\Examples\CodeDependencies.iss"

[Setup]
AppName={#ApplicationName}
AppVersion={#AppVersion}
AppContact={#Developer}
AppPublisher={#Publisher}
AppCopyright=Copyright © {#CurrentYear} - {#Publisher}
AllowRootDirectory=yes
CloseApplications=yes
DefaultDirName={commonpf}\{#Manufactured}\{#ApplicationName}
DefaultGroupName={#Manufactured}\{#ApplicationName}
DisableReadyPage=True
DisableStartupPrompt=yes
UninstallDisplayIcon={uninstallexe}
OutputDir=c:\Users\hnijk\OneDrive\DevOps\hnsoftwaredevelopment\KHMPartiturenCentrum\Installer
OutputBaseFilename=KHM_Setup
Compression=lzma2/ultra64
SolidCompression=yes
SetupIconFile=c:\Users\hnijk\OneDrive\DevOps\hnsoftwaredevelopment\KHMPartiturenCentrum\KHMPartiturenCentrum\Resources\Icons\applogo.ico
ArchitecturesInstallIn64BitMode=x64
WizardImageFile=c:\Users\hnijk\OneDrive\DevOps\hnsoftwaredevelopment\KHMPartiturenCentrum\KHMPartiturenCentrum\Resources\Images\InstallerImageBig.bmp
WizardSmallImageFile=c:\Users\hnijk\OneDrive\DevOps\hnsoftwaredevelopment\KHMPartiturenCentrum\KHMPartiturenCentrum\Resources\Images\InstallerLogo.bmp
LicenseFile=c:\Users\hnijk\OneDrive\DevOps\hnsoftwaredevelopment\KHMPartiturenCentrum\KHMPartiturenCentrum\Resources\Config\licentieovereenkomst.rtf
WizardStyle=modern
ShowLanguageDialog=no
UninstallDisplayName=KHM Partituren Centrum
VersionInfoCompany={#Developer}
VersionInfoCopyright=Copyright © {#CurrentYear} - {#Publisher}
VersionInfoProductName={#ApplicationName}
VersionInfoVersion={#AppVersion}
VersionInfoProductVersion={#AppVersion}

[Languages]
Name: "dutch"; MessagesFile: "compiler:Languages\Dutch.isl"

[Files]
Source: "c:\Users\hnijk\OneDrive\DevOps\hnsoftwaredevelopment\KHMPartiturenCentrum\KHMPartiturenCentrum\bin\Publish\*"; DestDir: "{app}"; Flags: recursesubdirs createallsubdirs; Excludes: "*.pdb"

[Icons]
Name: "{group}\{#Manufactured}\{#ApplicationName}"; Filename: "{app}\khm.exe"
Name: "{commondesktop}\{#ApplicationName}"; Filename: "{app}\khm.exe"

[Tasks]
Name: "desktopicon"; Description: "Plaats een icon op het bureaublad";

[Run]
Filename: "{app}\khm.exe"; Description: "Start het KHM Partituren Centrum"; Flags: postinstall nowait skipifsilent
