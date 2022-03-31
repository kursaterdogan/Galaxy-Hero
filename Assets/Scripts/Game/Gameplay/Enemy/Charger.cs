namespace Game.Gameplay.Enemy
{
    public class Charger : Enemy
    {
        //TODO Charger
        protected override void Attack()
        {
            float speedIncrease = speed / 4;
            speed += speedIncrease;
        }
    }
}