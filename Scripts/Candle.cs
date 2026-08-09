using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    public GameObject effectGo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(effectGo, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
