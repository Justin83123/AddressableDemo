using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class NewInstantiateGameObject : MonoBehaviour
{
    public AssetReferenceGameObject assetRef;

    private void Start()
    {
        //Debug.Log("BuildTarget: " + UnityEditor.EditorUserBuildSettings.activeBuildTarget);
        Debug.Log("LocalBuildPath: " + UnityEngine.AddressableAssets.Addressables.BuildPath);
        Debug.Log("LocalLoadPath: " + UnityEngine.AddressableAssets.Addressables.RuntimePath);
        //Debug.Log("RemoteBuildPath: " + );
        //Debug.Log("RemoteLoadPath: " + UnityEngine.AddressableAssets.Addressables.RuntimePath);
    }

    public void InstantiateFromAssetRef()
    {
        if (assetRef != null)
        {
            assetRef.InstantiateAsync(Vector3.right * 6.0f, Quaternion.identity);
        }
    }

    public void InstantiateFromAddress()
    {
        Addressables.InstantiateAsync("Assets/Samples/0_InstantiateGameObject/Addressable/Car_3.prefab", Vector3.right * 8.0f, Quaternion.identity);
        //Addressables.InstantiateAsync("Cube.prefab", Vector3.up * 2.0f, Quaternion.identity);
    }

    public void LoadAndInstantiateFromAddress()
    {
        Addressables.LoadAssetAsync<GameObject>("Assets/Samples/0_InstantiateGameObject/Addressable/Car_4.prefab").Completed += OnLoadDone;
    }

    public void LoadScene()
    {
        Addressables.LoadSceneAsync("Assets/Samples/0_InstantiateGameObject/Scenes/Taxi.unity", UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }

    private void OnLoadDone(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject prefab = obj.Result;
            GameObject.Instantiate(prefab, Vector3.right * 10.0f, Quaternion.identity);
        }
    }
}
