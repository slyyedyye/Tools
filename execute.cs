using System.Configuration.Install;
using System.Runtime.InteropServices;
using System.Management.Automation.Runspaces;
public class Program
 {
 public static void Main()
 {
 }
 }
 [System.ComponentModel.RunInstaller(true)]
 public class Sample : System.Configuration.Install.Installer
 {
 public override void Uninstall(System.Collections.IDictionary savedState)
 {
 Mycode.Exec();
 }
 }
 public class Mycode
 {
 public static void Exec()
 {
 string command = System.IO.File.ReadAllText(@"C:\Users\bob\Downloads\commands.ps1");
 RunspaceConfiguration rspacecfg = RunspaceConfiguration.Create();
 Runspace rspace = RunspaceFactory.CreateRunspace(rspacecfg);
 rspace.Open();
 Pipeline pipeline = rspace.CreatePipeline();
 pipeline.Commands.AddScript(command);
 pipeline.Invoke();
 }
 }

