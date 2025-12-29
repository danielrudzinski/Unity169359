using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damageAmount = 1;
    public GameObject bloodPrefab;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (bloodPrefab != null)
            {
                ContactPoint contact = collision.contacts[0];
                GameObject blood = Instantiate(bloodPrefab, contact.point, Quaternion.LookRotation(contact.normal));
                Destroy(blood, 1f); 
            }

            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount);
            }
        }

        Destroy(gameObject);
    }
}