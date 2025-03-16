using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : EnemyManager
{
    [SerializeField] GameObject Winner;
    [SerializeField] GameObject one;
    [SerializeField] GameObject two;
    [SerializeField] GameObject three;
    [SerializeField] private Image UI_hpEnemy;
    HealthPlayer healthPlayer;

    public override void Start()
    {
        base.Start();
        UpdateHealthUI();
        healthPlayer = FindObjectOfType<HealthPlayer>();
    }

    public override void takeDamage(int amount)
    {
        base.takeDamage(amount);
        UpdateHealthUI();
    }
    public override void Die()
    {
        base.Die();
        healthPlayer.canShake = false;
        Winner.SetActive(true);
        Time.timeScale = 0;
        takeStar(0);
    }
    void UpdateHealthUI()
    {
        UI_hpEnemy.fillAmount = (float)currentHealth / maxHealth;
    }

    void takeStar(float amount)
    {
        healthPlayer.takeDamage(amount);
        if (8 <= healthPlayer.currentHealth && healthPlayer.currentHealth <= 10)
        {
            three.SetActive(true);

        }
        else if (5 <= healthPlayer.currentHealth && healthPlayer.currentHealth <= 7)
        {
            two.SetActive(true);
        }
        else if (1 <= healthPlayer.currentHealth && healthPlayer.currentHealth <= 4)
        {
            one.SetActive(true);
        }
    }


}

