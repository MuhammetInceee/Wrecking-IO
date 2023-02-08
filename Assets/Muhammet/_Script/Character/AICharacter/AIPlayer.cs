using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


namespace WreckingOI.Character.AI
{
    public class AIPlayer : Character
    {
        private NavMeshAgent _agent;
        private AISettingsSO _aISettings;
        private GameObject _targetPos;

        private bool _canHit = true;
        
        protected override void Awake()
        {
            base.Awake();
            GetReference();
            ResourcesLoad();
            SetTarget();

        }

        protected override void Update()
        {
            base.Update();
            HitCheck();
        }

        protected override void Movement()
        {
            _agent.SetDestination(_targetPos.transform.position);
        }

        public void SetTarget()
        {
            _targetPos = theOtherCharacters[Random.Range(0, theOtherCharacters.Count)];
            transform.DOLookAt(_targetPos.transform.position, 0.5f);
        }

        private void HitCheck()
        {
            if (Vector3.Distance(transform.position, GetClosestEnemy().position) <= _aISettings.MinimumHitRange && _canHit)
            {
                StopCar();
                Hit();
            }
        }

        protected override void Hit()
        {
            transform.DORotate(Vector3.up * 360, 1f)
                .SetRelative();
            _canHit = false;
            StartCoroutine(FreedomForCar());
        }
        

        private Transform GetClosestEnemy()
        {
            Transform bestTarget = null;
            float closestDistanceSqr = Mathf.Infinity;
            Vector3 currentPosition = transform.position;
            
            foreach (GameObject potentialTarget in theOtherCharacters)
            {
                Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget.transform;
                }
            }
            return bestTarget;
        }

        private void StopCar()
        {
            _agent.speed = 0;
            _agent.angularSpeed = 0;
        }

        private IEnumerator FreedomForCar()
        {
            yield return new WaitForSeconds(1f);
            _agent.speed = 3.5f;
            _agent.angularSpeed = 120;
            _canHit = true;
            SetTarget();
        }

        private void GetReference()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void ResourcesLoad()
        {
            _aISettings = Resources.Load("Characters/AICharacters/AICharacterSettings") as AISettingsSO;
        }
        
        private void OnDestroy()
        {
            for (int i = 0; i < theOtherCharacters.Count; i++)
            {
                if (theOtherCharacters[i].transform.root.name != "MainPlayerRoot")
                {
                    theOtherCharacters[i].GetComponent<AIPlayer>().SetTarget();
                }
            }
        }
    }
}