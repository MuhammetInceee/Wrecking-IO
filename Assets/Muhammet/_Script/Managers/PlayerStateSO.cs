using UnityEngine;

namespace WreckingOI.Managers
{
    [CreateAssetMenu(menuName = "WreckingIO/Manager/PlayerState")]
    public class PlayerStateSO : ScriptableObject
    {
        public PlayerStateHolder playerState;
    }
    
    [System.Serializable]
    public enum PlayerStateHolder
    {
        Play,
        Wait
    }
}