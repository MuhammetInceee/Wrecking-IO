using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WreckingOI.Signals;

namespace WreckingOI.Managers
{
    public class ConfettiManager : MonoBehaviour
    {
        [SerializeField] private List<ParticleSystem> confettiParticlesList;


        private void OnEnable()
        {
            SubscribeEvent();
        }

        private void OnDisable()
        {
            UnSubscribeEvent();
        }

        private void SubscribeEvent()
        {
            UISignals.OnLevelSuccess += Play;
        }

        private void UnSubscribeEvent()
        {
            UISignals.OnLevelSuccess -= Play;
        }


        public void Play()
        {
            if (confettiParticlesList.Count == 0)
            {
                Debug.Log($"<color=white><b>(!) Couldn't find confetti in the Confetti List.</b> </color>"); return;
            }
            Toggle();
            confettiParticlesList.ForEach(x => x.Play());
        }

        public void Stop()
        {
            if (confettiParticlesList.Count == 0)
            {
                Debug.Log($"<color=white><b>(!) Couldn't find confetti in the Confetti List.</b> </color>"); return;
            }

            Toggle();
            confettiParticlesList.ForEach(x => x.Stop());
        }

        private void Toggle() => confettiParticlesList.ForEach(x => x.gameObject.SetActive(!x.gameObject.activeInHierarchy));
    }
}
