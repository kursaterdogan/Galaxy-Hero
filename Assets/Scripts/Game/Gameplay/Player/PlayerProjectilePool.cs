using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public class PlayerProjectilePool : MonoBehaviour
    {
        //TODO Integrate with StateMachine
        private const int AmountToPoll = 3;

        [SerializeField] private PlayerProjectile playerProjectilePrefab;
        private List<PlayerProjectile> _playerProjectiles;

        private float _maxVerticalPosition;

        void Awake()
        {
            SetMaxVerticalPosition();
            CreatePool();
        }

        public PlayerProjectile GetPlayerProjectile()
        {
            foreach (PlayerProjectile playerProjectile in _playerProjectiles)
            {
                if (!playerProjectile.gameObject.activeInHierarchy)
                    return playerProjectile;
            }

            return CreatePlayerProjectile();
        }

        private void SetMaxVerticalPosition()
        {
            _maxVerticalPosition = FindObjectOfType<GameCamera>().GetMaxVerticalPosition();
        }

        private void CreatePool()
        {
            _playerProjectiles = new List<PlayerProjectile>();

            for (int i = 0; i < AmountToPoll; i++)
            {
                CreatePlayerProjectile();
            }
        }

        private PlayerProjectile CreatePlayerProjectile()
        {
            PlayerProjectile playerProjectile = Instantiate(playerProjectilePrefab, transform);
            playerProjectile.SetDestroyPosition(_maxVerticalPosition);
            playerProjectile.gameObject.SetActive(false);
            _playerProjectiles.Add(playerProjectile);
            return playerProjectile;
        }
    }
}