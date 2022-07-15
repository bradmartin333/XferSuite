; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "XferSuite"
#define MyAppVersion "4.2"
#define MyAppPublisher "bradmartin333"
#define MyAppURL "https://github.com/bradmartin333/XferSuite"
#define MyAppExeName "XferSuite.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{F947F4EA-153E-41C6-8AF5-070BD2071D06}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
; Remove the following line to run in administrative install mode (install for all users.)
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
OutputDir=S:\XferSuite\Setup
OutputBaseFilename=XferSuiteSetup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "S:\XferSuite\XferSuite\bin\x64\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\Accord.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\Accord.Math.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\Accord.Math.Core.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\Accord.Math.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\Accord.Math.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\Accord.Statistics.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\Accord.Statistics.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\Accord.Video.DirectShow.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\Accord.Video.DirectShow.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\Accord.Video.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\Accord.Video.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\Accord.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\FSharp.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\FSharp.Core.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\MathNet.Numerics.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\ObjectListView.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\ObjectListView.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\OxyPlot.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\OxyPlot.WindowsForms.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\OxyPlot.WindowsForms.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\OxyPlot.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\ScottPlot.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\ScottPlot.WinForms.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\ScottPlot.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\System.Drawing.Common.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\System.Numerics.Vectors.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\System.Numerics.Vectors.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\System.ValueTuple.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\System.ValueTuple.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\XferHelper.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\XferHelper.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\XferHelper.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\XferSuite.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "S:\XferSuite\XferSuite\bin\x64\Release\XferSuite.pdb"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

