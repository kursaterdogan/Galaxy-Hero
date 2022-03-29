using System.Collections.Generic;
using Base.Gameplay;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public class PlayerProjectilePool : MonoBehaviour
    {
        [SerializeField] private PlayerProjectile playerProjectilePrefab;
        private readonly List<PlayerProjectile> _playerProjectiles = new List<PlayerProjectile>();

        private float _maxVerticalPosition;

        public PlayerProjectile GetPlayerProjectile()
        {
            foreach (PlayerProjectile playerProjectile in _playerProjectiles)
            {
                if (!playerProjectile.gameObject.activeInHierarchy)
                    return playerProjectile;
            }

            return CreatePlayerProjectile();
        }

        public void SetMaxVerticalPosition(float maxVerticalPosition)
        {
            _maxVerticalPosition = maxVerticalPosition;
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