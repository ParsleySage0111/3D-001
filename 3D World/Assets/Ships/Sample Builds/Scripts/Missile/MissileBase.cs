using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBase : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody MissileRB;
    [Header("Missile Config")]
    [SerializeField] float 
        ThrusterForce = 0,
        MaxRange = 800,
        TrackRate = 12,
        ProximityFuse = 5;

    #region private variables
    bool isTracking = false;
    bool isArmed = false;
    #endregion

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
