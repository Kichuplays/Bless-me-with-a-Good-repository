using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    [Header("Player Stats")]
    public int maxPlayerHealth;
    public int currentPlayerHealth;
    public int maxSP;
    public int currentSP;


    [Header("Secondary Stats")]
    public int attack;
    public int magic;
    public int agility;
    public int defense;


    public bool isDead => currentPlayerHealth <= 0;
    private void Awake()
    {
        currentPlayerHealth = maxPlayerHealth;
        currentSP = maxSP;

    }
    
    public void TakeDamage(int damage)
    {
        currentPlayerHealth = Mathf.Max(0, currentPlayerHealth - damage);

        Debug.Log("PLayer Hit with" + 
            damage);

    }

    public void heal(int amount)
    {
        currentPlayerHealth = Mathf.Min(maxPlayerHealth, currentPlayerHealth + amount);

    }

    public bool UseSp(int amount)
    {
        if (currentSP < amount)
        {
            return false;
        }   
        currentSP -= amount;

        return true;
    }


}
