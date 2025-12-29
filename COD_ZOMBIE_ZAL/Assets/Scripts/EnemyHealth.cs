using UnityEngine;
using UnityEngine.AI; 

public class EnemyHealth : MonoBehaviour
{
    public int hp = 3;
    private Animator anim; 

    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        WaveManager gm = FindObjectOfType<WaveManager>();
        if (gm != null)
        {
            gm.AddMoney(50);
        }


        if(anim != null) anim.SetTrigger("Die");

        var navAgent = GetComponent<NavMeshAgent>();
        if (navAgent != null) navAgent.enabled = false;

        GetComponent<Collider>().enabled = false;

        GetComponent<ZombieDamage>().enabled = false;

        this.enabled = false;

        Destroy(gameObject, 5f);
    }
}