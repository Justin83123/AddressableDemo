using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class MyBundle :Editor
{
    [MenuItem("CustomTools/Bundle")]
    public static void DoBundle()
    {
        string outpath = Application.streamingAssetsPath;
        if (!Directory.Exists(outpath))
        {
            Directory.CreateDirectory(outpath);
        }
        BuildAssetBundleOptions options = BuildAssetBundleOptions.ChunkBasedCompression | BuildAssetBundleOptions.ForceRebuildAssetBundle| BuildAssetBundleOptions.DeterministicAssetBundle;
        BuildPipeline.BuildAssetBundles(outpath, options, BuildTarget.StandaloneOSX);
    }

    [MenuItem ("CustomTools/ClearBundleNames")]
    public static void ClearBundleNames()
    {
        var bundleNames = AssetDatabase.GetAllAssetBundleNames();
        for (int i = 0; i < bundleNames.Length; i++)
        {
            AssetDatabase.RemoveAssetBundleName(bundleNames[i], true);
        }
        AssetDatabase.RemoveUnusedAssetBundleNames();
    }
}
