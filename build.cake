

var target        = Argument("target", "Default");

//#tool "nuget:?package=NUnit.Console"
//Version 3.7.0
#tool "nuget:?package=NUnit.ConsoleRunner&version=3.6.0"
//#tool "nuget:?package=NUnit.ConsoleRunner"
//#tool "nuget:?package=NUnit.Runners&version=2.6.4"
var configuration = Argument("configuration", "Debug");
var buildNumber   = Argument("buildnumber", "0");
var buildDir      = Directory("./artifacts");
var solution      = "./Appium.Equip.sln";
var TestFile    = "Appium.Equip.Tests.dll";
var TestDirectory ="./Appium.Equip/Appium.Equip.Tests/bin/debug";
var TestDll      = TestDirectory + "/" + TestFile;
var dirTestResults = "./TestResults";
var dirNugetPackage ="./nuget";


Task("Default")
    .IsDependentOn("Build");

Task("Build")
  .Does(() =>
{
  NuGetRestore(solution);
  MSBuild(solution , new MSBuildSettings {
    Verbosity = Verbosity.Minimal,
    ToolVersion = MSBuildToolVersion.VS2017,
    Configuration = configuration,
    PlatformTarget = PlatformTarget.MSIL
    });
});

Task("Test")
    .Does(() =>
{
    if (!DirectoryExists(dirTestResults))
    {
        CreateDirectory(dirTestResults);
    }
    Debug(TestDll);
    var file ="C:/Users/Rick/Documents/GitHub/Appium.Equip/Appium.Equip.Tests/bin/Debug/Appium.Equip.Tests.dll";
    var testAssemblies = GetFiles(file);
    NUnit3(testAssemblies, new NUnit3Settings {
        //WorkingDirectory = "./Appium.Equip/Appium.Equip.Tests/bin/debug",
        StopOnError = false
    });
});

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
});

Task("Package")
  .Does(()=>{
    if (!DirectoryExists(dirNugetPackage))
    {
        CreateDirectory(dirNugetPackage);
    }
    var assemblyInfo = ParseAssemblyInfo("./Appium.Equip/Properties/AssemblyInfo.cs");
    var nuGetPackSettings   = new NuGetPackSettings {                              
                                Version                 = assemblyInfo.AssemblyFileVersion,
                                Copyright               = "EQUIP 2016",
                                // ReleaseNotes            = new [] {"Bug fixes", "Issue fixes", "Typos"},
                                OutputDirectory         = "./nuget"
                            };     
    NuGetPack("./Appium.Equip/Appium.Equip.nuspec", nuGetPackSettings);
});

RunTarget(target);