
using UdonSharp;
using UnityEngine;
using VRC.Core.Pool;
using VRC.SDKBase;
using VRC.Udon;

public class ObjectPoolController : UdonSharpBehaviour
{
    //[SerializeField] ObjectPool<GameObject> LinkedObjectPool;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Home))
        {
            //LinkedObjectPool.Release();
        }
    }
}
