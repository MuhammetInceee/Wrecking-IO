using System;
using System.Collections.Generic;
using UnityEngine;
using WreckingOI.Character.Main;
using WreckingOI.Signals;

namespace WreckingOI.Managers
{
    public class GameManager : MonoBehaviour
    {
        private GameObject _mainPlayer;
        private PlayerStateManager _playerState;

        public List<GameObject> allCharacters;


        private void OnEnable()
        {
            SubscribeEvent();
        }

        private void OnDisable()
        {
            UnSubscribeEvent();
        }

        private void Awake()
        {
            GetReference();
        }

        private void SubscribeEvent()
        {
            CoreGameSignals.OnLevelCheck += CheckGameSituation;
            CoreGameSignals.OnDeath += OnDeath;
        }

        private void UnSubscribeEvent()
        {
            CoreGameSignals.OnLevelCheck -= CheckGameSituation;
            CoreGameSignals.OnDeath -= OnDeath;
        }

        private void OnDeath(GameObject gO)
        {
            allCharacters.Remove(gO);
        }

        private void CheckGameSituation()
        {
            if (!allCharacters.Contains(_mainPlayer))
            {
                UISignals.OnLevelFail.Invoke();
                _playerState.SetNewPlayerState(PlayerStateHolder.Wait);
            }

            else if (allCharacters.Contains(_mainPlayer) && allCharacters.Count == 1)
            {
                UISignals.OnLevelSuccess.Invoke();
                _playerState.SetNewPlayerState(PlayerStateHolder.Wait);
            }
        }

        private void GetReference()
        {
            _mainPlayer = FindObjectOfType<MainPlayer>().gameObject;
            _playerState = FindObjectOfType<PlayerStateManager>();
        }
    }
}