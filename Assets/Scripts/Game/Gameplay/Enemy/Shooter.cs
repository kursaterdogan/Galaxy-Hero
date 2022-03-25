using UnityEngine;

namespace Game.Gameplay.Enemy
{
    public class Shooter : Enemy
    {
        //TODO Shooter
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform firingPoint;
        float _projectileSpeed = -10.0f;

        protected override void Attack()
        {
            GameObject laser = Instantiate(projectilePrefab);
            laser.transform.position = firingPoint.position;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, _projectileSpeed);
        }
    }
}