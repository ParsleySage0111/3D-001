using System.Threading.Tasks;
using UnityEngine;

public class MissileBase : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody missileRB;
    [SerializeField] Collider missileCollider;
    [Header("Missile Config")]
    [SerializeField] float Speed = 50;
    [SerializeField] int LifeSpan = 30,
        trackRate = 30,
        proximityFuse = 5,
        timeArmed = 3,
        timeTrack = 4,
        leadTime = 1;

    #region Private Variables
    bool isTracking = false;
    bool isArmed = false;
    float distance;
    Vector3 offset, finalOffset;
    Rigidbody targetRB;
    Transform _t, target;
    Quaternion rotation;
    MissilePoolHandler missilePool;
    #endregion

    #region Getter & Setter
    public Transform Target { set { target = value; } }
    #endregion

    private void Awake()
    {
        _t = transform;
    }
    void Start()
    {
        InitComponents();
    }
    private void OnEnable()
    {
        Invoke(nameof(Detonate), LifeSpan);
        Invoke(nameof(SetArmed), timeArmed);
        Invoke(nameof(SetTracking), timeTrack);
    }
    void SetArmed()
    {
        missileCollider.enabled = true;
        isArmed = true;
    }

    void SetTracking()
    {
        isTracking = true;
    }

    public void FireMissile()
    {
        SetObject(true);
        if(_t == null) { return; }
        _t.SetParent(null);
    }
    private void InitComponents()
    {
        targetRB = target.GetComponent<Rigidbody>();
        missilePool = MissilePoolHandler.Instance;
    }

    private void Update()
    {
        if (!isTracking) return;
        if (targetRB) finalOffset = PredictMovement(leadTime);
        else finalOffset = target.position;
        RotateMissile(finalOffset);
        if (!TargetInProx()) return;
        Detonate();
    }

    void RotateMissile(Vector3 deviatedPrediction)
    {
        offset = deviatedPrediction - _t.position;
        rotation = Quaternion.LookRotation(offset);
        missileRB.MoveRotation(Quaternion.RotateTowards(_t.rotation, rotation, trackRate * Time.deltaTime));
    }

    private Vector3 PredictMovement(float leadTime)
    {
        var predictionTime = Mathf.Lerp(0, 10, leadTime);
        var basePrediction = target.position + targetRB.velocity * predictionTime;
        return basePrediction;
    }

    private void FixedUpdate()
    {
        missileRB.velocity = _t.forward * Speed;
    }
    private bool TargetInProx()
    {
        distance = Vector3.Distance(_t.position, target.position);
        return (distance <= proximityFuse);
    }

    private void Detonate()
    {
        CancelInvoke();
        SetObject(false);
        ExplosionPoolHandler.Instance.SpawnExplosion(_t);
        missilePool.ReleaseMissile(this);
    }

    private void SetObject(bool isEnabled)
    {
        if (this == null) { return; }
        enabled = isEnabled;
        isArmed = false;
        isTracking = false;
        missileCollider.enabled = false;
        missileRB.isKinematic = !isEnabled;
    }

    private void OnCollisionEnter()
    {
        Detonate();
    }
}
