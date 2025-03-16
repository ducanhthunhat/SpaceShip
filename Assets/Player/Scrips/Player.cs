using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public GameObject bulletPrefab;
    public Transform PointShooting;
    public float startShoot = 0;
    public float nextShoot = 1f;
    AudioPlayer audioPlayer;
    private void Awake()
    {
        audioPlayer = FindAnyObjectByType<AudioPlayer>();
    }

    void Update()
    {
        // Cursor.visible = false;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;

        transform.position = Vector3.Lerp(transform.position, worldPosition, speed * Time.deltaTime);
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
            audioPlayer.PlayShootingClip();
        }
    }
}
