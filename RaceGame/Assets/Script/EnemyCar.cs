using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    private  Transform WayPoints;
    [HideInInspector] public Vector3 TargetPoint;
    public int WayIndex;
    public List<AxleInfo> axleInfos;
    public GameObject Player;

    public void Start()
    {   
        wheel playerController = Player.GetComponent<wheel>();
        WayPoints = playerController.WayPoints;
        WayIndex = playerController.WayIndex + 2;
        transform.position = WayPoints.GetChild(WayIndex).position;
    }
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

        Vector3 WaypointDistance = transform.InverseTransformPoint(TargetPoint);
        WaypointDistance = WaypointDistance.normalized;
        steering = WaypointDistance.x * 25;
        Vector3 EndPoint = WayPoints.GetChild(WayIndex - 3).transform.position;

        if (Vector3.Distance(TargetPoint, transform.position) <= 30)
        {
            WayIndex--;
            TargetPoint = WayPoints.GetChild(WayIndex).position;
            if (TargetPoint == EndPoint) Destroy(gameObject);
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

}
