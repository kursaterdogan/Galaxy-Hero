using UnityEngine;

namespace Game.Gameplay.Enemy
{
    public class Charger : Enemy
    {
        [SerializeField] private float speedIncreaseDivider = 4.0f;

        protected override void Attack()
        {
            float speedIncrease = speed / speedIncreaseDivider;
            speed += speedIncrease;
        }
    }
}