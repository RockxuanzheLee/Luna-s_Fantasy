using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LunaController lunaController = collision.GetComponent<LunaController>();
        if (lunaController != null && lunaController.CurrentHealth < lunaController.MaxHealth)
        {
            lunaController.ChangeHealth(1);
            Destroy(gameObject);
        }
        
    }
}
