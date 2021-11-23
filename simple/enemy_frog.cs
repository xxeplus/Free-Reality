using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_frog : Enemy
{
    private Rigidbody2D rb;
   //private Animator Anim;
    public Transform leftpoint,rightpoint;
    public Collider2D coll;
    public LayerMask ground;
    public float Speed,Jumpforce;
    private bool Faceleft = true;
    
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        transform.DetachChildren();
    }

    // Update is called once per frame
    void Update()
    {
       
        SwitchAnim();
    }
    void Movement()             
    {
        if (Faceleft)
        {
            if (coll.IsTouchingLayers(ground))
            {

                Anim.SetBool("jumping", true);
                rb.velocity = new Vector2(-Speed, Jumpforce);
            }
            if (transform.position.x < leftpoint.position.x)                                 
            {
                transform.localScale = new Vector3(-1, 1, 1);
                Faceleft = false;
            }
        
    }
        else
        {
            if (coll.IsTouchingLayers(ground))
            {

                Anim.SetBool("jumping", true);
                rb.velocity = new Vector2(Speed, Jumpforce);
            }
            if (transform.position.x > rightpoint.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                Faceleft = true;
            }
        }
    }

    void SwitchAnim()
    {
        if (Anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0.1)
            {
               Anim.SetBool("falling", true);
                Anim.SetBool("jumping", false);
            }
        }
        if(coll.IsTouchingLayers(ground) && Anim.GetBool("falling")){
            Anim.SetBool("falling", false);
        }
    }
    
}
