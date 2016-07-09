using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Main.Enemies
{
    class BasicEnemy : MonoBehaviour , IEnemy
    {
        public int direction = 1;
        private Vector3 _endPoint;
        private Vector3 _spawnPoint;
        private bool _initializedState;
        private Vector3 _xVelocity = Vector3.zero;
        private NavMeshAgent _navMeshAgent;

        // Use this for initialization
        void Start()
        {
            _initializedState = true;

            if (direction == 1)
            {
                _spawnPoint = ConfigurationSettings.DirectionOneStartPoint;
                _endPoint = ConfigurationSettings.DirectionOneEndPoint;
            }
            else
            {
                _spawnPoint = ConfigurationSettings.DirectionTwoStartPoint;
                _endPoint = ConfigurationSettings.DirectionTwoEndPoint;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (_initializedState)
            {
                MoveToFirstGridSpace();
            }

            if (!_initializedState)
            {
                MoveNext();
            }
        }

        //Possibly make calls to grid to get next move?
        public void MoveNext()
        {
            /*     Implement A*      */
            _navMeshAgent.SetDestination(_endPoint);
        }

        public void MoveToFirstGridSpace()
        {
            transform.position = Vector3.SmoothDamp(transform.position, _spawnPoint, ref _xVelocity, 0.1f);
            if (Mathf.Abs((_spawnPoint.x - transform.position.x)) < 0.01 && Mathf.Abs((_spawnPoint.z - transform.position.z)) < 0.01)
            {
                _initializedState = false;
                transform.position = _spawnPoint; 
            }
            _initializedState = false;
            _navMeshAgent = GetComponent<NavMeshAgent>(); //Remove
        }

        public void CurrentHealth()
        {
            throw new NotImplementedException();
        }

        public void Die()
        {
            throw new NotImplementedException();
        }

        public void Enrage()
        {
            throw new NotImplementedException();
        }
    }
}
