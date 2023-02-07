using System;
using UnityEngine;
using UnityEngine.AI;


namespace WreckingOI.Character.AI
{
    public class AIPlayer : Character
    {
        private NavMeshAgent _agent;
        private GetPoint _getPoint;
        private AISettingsSO _aISettings;

        protected override void Awake()
        {
            base.Awake();
            GetReference();
        }

        protected override void Movement()
        {
            if (!_agent.hasPath)
            {
                _agent.SetDestination(_getPoint.GetRandomPoint());
            }
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