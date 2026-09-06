using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool vertical;
    public float speed = 4.0f;
    private int direction = 1;
    public float changeTime = 3.0f;
    private float timer;
    private Rigidbody2D rigidbody2d;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction *= -1;
            timer = changeTime;
        }
    }

    private void FixedUpdate()
    {
        Vector3 pos = rigidbody2d.position;
        if (vertical)
        {
            pos.y = pos.y + Time.fixedDeltaTime * speed * direction;
            animator.SetFloat("LookX", 0);
            animator.SetFloat("LookY", direction);
        }
        else
        {
            pos.x = pos.x + Time.fixedDeltaTime * speed * direction;
            animator.SetFloat("LookX", direction);
            animator.SetFloat("LookY", 0);
        }
        rigidbody2d.MovePosition(pos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Luna"))
        {
            GameManager.Instance.EnterOrExitBattle(true);
            UIManager.Instance.ShowOrHideBattlePanel(true);
        }
    }
}
