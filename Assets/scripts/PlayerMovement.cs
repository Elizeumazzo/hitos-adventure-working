using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D Rb;
    public Animator anim;
    public ParticleSystem dust;
    Vector2 movement;
    public GameObject camera;

     // Update is called once per frame
    void Update()
    {

        /*anim.SetFloat("horizontal", movement.x);
        anim.SetFloat("vertical", movement.y);
        anim.SetFloat("speed", movement.sqrMagnitude);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");*/


        /*if (Input.GetAxisRaw("Horizontal") > -1 || Input.GetAxisRaw("Horizontal") < 1 || Input.GetAxisRaw("Vertical") > -1 || Input.GetAxisRaw("Vertical") < 1)
        {
            CreateDust();
        }*/


        DoMove();
        if (Rb.velocity.y > 0.1 || Rb.velocity.x > 0.1)
        {
            //CreateDust();
        }

    }


    void FixedUpdate()
    {
        Rb.MovePosition(Rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (movement.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 0.5f);
        }
        else if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 0.5f);
        }

    }


    void DoMove()
    {
        anim.SetFloat("horizontal", movement.x);
        anim.SetFloat("vertical", movement.y);

        anim.SetFloat("speed", movement.sqrMagnitude);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(Input.GetAxisRaw("Horizontal")==1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            anim.SetFloat("lasthorizontal", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("lastvertical", Input.GetAxisRaw("Vertical"));

        }


        //CreateDust();
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "door2")
        {
            print("hit door");
            transform.position = transform.position + new Vector3(1, 7, 0);

            camera.transform.position = new Vector3(0, 0, -10);
        }





        //print("player has hit " + col.gameObject.tag);
        if( col.gameObject.tag == "door")
        {
            print("hit door");
            transform.position = transform.position + new Vector3(0, -7, 0);

            camera.transform.position = new Vector3(-5, -12, -10);
        }
    }





    /*void CreateDust()
    {
        dust.Play();
    }*/



}
