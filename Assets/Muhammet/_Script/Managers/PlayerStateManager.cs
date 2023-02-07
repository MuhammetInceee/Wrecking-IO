using UnityEngine;

namespace WreckingOI.Managers
{
    public class PlayerStateManager : MonoBehaviour
    {
        private PlayerStateSO _playerStateSO;
        private void Awake()
        {
            ResourcesLoad();
            
            SetNewPlayerState(PlayerStateHolder.Play);
        }
        
        public PlayerStateHolder GetCurrentState()
        {
            return _playerStateSO.playerState;
        }

        public void SetNewPlayerState(PlayerStateHolder newState)
        {
            _playerStateSO.playerState = newState;
        }

        private void ResourcesLoad()
        {
            _playerStateSO = Resources.Load("Managers/PlayerState") as PlayerStateSO;
        }
    }
}
