using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : EnemyManager
{
    private GameManager gameManager;

    public override void Start()
    {
        base.Start();
        gameManager = FindObjectOfType<GameManager>();
    }

    public override void takeDamage(int amount)
    {
        changeAnim("takeDamage");
        Invoke("changeIdle", 0.5f);
        base.takeDamage(amount);
    }

    void changeIdle()
    {
        changeAnim("basic");
    }

    public override void Die()
    {
        base.Die();
        if (gameManager != null)
        {
            gameManager.AddEnergyPoint();
        }
    }
}
