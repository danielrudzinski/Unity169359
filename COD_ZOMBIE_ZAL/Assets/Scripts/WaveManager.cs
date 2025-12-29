using UnityEngine;
using System.Collections;
using TMPro; 

public class WaveManager : MonoBehaviour
{
    public GameObject zombiePrefab;      
    public Transform[] spawnPoints;      
    public float timeBetweenWaves = 3f;  
    public TextMeshProUGUI waveText;     
    public TextMeshProUGUI moneyText;    
    public int money = 0;                

    private int currentWave = 1;
    private int zombiesToSpawn = 3;      
    private bool spawning = false;

    void Start()
    {
        UpdateMoneyUI();

        if(waveText != null) waveText.text = "FALA: " + currentWave;

        StartCoroutine(StartWave());
    }

    void Update()
    {
        if (!spawning)
        {
            int enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (enemiesAlive == 0)
            {
                StartNextWave();
            }
        }
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyUI();
    }

    void UpdateMoneyUI()
    {
        if(moneyText != null) moneyText.text = "$: " + money;
    }

    void StartNextWave()
    {
        spawning = true;
        currentWave++;
        zombiesToSpawn += 2; 
        
        if(waveText != null) waveText.text = "FALA: " + currentWave;

        StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        spawning = true;
        yield return new WaitForSeconds(timeBetweenWaves);

        for (int i = 0; i < zombiesToSpawn; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f); 
        }

        spawning = false;
    }

    void SpawnEnemy()
    {
  
        if (spawnPoints.Length == 0) return;

        int rand = Random.Range(0, spawnPoints.Length);
        
        GameObject newZombie = Instantiate(zombiePrefab, spawnPoints[rand].position, Quaternion.identity);

        EnemyHealth zombieHpScript = newZombie.GetComponent<EnemyHealth>();
        
        if (zombieHpScript != null)
        {
            zombieHpScript.hp += (currentWave * 2); 
        }
    }
}