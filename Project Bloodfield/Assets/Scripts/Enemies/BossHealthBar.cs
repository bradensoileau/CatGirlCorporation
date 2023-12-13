using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BossHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image healthBar;
    public GameObject boss;
    private float maxHealth;
    public EnemyStats bossHealth;
    public GameObject bossHealthBar;

    void Start()
    {
        bossHealthBar.SetActive(false);
        boss = GameObject.FindGameObjectWithTag("Enemy");
        bossHealth = boss.GetComponent<EnemyStats>();
        maxHealth = bossHealth.health;
    }

    // Update is called once per frame
    void Update()
    {
        if(boss)
        {
            bossHealthBar.SetActive(true);
        }
        float currentHealth = bossHealth.health;
        healthBar.fillAmount = currentHealth / maxHealth;
        if(currentHealth == 0)
        {
            bossHealthBar.SetActive(false);
        }
    }

}