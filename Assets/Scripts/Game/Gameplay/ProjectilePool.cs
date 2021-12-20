namespace Game.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ProjectilePool : MonoBehaviour
    {
        [SerializeField] private GameObject playerProjectile;
        private int amountToPoll = 50;
        private List<GameObject> _playerProjectiles;

        // Start is called before the first frame update
        void Start()
        {
            CreatePlayerProjectiles();
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

        public GameObject GetPlayerProjectile()
        {
            for (int i = 0; i < amountToPoll; i++)
            {
                if (!_playerProjectiles[i].activeInHierarchy)
                    return _playerProjectiles[i];
            }

            return null;
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