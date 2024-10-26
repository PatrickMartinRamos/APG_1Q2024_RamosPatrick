using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carScript : MonoBehaviour
{
    [SerializeField] private Transform _flagPOS;
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private WheelJoint2D _backWheel;
    [SerializeField] private WheelJoint2D _frontWheel;

    [SerializeField] private Slider _slider;
    [SerializeField] private float carSpeed;
    [SerializeField] private JointMotor2D JointMotorSpeed2D;

    [SerializeField] private Camera cam;

    private void Start()
    {


        JointMotorSpeed2D.maxMotorTorque = 10000f;

        _slider.maxValue = 1000f;

    }

    private void Update()
    {
        //_slider.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        cam.transform.position = new Vector3(_playerTransform.transform.position.x, _playerTransform.transform.position.y, -10f);



        if (Input.GetKey(KeyCode.Space))
        {
            JointMotorSpeed2D.motorSpeed = _slider.value;
            _backWheel.motor = JointMotorSpeed2D;
            _frontWheel.motor = JointMotorSpeed2D;
        }
    }
}
