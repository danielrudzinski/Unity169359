using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public string playerName = "Player";
    public int health = 1000;
    public int strength = 100;

    public void ResetStats()
    {
        health = 100;
        strength = 10;
        Debug.Log("Stats to default");
    }
}