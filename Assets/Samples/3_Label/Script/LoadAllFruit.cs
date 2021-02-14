using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

public class LoadAllFruit : MonoBehaviour
{
    void Start()
    {
        AssetLabelReference label = new AssetLabelReference();
        label.labelString = "fruit";
        Addressables.LoadResourceLocationsAsync(label.labelString).Completed += OnFruitLoaded;
    }

    private void OnFruitLoaded(AsyncOperationHandle<IList<IResourceLocation>> op)
    {
        if (op.Status == AsyncOperationStatus.Succeeded)
        {
            float pos = 0.0f;
            Debug.Log("op.Result.Count: " + op.Result.Count);
            for(int i = 0; i < op.Result.Count; ++i)
            {
                IResourceLocation prefab = op.Result[i];
                Addressables.InstantiateAsync(prefab, Vector3.right * pos, Quaternion.identity);
                pos += 1.0f;

            }
        }
    }
}
