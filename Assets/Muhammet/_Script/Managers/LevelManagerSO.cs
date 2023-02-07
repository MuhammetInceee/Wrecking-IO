using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace WreckingOI.Managers
{
    [CreateAssetMenu(menuName = "WreckingIO/Manager/LevelManagerSettings")]
    public class LevelManagerSO : ScriptableObject
    {
        [SerializeField] private List<float> levelDurations;
        public List<float> LevelDurations => levelDurations;

        [TabGroup("Durations")][SerializeField] private float colorChangeDuration;
        public float ColorChangeDuration => colorChangeDuration;

        [TabGroup("Durations")][SerializeField] private float scaleZeroDuration;
        public float ScaleZeroDuration => scaleZeroDuration;
    }
}