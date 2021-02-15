using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadVariant : MonoBehaviour
{
    private AssetBundleManifest m_mainifest;
    public bool m_variant = false;

    AssetBundle LoadBundle(string bundleName, bool variant = false)
    {
        AssetBundle ret = null;
        if (null != m_mainifest)
        {
            string[] dependencies = m_mainifest.GetAllDependencies(bundleName);
            foreach (string dependence in dependencies)
            {
                string name = variant ? dependence.Replace(".hd", ".sd"): dependence;
                AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + name);
            }
        }

        string bundle = variant ? bundleName.Replace(".hd", ".sd") : bundleName;
        ret = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + bundle);

        return ret;
    }

    public void InstantiateCube()
    {
        AssetBundle mainifestBundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/StreamingAssets");
        if (mainifestBundle != null)
        {
            m_mainifest = mainifestBundle.LoadAsset<AssetBundleManifest>("assetbundlemanifest");
        }
        AssetBundle ab = LoadBundle("cube", m_variant);
        GameObject cubePrefab = ab.LoadAsset("Cube") as GameObject;
        GameObject cube = GameObject.Instantiate<GameObject>(cubePrefab, Vector3.zero, Quaternion.identity);
    }
}
