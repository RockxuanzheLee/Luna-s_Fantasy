using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using 

public class JumpArea : MonoBehaviour
{
    public Transform jumpPointA;
    public Transform jumpPointB;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Luna"))
        {
            LunaController lunaController = collision.transform.GetComponent<LunaController>();
            lunaController.Jump(true);
        }
    }
}
