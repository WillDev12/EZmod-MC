; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "EZmod"
#define MyAppVersion "1.5.0"
#define MyAppPublisher "WillDevv12"
#define MyAppURL "https://sites.google.com/view/ezmod-mc/home"
#define MyAppExeName "EZmod MC v1.5.0.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{4ECAA9A8-2FB7-48D4-950A-50F6D61F7D7C}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={%USERPROFILE}\{#MyAppName}
DisableDirPage=yes
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=C:\Users\kevin\Desktop
OutputBaseFilename=EZmod
SetupIconFile=C:\Users\kevin\Desktop\Projects\EZmod MC v1.5.0\src\Dakirby309-Simply-Styled-Minecraft-Folder.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[DIRS]
Name: {%USERPROFILE}\EZmod
Name: {%USERPROFILE}\EZmod\.Core
Name: {%USERPROFILE}\EZmod\Backup
Name: {%USERPROFILE}\EZmod\Backup\Bedrock
Name: {%USERPROFILE}\EZmod\Backup\resource
Name: {%USERPROFILE}\EZmod\Backup\Shaders
Name: {%USERPROFILE}\EZmod\Settings
Name: {%USERPROFILE}\EZmod\Versions

[Files]
Source: "C:\Users\kevin\EZmod\.Core\{#MyAppExeName}"; DestDir: "{%USERPROFILE}\EZmod\.Core"; Flags: ignoreversion
Source: "C:\Users\kevin\EZmod\.Core\EZmod MC v1.5.0.exe"; DestDir: "{%USERPROFILE}\EZmod\.Core"; Flags: ignoreversion
Source: "C:\Users\kevin\EZmod\.Core\EZmod MC v1.5.0.exe.config"; DestDir: "{%USERPROFILE}\EZmod\.Core"; Flags: ignoreversion
Source: "C:\Users\kevin\EZmod\.Core\EZmod MC v1.5.0.pdb"; DestDir: "{%USERPROFILE}\EZmod\.Core"; Flags: ignoreversion
Source: "C:\Users\kevin\EZmod\.Core\EZmod MC v1.5.0.xml"; DestDir: "{%USERPROFILE}\EZmod\.Core"; Flags: ignoreversion
Source: "C:\Users\kevin\EZmod\.Core\Guna.UI2.dll"; DestDir: "{%USERPROFILE}\EZmod\.Core"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\.Core\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
