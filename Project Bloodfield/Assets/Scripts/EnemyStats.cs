using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using static ScoreBoard;

public class EnemyStats : MonoBehaviour
{
    public float health = 50f;
    public GameObject floatingTextPrefab;
    //public ScoreBoard scoreBoard;
    public void TakeDamage(float damageAmount)
    {
        if (floatingTextPrefab && health >= 0)
        {
            Debug.Log("damage");
            ShowFloatingText(damageAmount);
        }

        health -= damageAmount;
        Debug.Log("damage2");
        if (health <= 1)
        {
            Debug.Log("die");
            Die();
        }
    }

    void Die()
    {
        //scoreBoard.AddScore(10);
        Destroy(gameObject);
    }

    void ShowFloatingText(float damageAmount)
    {
        var spawnText = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        spawnText.GetComponent<TextMesh>().text = damageAmount.ToString();
    }
}
