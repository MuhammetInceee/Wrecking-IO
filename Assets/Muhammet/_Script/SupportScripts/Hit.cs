using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WreckingOI.SupportScripts.Collisions
{
    public class Hit : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Character.Character character))
            {
                CinemachineShake.Instance.ShakeCamera(1, 0.5f);
            }
        }
    }
}
