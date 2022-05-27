using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BikeController : MonoBehaviour
{
    private VehicleControls AirBikeController;
    private VehicleControls.AirBikeActions AirBikeActions;
    [SerializeField] Animator BikeAnimator;
    [SerializeField] Rigidbody bikeRB;
    [SerializeField] Transform body;
    [SerializeField] float targetHeight;
    [SerializeField] float thrusterForce;
    [SerializeField] float stability, speed;
    [SerializeField] float forwardForce, steerForce;
    [SerializeField] float minHeight, maxHeight, throttleSensitivity;
    [SerializeField] float hoverHeight;


    private Vector2 move;
    private RaycastHit hit;
    private float throttle;
    private bool onFlight = false;

    [SerializeField] TextMeshProUGUI Mode;

    private void Awake()
    {
        AirBikeController = new VehicleControls();
        AirBikeActions = AirBikeController.AirBike;
    }

    private void OnEnable()
    {
        AirBikeController.Enable();
    }
    private void OnDisable()
    {
        AirBikeController.Disable();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Throttle(throttle);
        SetFlightMode(GetHeightDistance());
        SetAnimation();
        SetHUDInfo();
    }

    void SetAnimation()
    {
        BikeAnimator.SetFloat("steer", move.x);
    }
    void GetInput()
    {
        move = AirBikeActions.Move.ReadValue<Vector2>();
        throttle = AirBikeActions.Throttle.ReadValue<float>();
    }
    void Throttle(float throttle)
    {
        targetHeight += throttle * throttleSensitivity;
        targetHeight = Mathf.Clamp(targetHeight, minHeight, maxHeight);
    }
    
    private void SetHUDInfo()
    {
        Mode.SetText(onFlight.ToString());
    }
    private void SetFlightMode(float distance)
    {
        onFlight = distance >= hoverHeight;
    }
    private float GetHeightDistance()
    {
        var isHit = Physics.Raycast(body.position, -Vector3.up, out hit);
        if (isHit) { return hit.distance; }
        return body.position.y;
    }

    private float Distance(Transform transform)
    {
        var isHit = Physics.Raycast(body.position, -Vector3.up, out hit);
        if (isHit && hit.distance <= hoverHeight) { return hit.distance; }
        return transform.position.y;
    }
    private void FixedUpdate()
    {
        var _t = transform;
        Vector3 predictUp = Angle(_t);
        Vector3 torqueVector = Torque(predictUp);
        float force = Force(Distance(_t));
        bikeRB.AddForce(Vector3.up * force, ForceMode.Force);
        bikeRB.AddForce(_t.forward * forwardForce * move.y, ForceMode.Force);
        bikeRB.AddTorque(_t.up * steerForce * move.x, ForceMode.Force);
        bikeRB.AddTorque(torqueVector * speed * speed);
    }

    private float Force(float distance)
    {
        return (targetHeight / distance) * thrusterForce;
    }

    private Vector3 Angle(Transform transform)
    {
        float axis = bikeRB.angularVelocity.magnitude * Mathf.Rad2Deg * stability / speed;
        return Quaternion.AngleAxis(axis, bikeRB.angularVelocity) * transform.up;
    }

    private Vector3 Torque(Vector3 predictUp)
    {
        return Vector3.Cross(predictUp, Vector3.up);
    }
}
