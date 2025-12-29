using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 40;
    public int currentHealth;
    public TextMeshProUGUI hpText; 

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            BuyHealth();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateUI();

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void BuyHealth()
    {
        WaveManager gm = FindObjectOfType<WaveManager>();
        int cost = 100;

        if (gm != null && gm.money >= cost && currentHealth < maxHealth)
        {
            gm.AddMoney(-cost); 
            currentHealth = maxHealth; 
            UpdateUI();
            Debug.Log("Kupiłeś życie! Stan konta: " + gm.money);
        }
        else
        {
            Debug.Log("Nie można kupić życia (Brak kasy lub jesteś zdrowy)");
        }
    }

    void UpdateUI()
    {
        if(hpText != null) hpText.text = "HP: " + currentHealth;
    }
}