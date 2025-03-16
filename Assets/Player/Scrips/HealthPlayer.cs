using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthPlayer : MonoBehaviour
{
    private float maxHealth = 10;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] public float currentHealth;
    AudioPlayer audioPlayer;
    LevelManager levelManager;
    public TextMeshProUGUI healthText;
    public bool canShake = true;

    private void Awake()
    {
        audioPlayer = FindAnyObjectByType<AudioPlayer>();
        levelManager = FindObjectOfType<LevelManager>();

    }

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }
    public void takeDamage(float amount)
    {
        currentHealth -= amount;
        UpdateHealthUI();
        PlayHitEffect();
        audioPlayer.PlayDamageClip();
        if (canShake)
        {
            CameraShake cameraShake = Camera.main.GetComponent<CameraShake>();
            if (cameraShake != null)
            {
                StartCoroutine(cameraShake.Shake(0.2f, 0.2f));
            }
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
    public void Die()
    {
        Destroy(gameObject);
        levelManager.loadGameOver();
    }

    public void UpdateHealthUI()
    {
        healthText.text = currentHealth.ToString();
    }

}
