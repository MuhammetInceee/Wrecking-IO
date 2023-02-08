using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WreckingOI.Character.AI
{
    [CreateAssetMenu(menuName = "WreckingIO/Character/AICharacter")]
    public class AISettingsSO : ScriptableObject
    {
        [SerializeField] private float radius;
        public float Radius => radius;

        [SerializeField] private float minimumHitRange;
        public float MinimumHitRange => minimumHitRange;
    }
}
