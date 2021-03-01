; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "XferSuite"
<<<<<<< HEAD
#define MyAppVersion "1.0"
=======
#define MyAppVersion "1.1"
>>>>>>> develop
#define MyAppPublisher "bradmartin333"
#define MyAppURL "https://github.com/bradmartin333"
#define MyAppExeName "XferSuite.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{764430A0-660F-4D3F-925B-838D1FD8B2B5}
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
OutputDir=C:\Repos\XferSuite\Setup
OutputBaseFilename=XferSuiteSetup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\DataFileTree.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\DataFileTree.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\DataFileTree.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\DataFileTree.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\FSharp.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\MapFlip.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\MapFlip.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\MapFlip.pdb"; DestDir: "{app}"; Flags: ignoreversion
<<<<<<< HEAD
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\netstandard.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Runtime.Numerics.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.ValueTuple.dll"; DestDir: "{app}"; Flags: ignoreversion
=======
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\MathNet.Numerics.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\Microsoft.Win32.Primitives.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\netstandard.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\OxyPlot.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\OxyPlot.WindowsForms.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\OxyPlot.WindowsForms.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\OxyPlot.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.AppContext.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Collections.Concurrent.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Collections.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Collections.NonGeneric.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Collections.Specialized.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.ComponentModel.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.ComponentModel.EventBasedAsync.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.ComponentModel.Primitives.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.ComponentModel.TypeConverter.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Console.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Data.Common.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Diagnostics.Contracts.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Diagnostics.Debug.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Diagnostics.FileVersionInfo.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Diagnostics.Process.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Diagnostics.StackTrace.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Diagnostics.TextWriterTraceListener.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Diagnostics.Tools.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Diagnostics.TraceSource.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Diagnostics.Tracing.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Drawing.Primitives.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Dynamic.Runtime.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Globalization.Calendars.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Globalization.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Globalization.Extensions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.IO.Compression.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.IO.Compression.ZipFile.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.IO.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.IO.FileSystem.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.IO.FileSystem.DriveInfo.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.IO.FileSystem.Primitives.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.IO.FileSystem.Watcher.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.IO.IsolatedStorage.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.IO.MemoryMappedFiles.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.IO.Pipes.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.IO.UnmanagedMemoryStream.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Linq.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Linq.Expressions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Linq.Parallel.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Linq.Queryable.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Net.Http.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Net.NameResolution.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Net.NetworkInformation.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Net.Ping.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Net.Primitives.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Net.Requests.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Net.Security.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Net.Sockets.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Net.WebHeaderCollection.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Net.WebSockets.Client.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Net.WebSockets.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.ObjectModel.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Reflection.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Reflection.Extensions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Reflection.Primitives.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Resources.Reader.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Resources.ResourceManager.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Resources.Writer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Runtime.CompilerServices.VisualC.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Runtime.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Runtime.Extensions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Runtime.Handles.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Runtime.InteropServices.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Runtime.InteropServices.RuntimeInformation.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Runtime.Numerics.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Runtime.Serialization.Formatters.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Runtime.Serialization.Json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Runtime.Serialization.Primitives.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Runtime.Serialization.Xml.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Security.Claims.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Security.Cryptography.Algorithms.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Security.Cryptography.Csp.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Security.Cryptography.Encoding.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Security.Cryptography.Primitives.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Security.Cryptography.X509Certificates.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Security.Principal.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Security.SecureString.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Text.Encoding.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Text.Encoding.Extensions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Text.RegularExpressions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Threading.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Threading.Overlapped.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Threading.Tasks.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Threading.Tasks.Parallel.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Threading.Thread.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Threading.ThreadPool.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Threading.Timer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.ValueTuple.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Xml.ReaderWriter.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Xml.XDocument.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Xml.XmlDocument.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Xml.XmlSerializer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Xml.XPath.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\System.Xml.XPath.XDocument.dll"; DestDir: "{app}"; Flags: ignoreversion
>>>>>>> develop
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\XferHelper.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\XferHelper.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\XferHelper.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\XferSuite.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\XferSuite.pdb"; DestDir: "{app}"; Flags: ignoreversion
<<<<<<< HEAD
=======
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\ZRegistration.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\ZRegistration.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\ZRegistration.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Repos\XferSuite\XferSuite\bin\Release\ZRegistration.xml"; DestDir: "{app}"; Flags: ignoreversion
>>>>>>> develop
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

