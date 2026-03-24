using System;
using UnityEngine;
using UnityEngine.Rendering;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRightCollider;
    [SerializeField] WheelCollider backRightCollider;
    [SerializeField] WheelCollider frontLeftCollider;
    [SerializeField] WheelCollider backLeftCollider;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backLeftTransform;

    [SerializeField] float motorForce = 400f;
    [SerializeField] float brakeForce = 1000;
    [SerializeField] float maxSteerAngle = 30f;

    private float horizontalInput;
    private float verticalInput;
    private float currentBrakeForce = 0f;
    private float currentSteerAngle;
    private bool isBraking;
    private void Update()
    {
        GetInput();
        ApplyBreaking();
        HandleMotor();
        HandleStering();
        UpdateWheels();
    }
    private void GetInput() 
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBraking = Input.GetKey(KeyCode.Space);
    }
    private void HandleMotor()
    {
        frontLeftCollider.motorTorque = verticalInput * motorForce;
        frontRightCollider.motorTorque = verticalInput *motorForce;
        currentBrakeForce = isBraking ? brakeForce : 0f;
    }
    private void ApplyBreaking()
    {
        frontRightCollider.brakeTorque = currentBrakeForce;
        backRightCollider.brakeTorque = currentBrakeForce;
        frontLeftCollider.brakeTorque = currentBrakeForce;  
        backLeftCollider.brakeTorque = currentBrakeForce;
    }
    private void HandleStering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftCollider.steerAngle=currentSteerAngle;
        frontRightCollider.steerAngle = currentSteerAngle;
    }
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }
    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftCollider, frontLeftTransform);
        UpdateSingleWheel(frontRightCollider, frontRightTransform);
        UpdateSingleWheel(backLeftCollider, backLeftTransform);
        UpdateSingleWheel(backRightCollider, backRightTransform);

    }
}
