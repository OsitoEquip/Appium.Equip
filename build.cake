

var target        = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var buildNumber   = Argument("buildnumber", "0");
var buildDir      = Directory("./artifacts");
var solution      = "./<YourSolutionFile>.sln";


Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
});

Task("Default")
    .IsDependentOn("Clean");

RunTarget(target);