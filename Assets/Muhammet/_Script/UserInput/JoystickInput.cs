using System;
using UnityEngine;

namespace WreckingOI.UserInput
{
    public class JoystickInput : MonoBehaviour
    {
        private Vector3 _movementVector;

        [SerializeField] private FloatingJoystick joystick;


        public bool IsStop => joystick.Horizontal == 0 && joystick.Vertical == 0;
        public float JoystickHorizontal => joystick.Horizontal;

        public Vector3 CalculateMoveVector(float movementSpeed)
        {
            _movementVector = Vector3.zero;
            _movementVector.x = joystick.Horizontal * movementSpeed * Time.deltaTime;
            _movementVector.z = joystick.Vertical * movementSpeed * Time.deltaTime;
            
            return _movementVector;
        }
    }
}