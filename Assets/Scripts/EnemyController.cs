using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MoveForward
{
    public GameManager GameManager;
    public int Damage = -1;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            GameManager.AddScore();
            //unistavamo projektil
            Destroy(other.gameObject);
            //unistavamo enemya
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Shredder"))
        {
            GameManager.ManagePlayerLives(Damage);

            Destroy(gameObject);
        }

    }

    void Update()
    {
        Move();
    }
}
