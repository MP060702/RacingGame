using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horiziontalInput;
    private float verticalInput;
    private bool isbreaking;
    private float currentbreakForce;
    private float currentsteerAngle;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransfrom;
    [SerializeField] private Transform frontRightWheelTransfrom;
    [SerializeField] private Transform rearLeftWheelTransfrom;
    [SerializeField] private Transform rearRightWheelTransfrom;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isbreaking ? breakForce : 0f;
        if (isbreaking)
        {
            ApplyBreaking();
        }
    }

    private void ApplyBreaking()
    {
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void GetInput()
    {
        horiziontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isbreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleSteering()
    {
        currentsteerAngle = maxSteerAngle * horiziontalInput;
        frontLeftWheelCollider.steerAngle = currentsteerAngle;
        frontRightWheelCollider.steerAngle = currentsteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransfrom);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransfrom);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransfrom);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransfrom);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
