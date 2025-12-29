using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject pistol; 
    public GameObject rifle; 

    public int rifleCost = 1000;
    public bool hasRifle = false; 

    void Start()
    {
        pistol.SetActive(true);
        rifle.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pistol.SetActive(true);
            rifle.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2) && hasRifle)
        {
            pistol.SetActive(false);
            rifle.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.M) && !hasRifle)
        {
            BuyRifle();
        }
    }

    void BuyRifle()
    {
        WaveManager gm = FindObjectOfType<WaveManager>();
        
        if (gm != null && gm.money >= rifleCost)
        {
            gm.AddMoney(-rifleCost);
            hasRifle = true;
           
            pistol.SetActive(false);
            rifle.SetActive(true);
        }
    }
}