//place this script in the Editor folder within Assets.
using UnityEditor;


//to be used on the command line:
//$ Unity -quit -batchmode -executeMethod WebGLBuilder.build

class WebGLBuilder
{
    static void build()
    {
        string[] scenes = { "Assets/Zastavka.unity", "Assets/Shop.unity", "Assets/Main.unity" };
        BuildPipeline.BuildPlayer(scenes, "D:/devel/WebGL-Dist", BuildTarget.WebGL, BuildOptions.None);
    }
}