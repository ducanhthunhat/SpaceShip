using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform PointShooting;
    public float startShoot = 0;
    public float nextShoot = 1f;

    private void Update()
    {
        startShoot += Time.deltaTime;
        WaitTimeShotting();
    }
    void WaitTimeShotting()
    {
        if (startShoot < nextShoot) return;
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, PointShooting.position, Quaternion.identity);
            startShoot = 0;
            Destroy(bullet, 3f);
        }
    }
}
