namespace Game.Gameplay.Enemy
{
    public class Charger : Enemy
    {
        protected override void Attack()
        {
            float speedIncrease = speed / 4;
            speed += speedIncrease;
        }
    }
}