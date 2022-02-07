using UnityEngine;

namespace Game.Gameplay
{
    public class ProjectileShredder : MonoBehaviour
    {
        //TODO Integrate with StateMachine
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("PlayerProjectile"))
            {
                col.gameObject.SetActive(false);
            }
        }
    }
}