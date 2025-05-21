using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public static class BuildScript
{
    public static void BuildAPK()
    {
        string buildPath = "Builds/Android";
        string apkName = "MyGame.apk";
        string fullPath = $"{buildPath}/{apkName}";

        Debug.Log("PROGRESS: Starting APK build process...");

        // Step 1: Clean up previous builds (optional)
        Debug.Log("PROGRESS: Cleaning up previous APK...");
        if (System.IO.File.Exists(fullPath))
        {
            System.IO.File.Delete(fullPath);
            Debug.Log("PROGRESS: Previous APK deleted.");
        }

        // Step 2: Gather scenes
        Debug.Log("PROGRESS: Gathering scenes...");
        BuildPlayerOptions buildOptions = new BuildPlayerOptions
        {
            scenes = new[] { "Assets/Scenes/SampleScene.unity" },
            locationPathName = fullPath,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };

        // Step 3: Start build
        Debug.Log("PROGRESS: Starting Unity BuildPipeline.BuildPlayer...");
        BuildReport report = BuildPipeline.BuildPlayer(buildOptions);

        // Step 4: Build completed
        if (report.summary.result == BuildResult.Succeeded)
        {
            Debug.Log("PROGRESS: Build succeeded.");
            Debug.Log("✅ APK build completed successfully.");
        }
        else
        {
            Debug.LogError("❌ APK build failed.");
            Debug.Log("PROGRESS: Build failed.");
        }
    }
} 


