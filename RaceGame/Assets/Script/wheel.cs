using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class wheel : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float BreakForce;

    public Transform center;

    public bool IsPlayer;
    public bool CanTouchFinishLine = false;
    public bool AICanTouchFinishLine = false;

    public int Laps;

    private Rigidbody rb;

    public Transform WayPoints;

    [HideInInspector] public Transform TargetPoint;

    public int WayIndex = 0;

    public GameObject[] wheelList;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = center.localPosition;

        TargetPoint = WayPoints.GetChild(WayIndex);

        if (gameObject.CompareTag("Player"))
        {
            IsPlayer = true;
            
        }
        else
        {
            IsPlayer = false;
        }
    }

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        float motor = 1000;
        float steering = 0;
        float Break = 0;

        if (IsPlayer)
        {
            motor = maxMotorTorque * Input.GetAxis("Vertical");
            steering = maxSteeringAngle * Input.GetAxis("Horizontal");
            Break = Input.GetKey(KeyCode.Space) ? BreakForce : 0;

            string[] wheelItemTags = { "DesertWheel", "MountainWheel", "CityWheel" };
 
        }
        else
        {
            Vector3 waypointDistance = transform.InverseTransformPoint(TargetPoint.position);
            waypointDistance = waypointDistance.normalized;
            steering = waypointDistance.x * 25;
        }

        if (Vector3.Distance(TargetPoint.position, transform.position) <= 40)
        {
            if (WayPoints.childCount > WayIndex)
                WayIndex++;

            if (WayIndex == WayPoints.childCount)
            {
                WayIndex = 0;

                if (IsPlayer)
                {
                    CanTouchFinishLine = true;
                }
                else
                {
                    AICanTouchFinishLine = true;
                }

            }
            TargetPoint = WayPoints.GetChild(WayIndex);
        }

    

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }

            axleInfo.leftWheel.brakeTorque = Break;
            axleInfo.rightWheel.brakeTorque = Break;

            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FinishLine"))
        {   
            if(AICanTouchFinishLine == true)
            {
                AICanTouchFinishLine = false;
                Laps++;

                if (Laps >= 3)
                {
                    Debug.Log("You Lose");
                }
            }
        }
    }
    private void Update()
    {
          if (IsPlayer)
          {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    rb.AddForce(transform.forward * 20000, ForceMode.Impulse);
                }
          }
        }
    }