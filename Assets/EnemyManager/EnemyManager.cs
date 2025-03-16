using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyManager : MonoBehaviour
{
    [SerializeField] public float maxHealth = 2f;
    [SerializeField] public float currentHealth;
    private Animator anim;
    private string currentAnim;
    [SerializeField] ParticleSystem hitEffect;
    AudioPlayer audioPlayer;

    public virtual void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        audioPlayer = FindAnyObjectByType<AudioPlayer>();
    }
    public virtual void Update()
    {

    }

    public virtual void takeDamage(int amount)
    {
        PlayHitEffect();
        currentHealth -= amount;
        if (currentHealth <= 0)
            Die();

    }
    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
    public virtual void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            audioPlayer.PlayDamageClip();
        }
    }
    public void changeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            currentAnim = animName;
            anim.ResetTrigger(animName);
            anim.SetTrigger(currentAnim);
        }
    }
}
