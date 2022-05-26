using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] float PositionTime, RotationTime;

    private Transform _t;

    private void Awake()
    {
        _t = transform;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var time = Time.deltaTime;
        LerpToPosition(time);
        LerpToRotation(time);
    }

    void LerpToPosition(float time)
    {
        _t.position = Vector3.Lerp(_t.position, Target.position, PositionTime * time) ;
    }

    void LerpToRotation(float time)
    {
        _t.rotation = Quaternion.Lerp(_t.rotation, Target.rotation, RotationTime * time);
    }
}
