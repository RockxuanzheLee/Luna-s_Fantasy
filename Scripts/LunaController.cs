using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunaController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public float moveSpeed = 3f;
    public int maxHealth;
    public int MaxHealth { get { return maxHealth; } }
    public int currentHealth;
    public int CurrentHealth { get { return currentHealth; } }

    // Start is called before the first frame update
    void Start()
    {
        //帧率控制：90帧
        Application.targetFrameRate = 90;
        rigidbody2d = GetComponent<Rigidbody2D>();
        maxHealth = 5;
        currentHealth = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //获取玩家输入
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 position = transform.position;
        
        //调整Luna的位置
        position.x = position.x + moveSpeed * horizontal * Time.deltaTime;
        position.y = position.y + moveSpeed * vertical * Time.deltaTime;
        
        rigidbody2d.MovePosition(position);
  
    }

    //改变生命值
    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth+"/"+maxHealth);
    }
}