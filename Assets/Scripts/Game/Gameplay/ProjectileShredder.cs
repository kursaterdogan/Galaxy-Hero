namespace Game.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

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