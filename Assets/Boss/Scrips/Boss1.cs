using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefabs;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float skillCoolDown = 2f;
    [SerializeField] private float nextSkillTime = 0f;
    [SerializeField] GameObject laserPrefabs;
    [SerializeField] public Transform laserPoint;
    AudioPlayer audioPlayer;

    private int skill = 0;
    [SerializeField] private float secondsWaitTime;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    private void Update()
    {
        useSkill();
    }

    private void circle_shooting()
    {
        Debug.Log("skill");
        const int bulletCount = 16;
        float angleStep = 360f / bulletCount;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * angleStep;
            Vector3 bulletDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0);
            GameObject bullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
            BossBullet enemyBullet = bullet.AddComponent<BossBullet>();
            enemyBullet.SetMovementDirections(bulletDirection * 6);
        }
    }


    public void Laser()
    {
        Instantiate(laserPrefabs, laserPoint.position, Quaternion.identity);
        StartCoroutine(wait_for_warning());
    }

    IEnumerator waitSkill()
    {
        for (int i = 0; i <= 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            circle_shooting();
        }

    }

    private void useSkill()
    {
        nextSkillTime += Time.deltaTime;
        if (nextSkillTime < skillCoolDown) return;
        nextSkillTime = 0;
        skillList();
    }

    private void skillList()
    {
        skill = (skill + 1) % 2;
        switch (skill)
        {
            case 0:
                circle_shooting();
                StartCoroutine(waitSkill());
                break;
            case 1:
                Laser();
                break;
        }
    }

    IEnumerator wait_for_warning()
    {
        yield return new WaitForSeconds(secondsWaitTime);
        audioPlayer.PlayLaserClip();
    }
}
