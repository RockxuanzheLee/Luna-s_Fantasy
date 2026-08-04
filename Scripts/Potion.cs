using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public GameObject effectGo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LunaController lunaController = collision.GetComponent<LunaController>();
        if (lunaController != null && lunaController.CurrentHealth < lunaController.MaxHealth)
        {
            lunaController.ChangeHealth(1);
            Instantiate(effectGo, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
