using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public class ProjectilePool : MonoBehaviour
    {
        //TODO Integrate with StateMachine
        private const int AmountToPoll = 3;

        [SerializeField] private GameObject playerProjectile;
        private List<GameObject> _playerProjectiles;

        void Awake()
        {
            CreatePlayerProjectiles();
        }

        public GameObject GetPlayerProjectile()
        {
            for (int i = 0; i < _playerProjectiles.Count; i++)
            {
                if (!_playerProjectiles[i].activeInHierarchy)
                    return _playerProjectiles[i];
            }

            //TODO Optimize
            GameObject temporaryProjectile = Instantiate(playerProjectile, transform);
            temporaryProjectile.SetActive(false);
            _playerProjectiles.Add(temporaryProjectile);

            return temporaryProjectile;
        }

        private void CreatePlayerProjectiles()
        {
            _playerProjectiles = new List<GameObject>();

            for (int i = 0; i < AmountToPoll; i++)
            {
                GameObject temporaryProjectile = Instantiate(playerProjectile, transform);
                temporaryProjectile.SetActive(false);
                _playerProjectiles.Add(temporaryProjectile);
            }
        }
    }
}