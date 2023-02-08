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
            _mainPlayer = FindObjectOfType<MainPlayer>().gameObject;
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
                print("LooseScreenComes");
                
            }

            else if (allCharacters.Contains(_mainPlayer) && allCharacters.Count == 1)
            {
                print("LevelWonScreenComes");
                Time.timeScale = 0;
            }
        }
    }
}