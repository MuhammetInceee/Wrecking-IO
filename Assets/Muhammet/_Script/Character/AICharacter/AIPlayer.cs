using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;


namespace WreckingOI.Character.AI
{
    public class AIPlayer : Character
    {
        private NavMeshAgent _agent;
        private GetPoint _getPoint;
        private AISettingsSO _aISettings;

        private bool _canHit = true;

        [SerializeField] private List<GameObject> theOtherCharacters;

        protected override void Awake()
        {
            base.Awake();
            GetReference();
            StopCar();
        }

        protected override void Update()
        {
            base.Update();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
            }

            HitCheck();
        }

        protected override void Movement()
        {
            if (!_agent.hasPath)
            {
                _agent.SetDestination(_getPoint.GetRandomPoint());
            }
        }

        private void HitCheck()
        {
            //print(Vector3.Distance(transform.position, GetClosestEnemy().position));
            
            if (Vector3.Distance(transform.position, GetClosestEnemy().position) <= _aISettings.MinimumHitRange && _canHit)
            {
                StopCar();
                Hit();
            }
        }

        private void Hit()
        {
            // Sequence sequence = DOTween.Sequence();
            //
            // sequence.Append(transform.DOLookAt(targetTr.position, 1f));
            // sequence.Append(transform.DORotate(transform.rotation * Vector3.back, 2f));
            // transform.LookAt(targetTr);

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

            Rb.constraints = RigidbodyConstraints.FreezePosition;
        }

        private IEnumerator FreedomForCar()
        {
            yield return new WaitForSeconds(1f);
            _agent.speed = 3.5f;
            _agent.angularSpeed = 120;
            Rb.constraints = RigidbodyConstraints.None;
            _canHit = true;
        }

        private void GetReference()
        {
            _agent = GetComponent<NavMeshAgent>();
            _getPoint = FindObjectOfType<GetPoint>();
            _aISettings = Resources.Load("Characters/AICharacters/AICharacterSettings") as AISettingsSO;
        }

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            
            Gizmos.DrawWireSphere(transform.position, _aISettings == null ? 0 : _aISettings.Radius);
        }

#endif
    }
}