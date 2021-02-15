using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadFromLocalAndRemote : MonoBehaviour
{
    public void InstantiateCheese()
    {
        Addressables.InstantiateAsync("Assets/Samples/2_Remote/FBX/Cheese.fbx", Vector3.right * 1.0f, Quaternion.identity);
    }

    public void InstantiateHotdog()
    {
        Addressables.InstantiateAsync("Assets/Samples/2_Remote/FBX/Hotdog.fbx", Vector3.right * 3.0f, Quaternion.identity);
    }
}
