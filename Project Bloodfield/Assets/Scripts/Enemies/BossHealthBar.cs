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
        boss = GameObject.FindGameObjectWithTag("Enemy");
        bossHealth = boss.GetComponent<EnemyStats>();
        maxHealth = bossHealth.health;
        if(!boss)
        {
            bossHealthBar.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!boss)
        {
            bossHealthBar.SetActive(false);
        }
        float currentHealth = bossHealth.health;
        healthBar.fillAmount = currentHealth / maxHealth;
        if(currentHealth == 0)
        {
            bossHealthBar.SetActive(false);
        }
    }

}
