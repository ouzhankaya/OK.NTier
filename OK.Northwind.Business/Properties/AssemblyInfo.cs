using System.Data.Entity;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OK.Core.Aspects.Postsharp.ExceptionAspects;
using OK.Core.Aspects.Postsharp.LogAspects;
using OK.Core.Aspects.PostSharp.PerformanceAspect;
using OK.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("OK.Northwind.Business")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("OK.Northwind.Business")]
[assembly: AssemblyCopyright("Copyright ©  2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: PerformanceCounterAspect(AttributeTargetTypes = "OK.Northwind.Business.Concrete.Managers.*")]
//[assembly: LogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "OK.Northwind.Business.Concrete.Managers.*")]
//[assembly: ExceptionLogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "OK.Northwind.Business.Concrete.Managers.*")]


// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("680bb704-8ff7-42aa-b218-cf31e1d02240")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
