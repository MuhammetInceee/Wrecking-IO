using System.Collections.Generic;
using UnityEngine;

namespace WreckingOI.Managers
{
    [CreateAssetMenu(menuName = "WreckingIO/Manager/LevelManagerSettings")]
    public class LevelManagerSO : ScriptableObject
    {
        [SerializeField] private List<float> levelDurations;
        public List<float> LevelDurations => levelDurations;

        [SerializeField] private float colorChangeDuration;
        public float ColorChangeDuration => colorChangeDuration;

        [SerializeField] private float scaleZeroDuration;
        public float ScaleZeroDuration => scaleZeroDuration;
    }
}