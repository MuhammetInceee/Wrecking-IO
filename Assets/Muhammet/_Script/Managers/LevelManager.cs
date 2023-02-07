using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace WreckingOI.Managers
{
    public class LevelManager : MonoBehaviour
    {
        private int _levelCount;
        private PlayerStateManager _playerStateManager;
        private LevelManagerSO _levelManagerSettings;
        
        [SerializeField] private List<LevelHolder> levelHolder;

        private void Awake()
        {
            ResourcesLoad();
            _playerStateManager = FindObjectOfType<PlayerStateManager>();

            LevelSpaceNarrower(); 
        }

        private void LevelSpaceNarrower()
        {
            if(_playerStateManager.GetCurrentState() != PlayerStateHolder.Play) return;
            
            
        }

        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(_levelManagerSettings.LevelDurations[_levelCount]);
            
            
        }
        
        private void ResourcesLoad()
        {
            _levelManagerSettings = Resources.Load("Managers/LevelManagerSettings") as LevelManagerSO;
        }
        
    }

    [System.Serializable]
    public struct LevelHolder
    {
        public List<GameObject> level;
    }
}
