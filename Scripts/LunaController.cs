using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunaController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public float moveSpeed = 2f;
    public int maxHealth;
    public int MaxHealth { get { return maxHealth; } }
    public int currentHealth;
    public int CurrentHealth { get { return currentHealth; } }
    private Animator animator;
    private Vector2 lookDirection = new Vector2(1, 0);
    private float moveScale;
    private Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        //帧率控制：90帧
        Application.targetFrameRate = 165;

        rigidbody2d = GetComponent<Rigidbody2D>();
        maxHealth = 5;
        currentHealth = 0;
        animator = GetComponentInChildren<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //玩家输入监听
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        move = new Vector2(horizontal, vertical); 

        //设置动画参数
        if (!Mathf.Approximately(move.x,0)||!Mathf.Approximately(move.y,0))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        
        //设置移动状态
        moveScale = move.magnitude;
        if (move.magnitude > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveScale = 1;
                moveSpeed = 2f;
            }
            else
            {
                moveScale = 2;
                moveSpeed = 3.5f;
            }
        }
        animator.SetFloat("MoveValue", moveScale);
    }

    private void FixedUpdate()
    {
        //移动角色
        Vector2 position = rigidbody2d.position;
        position = position + move * moveSpeed * Time.fixedDeltaTime;
        rigidbody2d.MovePosition(position);
    }

    //改变生命值
    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth+"/"+maxHealth);
    }
}