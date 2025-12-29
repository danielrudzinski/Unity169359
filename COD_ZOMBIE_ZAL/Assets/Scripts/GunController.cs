using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("Co strzela")]
    public GameObject bulletPrefab;
    public Transform muzzlePoint;

    [Header("Ustawienia")]
    public float bulletSpeed = 40f;
    public float fireRate = 0.2f;

    [Header("Sklep i Statystyki")]
    public int damage = 1;          
    public int upgradeCost = 500;   

    [Header("Dźwięk")]
    public AudioSource gunAudio;
    public AudioClip shootSound;

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            BuyUpgrade();
        }
    }

    void Shoot()
    {
        GameObject currentBullet = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
        
        BulletDamage bulletScript = currentBullet.GetComponent<BulletDamage>();
        if (bulletScript != null)
        {
            bulletScript.damageAmount = this.damage; 
        }

        Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
        if(rb != null) rb.linearVelocity = muzzlePoint.forward * bulletSpeed; 

        Destroy(currentBullet, 3f);

        if (gunAudio != null && shootSound != null)
        {
            gunAudio.PlayOneShot(shootSound);
        }
    }

    void BuyUpgrade()
    {
        WaveManager gm = FindObjectOfType<WaveManager>();
        
        if (gm != null)
        {
            if (gm.money >= upgradeCost)
            {
                gm.money -= upgradeCost; 
                gm.AddMoney(0); 
                
                damage += 1;
                upgradeCost += 200; 
            }
        }
    }
}