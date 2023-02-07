using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WreckingOI.UserInput;

namespace WreckingOI.Character
{
    public class MainPlayer : Character
    {
        private JoystickInput _joystickInput;
        private UserInputSO _userInput;

        protected override void Awake()
        {
            base.Awake();
            ResourcesLoad();
            GetReferences();
        }

        protected override void Movement()
        {
            if (_joystickInput.IsStop)
            {
                // idle pose
            }
            else
            {
                // movement pose
                Vector3 direction = 
                    Vector3.RotateTowards(transform.forward,
                    _joystickInput.CalculateMoveVector(_userInput.MovementSpeed), 
                    _userInput.RotateSpeed * Time.deltaTime, 0.0f);
                
                transform.rotation = Quaternion.LookRotation(direction);
            }
            
            Rb.MovePosition(Rb.position + _joystickInput.CalculateMoveVector(_userInput.MovementSpeed));
        }
        

        private void ResourcesLoad()
        {
            _userInput = Resources.Load("UserInput/UserInputController") as UserInputSO;
        }

        private void GetReferences()
        {
            _joystickInput = GetComponent<JoystickInput>();
        }
    }
}