using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class BuildScript
{
    public static void BuildProject()
    {
        string[] scenes = { "Assets/Scenes/MainScene.unity" };
        string pathToBuild = "D:/ProjectBuilds/EnterTheDungeons/UnityBuild.exe";

        BuildPipeline.BuildPlayer(scenes, pathToBuild, BuildTarget.StandaloneWindows64, BuildOptions.None);
    }
}
