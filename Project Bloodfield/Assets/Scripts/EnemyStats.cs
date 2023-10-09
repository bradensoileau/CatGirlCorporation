using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float health = 50f;
    public GameObject floatingTextPrefab;

    public void TakeDamage(float damageAmount)
    {
        if (floatingTextPrefab && health >= 0)
        {
            ShowFloatingText(damageAmount);
        }

        health -= damageAmount;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void ShowFloatingText(float damageAmount)
    {
        var spawnText = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        spawnText.GetComponent<TextMesh>().text = damageAmount.ToString();
    }
}
