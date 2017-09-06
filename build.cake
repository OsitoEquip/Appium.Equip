

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
        //Results = "./Appium.Equip/Appium.Equip.Tests/bin/debug/TestFile.xml",
        StopOnError = false
    });
});

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
});

RunTarget(target);