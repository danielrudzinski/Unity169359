using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    public int damage = 1;
    public float attackRate = 3.0f; 
    private float nextAttackTime = 0;

    public AudioClip attackSound;   
    private AudioSource audioSource;
    private Animator anim; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>(); 
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && Time.time >= nextAttackTime)
        {
            PlayerHealth playerHP = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHP != null)
            {
                if(anim != null) anim.SetTrigger("Attack");

                playerHP.TakeDamage(damage);
                nextAttackTime = Time.time + attackRate;

                if (audioSource != null && attackSound != null)
                {
                    audioSource.PlayOneShot(attackSound);
                }
            }
        }
    }
}