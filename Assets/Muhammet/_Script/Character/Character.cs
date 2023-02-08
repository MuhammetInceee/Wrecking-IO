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
        
        [SerializeField] protected List<GameObject> theOtherCharacters;
        
        protected virtual void Awake()
        {
            Rb = GetComponent<Rigidbody>();
        }

        protected virtual void Update()
        {
            Movement();
        }

        protected virtual void Movement() { }
        protected virtual void Hit() { }
        protected virtual void SetTarget() { }

        public void DestroyYourself()
        {
            Destroy(transform.root.gameObject);
        }
    }
}
