using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPools : MonoBehaviour
{
    [SerializeField] ExplosionHandler explosionPrefab;
    void Start()
    {
        ExplosionPoolHandler.Instance.ExplosionPrefab = explosionPrefab;

        MissilePoolHandler.Instance.InitPool();
        ExplosionPoolHandler.Instance.InitPool();
    }

}
