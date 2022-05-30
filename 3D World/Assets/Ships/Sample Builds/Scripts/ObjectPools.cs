using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPools : MonoBehaviour
{
    [SerializeField] ExplosionHandler explosionPrefab;
    [SerializeField] MissileBase MissilePrefab;

    private void Awake()
    {
        ExplosionPoolHandler.Instance.ExplosionPrefab = explosionPrefab;
        MissilePoolHandler.Instance.MissilePrefab = MissilePrefab;

        MissilePoolHandler.Instance.InitPool();
        ExplosionPoolHandler.Instance.InitPool();
    }


}
