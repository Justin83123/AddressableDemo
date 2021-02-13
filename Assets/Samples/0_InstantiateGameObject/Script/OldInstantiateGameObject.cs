using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OldInstantiateGameObject : MonoBehaviour
{
    public GameObject prefab;

    private AssetBundleManifest m_mainifest;

    public void InstantiateFromResources()
    {
        GameObject bus1Prefab = Resources.Load<GameObject>("Bus_1");
        GameObject bus1 = GameObject.Instantiate<GameObject>(bus1Prefab, Vector3.zero, Quaternion.identity);
    }

    AssetBundle LoadBundle(string bundleName)
    {
        AssetBundle ret = null;
        if (null != m_mainifest)
        {
            string[] dependencies = m_mainifest.GetAllDependencies(bundleName);
            foreach (string dependence in dependencies)
            {
                AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + dependence);
            }
        }

        ret = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + bundleName);

        return ret;
    }

    public void InstantiateFromAssetBundle()
    {
        AssetBundle mainifestBundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/StreamingAssets");
        if (mainifestBundle != null)
        {
            m_mainifest = mainifestBundle.LoadAsset<AssetBundleManifest>("assetbundlemanifest");
        }
        AssetBundle ab = LoadBundle("bus2");
        GameObject bus2Prefab = ab.LoadAsset("Bus_2") as GameObject;
        GameObject bus2 = GameObject.Instantiate<GameObject>(bus2Prefab, Vector3.right * 2.0f, Quaternion.identity);
    }

    public void InstantiateFromPublicRef()
    {
        if (prefab != null)
        {
            GameObject car = GameObject.Instantiate<GameObject>(prefab, Vector3.right * 4.0f, Quaternion.identity);
        }
    }

    public void LoadSceneAddtive()
    {
        SceneManager.LoadSceneAsync("PoliceCar", LoadSceneMode.Additive);
    }
}
