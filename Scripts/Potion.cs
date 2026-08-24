using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public GameObject effectGo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.CurrentHealth < GameManager.Instance.MaxHealth)
        {
            GameManager.Instance.ChangeHealth(1);
            Instantiate(effectGo, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}

