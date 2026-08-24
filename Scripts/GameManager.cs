using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int maxHealth;
    public int MaxHealth { get { return maxHealth; } }
    public int currentHealth;
    public int CurrentHealth { get { return currentHealth; } }

    private void Awake()
    {
        Instance = this;
        maxHealth = 5;
        currentHealth = 0;
    }

    //改变生命值
    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
