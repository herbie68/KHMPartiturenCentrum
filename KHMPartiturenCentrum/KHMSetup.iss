#define ApplicationName "KHM Partituren Centrum"
#define Manufactured "KHM"
#define Developer "Herbert Nijkamp"
#define Publisher "HN Software Development"
#define CurrentYear GetDateTimeString('yyyy', '', '')
#define DevOpsPath "c:\DevOps\hnsoftwaredevelopment\"
#define SetupIcons "c:\DevOps\hnsoftwaredevelopment\KHMPartiturenCentrum\KHMPartiturenCentrum\Resources\Icons\"
#define SetupImages "c:\DevOps\hnsoftwaredevelopment\KHMPartiturenCentrum\KHMPartiturenCentrum\Resources\Images\"
#define AppConfigPath "c:\DevOps\hnsoftwaredevelopment\KHMPartiturenCentrum\KHMPartiturenCentrum\Resources\Config\"
;#define AppVersion GetVersionNumbersString("c:\Users\hnijk\OneDrive\DevOps\hnsoftwaredevelopment\KHMPartiturenCentrum\KHMPartiturenCentrum\bin\Publish\KHM.exe")
;#define AppVersion GetVersionNumbersString("c:\DevOps\hnsoftwaredevelopment\KHMPartiturenCentrum\KHMPartiturenCentrum\bin\Publish\KHM.exe")
#define AppVersion GetVersionNumbersString("c:\DevOps\hnsoftwaredevelopment\KHMPartiturenCentrum\Builds\x64\Publish\KHM.exe")

; requires netcorecheck.exe and netcorecheck_x64.exe (see CodeDependencies.iss)
#define public Dependency_Path_NetCoreCheck "c:\DevOps\hnsoftwaredevelopment\InnoSetup\dependencies\"

; requires dxwebsetup.exe (see CodeDependencies.iss)
;#define public Dependency_Path_DirectX "dependencies\"

;#include "c:\Program Files (x86)\Inno Setup 6\Examples\CodeDependencies.iss"
#include "c:\DevOps\hnsoftwaredevelopment\InnoSetup\CodeDependencies.iss"

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
OutputDir={#DevOpsPath}KHMPartiturenCentrum\Installer
OutputBaseFilename=KHM_Setup
Compression=lzma2/ultra64
SolidCompression=yes
SetupIconFile={#SetupIcons}appicon.ico
ArchitecturesInstallIn64BitMode=x64
WizardImageFile={#SetupImages}InstallerImageBig.bmp
;WizardSmallImageFile={#SetupImages}InstallerBanner.bmp
WizardSmallImageFile={#SetupImages}InstallerLogo.bmp
LicenseFile={#AppConfigPath}licentieovereenkomst.rtf
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
;Source: "c:\DevOps\hnsoftwaredevelopment\KHMPartiturenCentrum\KHMPartiturenCentrum\bin\Publish\*"; DestDir: "{app}"; Flags: recursesubdirs createallsubdirs; Excludes: "*.pdb"
Source: "c:\DevOps\hnsoftwaredevelopment\KHMPartiturenCentrum\Builds\x64\Publish\*"; DestDir: "{app}"; Flags: recursesubdirs createallsubdirs; Excludes: "*.pdb"


[Icons]
Name: "{group}\{#Manufactured}\{#ApplicationName}"; Filename: "{app}\khm.exe"
Name: "{commondesktop}\{#ApplicationName}"; Filename: "{app}\khm.exe"

[Tasks]
Name: "desktopicon"; Description: "Plaats een icon op het bureaublad";

[Run]
Filename: "{app}\khm.exe"; Description: "Start het KHM Partituren Centrum"; Flags: postinstall nowait skipifsilent
