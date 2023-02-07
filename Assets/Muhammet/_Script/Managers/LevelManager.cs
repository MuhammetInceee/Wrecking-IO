using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

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

            StartCoroutine(LevelSpaceNarrower());

        }

        private IEnumerator LevelSpaceNarrower()
        {
            if(_playerStateManager.GetCurrentState() != PlayerStateHolder.Play) yield break;
            
            
            yield return new WaitForSeconds(_levelManagerSettings.LevelDurations[_levelCount]);

            foreach (GameObject gO in levelHolder[_levelCount].level)
            {
                MeshRenderer mesh = gO.GetComponent<MeshRenderer>();

                Sequence sequence = DOTween.Sequence();

                sequence.Append(mesh.material.DOColor(Color.red, _levelManagerSettings.ColorChangeDuration));
                sequence.Append(gO.transform.DOScale(Vector3.zero, _levelManagerSettings.ScaleZeroDuration));
                sequence.OnComplete(() =>
                {
                    Destroy(gO);
                    _levelCount++;
                    StartCoroutine(LevelSpaceNarrower());
                });
            }
            
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
