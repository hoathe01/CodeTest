using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float movingSpeed;
    public float playerHealth;
    public Camera mainCamera;
    private GameObject _playerObiject;


    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        var movingPos = new Vector3(horizontalInput, 0, verticalInput);
        movingPos.Normalize();

        transform.LookAt(movingPos + transform.position);
        transform.Translate(movingPos * (Time.deltaTime * movingSpeed), Space.World);
        CameraSetUp();
    }

    public void CameraSetUp()
    {
        var addDistance = new Vector3(0, 7, -7);
        mainCamera.transform.position = transform.position + addDistance;
    }
}