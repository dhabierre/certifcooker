// Required InnoSetup - http://www.jrsoftware.org/isinfo.php
// (with the Inno Setup Preprocessor installed)

#define AppName       "Certif'Cooker"
#define AppVersion    "1.0.0"        
#define AppExeName    "CertifCooker.exe"
#define Publisher     "Delphin Habierre"
#define WebSiteURL    "https://github.com/dhabierre/certifcooker"
#define ProjectPath   "F:\Dev\GITHUB\certifcooker\"
#define CurrentYear   "2018";

[Setup]                 
AppId={{180608D2-6456-4088-A49A-E400A345DCB3}}  
AppName={#AppName}
AppVersion={#AppVersion}
AppCopyright=Copyright (c) {#CurrentYear} {#Publisher}
VersionInfoVersion={#AppVersion}
AppPublisher={#Publisher}
AppPublisherURL={#WebSiteURL}
AppSupportURL={#WebSiteURL}
AppUpdatesURL={#WebSiteURL}
DefaultDirName={pf}\{#AppName}
DefaultGroupName={#AppName}
OutputBaseFilename={#AppName}-{#AppVersion}
UninstallDisplayName={#AppName}
SetupIconFile={#ProjectPath}\setup\App.ico
UninstallDisplayIcon={#ProjectPath}\setup\App.ico
AllowNoIcons=yes
LicenseFile={#ProjectPath}\setup\License.txt
OutputDir={#ProjectPath}\setup
Compression=lzma
SolidCompression=yes
WizardSmallImageFile={#ProjectPath}\setup\App.bmp

[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\{#AppExeName}"
Name: "{group}\{cm:UninstallProgram,{#AppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#AppName}"; Filename: "{app}\{#AppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#AppName}"; Filename: "{app}\{#AppExeName}"; Tasks: quicklaunchicon

[Files]
Source: "{#ProjectPath}\src\CertifCooker\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Code]
function IsDotNetDetected(version: string; service: cardinal): boolean;
// Indicates whether the specified version and service pack of the .NET Framework is installed.
//
// version -- Specify one of these strings for the required .NET Framework version:
//    'v1.1.4322'     .NET Framework 1.1
//    'v2.0.50727'    .NET Framework 2.0
//    'v3.0'          .NET Framework 3.0
//    'v3.5'          .NET Framework 3.5
//    'v4\Client'     .NET Framework 4.0 Client Profile
//    'v4\Full'       .NET Framework 4.0 Full Installation
//    'v4.5'          .NET Framework 4.5
//    'v4.5.1'        .NET Framework 4.5.1
//
// service -- Specify any non-negative integer for the required service pack level:
//    0               No service packs required
//    1, 2, etc.      Service pack 1, 2, etc. required
var
    key: string;
    install, release, serviceCount: cardinal;
    check45, success: boolean;
begin
    // .NET 4.5 installs as update to .NET 4.0 Full
    if version = 'v4.5' then begin
        version := 'v4\Full';
        check45 := true;
    end else
        check45 := false;

    // installation key group for all .NET versions
    key := 'SOFTWARE\Microsoft\NET Framework Setup\NDP\' + version;

    // .NET 3.0 uses value InstallSuccess in subkey Setup
    if Pos('v3.0', version) = 1 then begin
        success := RegQueryDWordValue(HKLM, key + '\Setup', 'InstallSuccess', install);
    end else begin
        success := RegQueryDWordValue(HKLM, key, 'Install', install);
    end;

    // .NET 4.0/4.5 uses value Servicing instead of SP
    if Pos('v4', version) = 1 then begin
        success := success and RegQueryDWordValue(HKLM, key, 'Servicing', serviceCount);
    end else begin
        success := success and RegQueryDWordValue(HKLM, key, 'SP', serviceCount);
    end;

    // .NET 4.5 uses additional value Release
    if check45 then begin
        success := success and RegQueryDWordValue(HKLM, key, 'Release', release);
        success := success and (release >= 378389);
    end;

    // .NET 4.5.1
    // HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\
    // version = (Win 7 is 4.5.50938 and the version for Win 8.1 is 4.5.51641) => 4.5.5

    result := success and (install = 1) and (serviceCount >= service);
end;


function InitializeSetup(): Boolean;
var
  ErrorCode: integer;
begin
    if not IsDotNetDetected('v4.5', 0) then begin
        if MsgBox('This product requires Microsoft .NET Framework 4.5.'#13
            'Would you like to visit the download page now?', mbError, MB_YESNO) = IDYES
        then begin
          ShellExec('OPEN', 'http://www.microsoft.com/en-us/download/details.aspx?id=30653', '', '', SW_SHOW, ewNoWait, ErrorCode);
        end;
        result := false;
    end else
        result := true;
end;
