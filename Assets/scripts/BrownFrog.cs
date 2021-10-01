using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float speed;
    public float checkradius;
    public float attackradius;

    public bool shouldrotate;
    
    public LayerMask WhatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    Vector2 movement;
    public Vector3 direction;

    private bool isinchaserange;
    private bool isinattackrange;


    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;

        print(target);
        
    }

    void Update()
    {



        isinchaserange = Physics2D.OverlapCircle(transform.position, checkradius, WhatIsPlayer);
        isinattackrange = Physics2D.OverlapCircle(transform.position, attackradius, WhatIsPlayer);

        direction = target.position - transform.position;



        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
        if (shouldrotate)
        {
            anim.SetFloat("x", direction.x);
            anim.SetFloat("y", direction.y);
        }

        if (isinchaserange && !isinattackrange)
        {
            MoveCharacter(movement);
        }

        if (isinattackrange)
        {
            rb.velocity = Vector2.zero;
        }


        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        if (movement.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 0.5f);
        }
        else if (movement.x < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 0.5f);
        }
    }


   


    private void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

}
