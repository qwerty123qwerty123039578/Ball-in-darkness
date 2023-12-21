using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Transform CameraCenter;
    public float TorqueValue;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        //_rigidbody.maxAngularVelocity = 500f;
    }
    private void FixedUpdate()
    {
        _rigidbody.AddTorque(CameraCenter.right * Input.GetAxis("Vertical") * TorqueValue);
        _rigidbody.AddTorque(-CameraCenter.forward * Input.GetAxis("Horizontal") * TorqueValue);
    }
    private void Update()
    {
        if(!GameManager.instance.isLose && transform.position.y < -1)
        {
            GameManager.instance.Lose();
        }

        if(GameManager.instance.isLose)
        {
            if(transform.position.y < -7)
            {
                transform.position = new Vector3(0f, 25f, 0f);
            }
            else if(transform.position.y > 0f && transform.position.x < 10f)
            {
                GameManager.instance.RestartGame();
            }
        }

    }
}
