using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public Animator animator;
    public float speed;

    [Header("Attack")]
    private float attackTime;
    [SerializeField] float timeBetweenAttack;
    private bool canMove;
    [SerializeField] Transform checkEnemy;
    public LayerMask WhatIsEnemy;
    public float range;

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        transform.position = transform.position + movement * Time.deltaTime * speed;

        Attack();

        if (Input.GetAxis("Horizontal") > 0.1)
        {
            checkEnemy.position = new Vector3(transform.position.x + range, transform.position.y, 0);
        }
        else if (Input.GetAxis("Horizontal") < -0.1)
        {
            checkEnemy.position = new Vector3(transform.position.x - range, transform.position.y, 0);
        }
        if (Input.GetAxis("Vertical") > 0.1)
        {
            checkEnemy.position = new Vector3(transform.position.x + range, transform.position.y + 1, 0);
        }
        else if (Input.GetAxis("Vertical") < -0.1)
        {
            checkEnemy.position = new Vector3(transform.position.x - range, transform.position.y - 1, 0);
        }

    }
    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= attackTime)
            {
                rb.velocity = Vector2.zero;
                animator.SetTrigger("attack");

                StartCoroutine(Delay());

                IEnumerator Delay()
                {
                    canMove = false;
                    yield return new WaitForSeconds(.5f);
                    canMove = true;
                }

                attackTime = Time.time + timeBetweenAttack;
            }
        }
    }
    private void FixedUpdate()
    {
        if(canMove)
        Move();
    }
    void Move()
    {
   
    }

    public void OnAttack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(checkEnemy.position, 0.5f, WhatIsEnemy);

        foreach (var enemy_ in enemy)
        {
            // dégat 
        }
    }
}
