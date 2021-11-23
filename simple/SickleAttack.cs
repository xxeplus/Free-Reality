using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickleAttack : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    private Rigidbody2D rb;
    public float tuning;
    private Transform playerTransform;
    private Transform sickleTransform;
    private Vector2 startSpeed;
    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        startSpeed = rb.velocity;
        playerTransform = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        sickleTransform = GetComponent<Transform>();
        
    }

    
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed);
        float y = Mathf.Lerp(transform.position.y, playerTransform.position.y, tuning);
        transform.position = new Vector2(transform.position.x, y);

        rb.velocity = rb.velocity - startSpeed * Time.deltaTime;
        if (Mathf.Abs(transform.position.x - playerTransform.position.x) < 0.5f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        if (other.CompareTag("Enemy"))
        {
            enemy.Jumpon();
        }
    }
}
