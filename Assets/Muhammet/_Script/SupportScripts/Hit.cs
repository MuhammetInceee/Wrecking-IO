using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lofelt.NiceVibrations;

namespace WreckingOI.SupportScripts.Collisions
{
    public class Hit : MonoBehaviour
    {
        private ParticleSystem _hitParticle;

        private void Awake()
        {
            _hitParticle = transform.GetChild(0).GetComponent<ParticleSystem>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Character.Character character))
            {
                CinemachineShake.Instance.ShakeCamera(1, 0.5f);
                _hitParticle.Play();
                HapticPatterns.PlayConstant(1,0,1);
            }
        }
    }
}
