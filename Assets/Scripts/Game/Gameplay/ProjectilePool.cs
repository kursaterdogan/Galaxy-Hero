using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    public class ProjectilePool : MonoBehaviour
    {
        //TODO Integrate with StateMachine
        [SerializeField] private GameObject playerProjectile;
        private List<GameObject> _playerProjectiles;
        private int amountToPoll = 10;

        void Awake()
        {
            CreatePlayerProjectiles();
        }

        public GameObject GetPlayerProjectile()
        {
            for (int i = 0; i < amountToPoll; i++)
            {
                if (!_playerProjectiles[i].activeInHierarchy)
                    return _playerProjectiles[i];
            }

            return null;
        }

        private void CreatePlayerProjectiles()
        {
            _playerProjectiles = new List<GameObject>();

            for (int i = 0; i < amountToPoll; i++)
            {
                GameObject temp = Instantiate(playerProjectile, transform);
                temp.SetActive(false);
                _playerProjectiles.Add(temp);
            }
        }

        private void ResetPlayerProjectiles()
        {
            for (int i = 0; i < amountToPoll; i++)
            {
                if (_playerProjectiles[i].activeInHierarchy)
                    _playerProjectiles[i].SetActive(false);
            }
        }
    }
}