using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private List<Transform> objectList;
    [SerializeField] private float rotateSpeed;

    [SerializeField] private bool isForward;
    
    [SerializeField] private bool x;
    [SerializeField] private bool y;
    [SerializeField] private bool z;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        foreach (Transform objects in objectList)
        {
            if (x && !y && !z && isForward)
            {
                objects.Rotate(Vector3.right * rotateSpeed);
            }
            if (x && !y && !z && !isForward)
            {
                objects.Rotate(Vector3.left * rotateSpeed);
            }
            if (!x && y && !z && isForward)
            {
                objects.Rotate(Vector3.up * rotateSpeed);
            }
            if (!x && y && !z && !isForward)
            {
                objects.Rotate(Vector3.down * rotateSpeed);
            }            
            if (!x && !y && z && isForward)
            {
                objects.Rotate(Vector3.forward * rotateSpeed);
            }            
            if (!x && !y && z && !isForward)
            {
                objects.Rotate(Vector3.back * rotateSpeed);
            }
        }
    }
}
