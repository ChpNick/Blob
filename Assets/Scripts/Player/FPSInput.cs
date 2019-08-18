using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт отвечающий за движение персонажа

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
    public float speed = 6.0f;
    public float gravity = -9.8f;
    [SerializeField] private FixedJoystick _fixedJoystick;

    private CharacterController _charController;

    void Start() {
        _charController = GetComponent<CharacterController>();
    }

    void Update() {
//        Debug.Log(1 / Time.deltaTime);
        float deltaX = Input.GetAxis("Horizontal") * speed + _fixedJoystick.Horizontal * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed + _fixedJoystick.Vertical * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}