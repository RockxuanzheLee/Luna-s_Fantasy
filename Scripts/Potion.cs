using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public GameObject effectGo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.lunaCurrentHP < GameManager.Instance.lunaHP)
        {
            GameManager.Instance.AddOrDecreaseHP(1);
            Instantiate(effectGo, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}

