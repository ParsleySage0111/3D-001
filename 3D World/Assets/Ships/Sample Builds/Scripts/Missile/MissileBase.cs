using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBase : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody MissileRB;
    [SerializeField] Collider MissileCollider;
    [Header("Missile Config")]
    [SerializeField] float Speed = 100;
    [SerializeField] float MaxRange = 800,
        TrackRate = 12,
        ProximityFuse = 5,
        DeviationSpeed = 5,
        DeviationAmount = 3,
        LeadTime = 10;

    #region Private Variables
    bool isTracking = false;
    bool isArmed = false;
    Vector3 offset, deviatedOffset;
    Transform _t;
    Quaternion rotation;
    #endregion

    //public Transform TargetTransform { private get; set; }
    public Rigidbody TargetRB { private get; set; }
    public Transform TargetTransform;
    void Start()
    {
        Init();
        _t = transform;   

    }

    private void Init()
    {
        TargetRB = TargetTransform.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var BasePrediction = PredictMovement(LeadTime);
        var DeviatedPrediction = AddDeviation(BasePrediction, LeadTime);
        RotateMissile(DeviatedPrediction);
    }

    void RotateMissile(Vector3 deviatedPrediction)
    {
        offset = deviatedPrediction - _t.position;
        rotation = Quaternion.LookRotation(offset);
        MissileRB.MoveRotation(Quaternion.RotateTowards(_t.rotation, rotation, TrackRate * Time.deltaTime));
    }

    private Vector3 PredictMovement(float leadTime)
    {
        var predictionTime = Mathf.Lerp(0, 10, leadTime);
        var basePrediction = TargetTransform.position + TargetRB.velocity * predictionTime;
        return basePrediction;
    }

    private Vector3 AddDeviation(Vector3 basePrediction, float leadTime)
    {
        var deviation = new Vector3(Mathf.Cos(Time.time * DeviationSpeed), 0, 0);
        var predictionOffset = _t.TransformDirection(deviation) * DeviationAmount * leadTime;
        return basePrediction + predictionOffset;
    }

    private void FixedUpdate()
    {
        MissileRB.velocity = _t.forward * Speed;
    }
}
