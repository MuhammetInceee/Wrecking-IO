using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WreckingOI.Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class Character : MonoBehaviour
    {
        protected Rigidbody Rb;
        
        protected virtual void Awake()
        {
            Rb = GetComponent<Rigidbody>();
        }

        protected virtual void Update()
        {
            Movement();
        }

        protected virtual void Movement() { }
    }
}
