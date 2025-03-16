using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Boss1;
    private int totalPointEnergy;
    [SerializeField] GameObject enemySpawner;
    [SerializeField] Image energyBar;
    [SerializeField] int Energy = 20;
    [SerializeField] GameObject EnergyBar;
    [SerializeField] GameObject HpEnemy;
    private void Start()
    {
        totalPointEnergy = 0;
        UpdateEnergy();
        HpEnemy.SetActive(false);
    }

    public void AddEnergyPoint()
    {
        totalPointEnergy += 1;
        UpdateEnergy();
        if (totalPointEnergy == Energy)
        {
            callBoss();
        }
    }

    public void callBoss()
    {
        if (Boss1 != null)
        {
            Boss1.SetActive(true);
            EnergyBar.SetActive(false);
            Debug.Log("Boss summoned!");
            enemySpawner.SetActive(false);
            HpEnemy.SetActive(true);
        }
    }


    public void UpdateEnergy()
    {
        energyBar.fillAmount = (float)totalPointEnergy / Energy;
    }
}
