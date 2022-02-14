// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

using NFive.SDK.Server;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

[assembly: Guid("c0f1d0f0-079b-42b0-b85f-611f0c95f395")]

[assembly: ServerPlugin(SDK.Version)]
