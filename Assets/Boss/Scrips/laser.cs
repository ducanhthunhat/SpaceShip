using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private HealthPlayer healthPlayer;
    [SerializeField] public Vector2 laserRadius = new Vector2(1f, 1f);
    [SerializeField] private LayerMask playerLayer;
    private Boss1 boss1;

    private void Awake()
    {
        boss1 = FindObjectOfType<Boss1>();
        if (boss1 == null)
        {
            Debug.LogError("Boss1 not found!");
        }
        healthPlayer = FindAnyObjectByType<HealthPlayer>();
    }

    public void LaserDamage()
    {
        if (boss1 == null || boss1.laserPoint == null) return;

        bool checkPlayer = Physics2D.OverlapBox(boss1.laserPoint.position, laserRadius, 0f, playerLayer);
        if (checkPlayer)
        {
            healthPlayer.takeDamage(1);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (boss1 == null || boss1.laserPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boss1.laserPoint.position, laserRadius);
    }
}
