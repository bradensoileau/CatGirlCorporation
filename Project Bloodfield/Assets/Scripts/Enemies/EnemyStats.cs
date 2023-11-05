using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using static ScoreBoard;

public class EnemyStats : MonoBehaviour
{
    public float health = 50f;
    public GameObject floatingTextPrefab;
    public ScoreBoard scoreBoard;

    public void Start()
    {
        scoreBoard = GameObject.FindObjectOfType<ScoreBoard>(); // Find the ScoreBoard script in your scene
    }
    public void TakeDamage(float damageAmount)
    {
        if (floatingTextPrefab)
        {
            Debug.Log("damage");
            GameObject damageTextObject = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            DamageText damageText = damageTextObject.GetComponent<DamageText>();
            damageText.ShowDamage(damageAmount, transform.position);
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
        if (scoreBoard != null)
        {
            scoreBoard.AddScore(1);
        }
        Destroy(gameObject);
    }

   /* void ShowFloatingText(float damageAmount)
    {
        var spawnText = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        spawnText.GetComponent<TextMesh>().text = damageAmount.ToString();
    }*/
}
