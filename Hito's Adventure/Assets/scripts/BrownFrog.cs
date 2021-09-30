using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownFrog : MonoBehaviour
{
    public float speed;
    public float checkradius;
    public float attackradius;

    public bool shouldrotate;
    
    public LayerMask WhatIsPlayer;

    private Transform target;
    private Rigidbody2D Rb;
    private Animator anim;
    Vector2 movement;
    public Vector3 direction;

    private bool isinchaserange;
    private bool isinattackrange;


    void Start()
    {
        Rb.GetComponent<Rigidbody2D>();
        anim.GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {

        anim.SetBool("isrunning", isinchaserange);

        isinchaserange = Physics2D.OverlapCircle(transform.position, checkradius, WhatIsPlayer);
        isinattackrange = Physics2D.OverlapCircle(transform.position, attackradius, WhatIsPlayer);

        direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
        if(shouldrotate)
        {
            anim.SetFloat("x", direction.x);
            anim.SetFloat("y", direction.y);
        }


    }


    private void FixedUpdate()
    {

        if(isinchaserange && !isinattackrange)
        {
            MoveCharacter(movement);
        }
        if(isinattackrange)
        {
            Rb.velocity = Vector2.zero;
        }

        Rb.MovePosition(Rb.position + movement * speed * Time.fixedDeltaTime);

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
        Rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

}
