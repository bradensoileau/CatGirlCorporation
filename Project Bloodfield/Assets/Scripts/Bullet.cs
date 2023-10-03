using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float bulletDamage = 10f;


    void OnTriggerEnter2D(Collider2D collision)
    {
        //GameObject effect(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        Destroy(gameObject);

        if (collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyStats>().TakeDamage(bulletDamage);
        }

        


    }


}
