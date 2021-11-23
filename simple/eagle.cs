using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagle : Enemy
{

    private Rigidbody2D rb;
    //private Animator Anim;
    public Transform uppoint, downpoint;
    public Collider2D coll;

    public float Speed;
    private bool isUp = true;
   
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
        Movement();
    }
void Movement()
{
    if (isUp)
    {
        rb.velocity = new Vector2(rb.position.x, Speed);
        if(rb.position.y> uppoint.position.y)
        {
            isUp = false;
        }
    }
    else
    {
        rb.velocity = new Vector2(rb.position.x, -Speed);
        if (rb.position.y < downpoint.position.y)
        {
            isUp = true;
        }
    }
}
}
