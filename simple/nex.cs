using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nex : MonoBehaviour
{
    private float destroyTime = 0.5f;
    [Header("血条显示值")]
    public float maxHp = 100.0f;
    public float currentHp = 10.0f;

   [Header("杂项")]
    public Rigidbody2D rb;
    private Animator anim;
    public Collider2D coll;
    public Collider2D discoll;
    private float speed = 6;
    private float jumpforce = 6;
    public LayerMask ground;
    private int Cherry = 0;
    private int Gem = 0;
    public Text CherryNum ;
    public Transform Cellingcheck,Groundcheck;
    public AudioSource jumpAudio,collectionAudio;
    private bool isHurt;//默认是false
    private bool isGround,isDashing;
    bool jumpPressed,isJump;
    int jumpCount;
    [Header("CD的UI组件")]
    public Image cdImage;


    [Header("Dash参数")]
    public float dashTime;//dash时长
    private float dashTimeLeft;//dash剩余时长
    private float lastDash = -10f;//上一次dash时间点；
    public float dashCoolDown;
    private float horizontalMove;
    public float dashSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


    }
   

    private void Awake()//人物的血条
    {
        currentHp = maxHp;
    }
    private void Update()
    {
        
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.J))//按键
        {
            if (Time.time >= (lastDash + dashCoolDown))
            {
                ReadyToDash();
                //可以执行Dash
            }
        }
        cdImage.fillAmount -= 1.0f / dashCoolDown * Time.deltaTime;//CD冷却效果的实现
    }
        
   
   
    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(Groundcheck.position, 0.1f, ground);
       
        if (!isHurt)
        {
            GroundMovement();
        }
        Jump();
        SwitchAnim();
        Crouch();
        Dash();
        Die();
    }
 
    void GroundMovement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);

        }
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce * Time.fixedDeltaTime);
           
            anim.SetBool("jumping", true);
          

        }
    }//人物的移动效果实现
    
        void Jump()//究极手感优化 二段跳
    {
        if (isGround)
        {
            jumpCount = 2;
            isJump = false;
        }
        if(jumpPressed && isGround)
        {
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.y, jumpforce);
            jumpCount--;
            jumpPressed = false;
            jumpAudio.Play();
        }
        else if(jumpPressed && jumpCount>0 && !isGround)
        {
            rb.velocity = new Vector2(rb.velocity.y, jumpforce);
            jumpCount--;
            jumpPressed = false;
            jumpAudio.Play();
        }
    }
    
    void SwitchAnim()//选择动画
    {
        anim.SetFloat("running", Mathf.Abs(rb.velocity.x));
        if (isGround)
        {
            anim.SetBool("falling", false);
        }
        else if(!isGround && rb.velocity.y > 0)
        {
            anim.SetBool("jumping", true);
        }
        else if (rb.velocity.y < 0)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
        }

        anim.SetBool("idle", false);
        if (anim.GetBool("jumping")) 
        {
            if(rb.velocity.y<0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }else if (isHurt)
        {
            anim.SetBool("hurting", true);

           
            
           

            if (Mathf.Abs(rb.velocity.x) < 0.1f)
            {
                anim.SetBool("hurting", false);
                anim.SetBool("idle", true);
                isHurt = false;
            }
        }
        else if (coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetBool("battling", true);
           
        }

    }
    
    
        
    
    //收集物品
    private void OnTriggerEnter2D(Collider2D collision)
    {

      


        if (collision.tag == "Collection")
        {
            Destroy(collision.gameObject);
            Cherry ++;
            collectionAudio.Play();
            CherryNum.text = Cherry.ToString();
            
        }
        if (collision.tag == "Deadline")
        {
            GetComponent<AudioSource>().enabled = false;
            Invoke("Restart", 2f);//执行游戏重启
        }
    }
    //消灭敌人
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Enemy")
        {
            
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (anim.GetBool("falling"))
            {
                rb.velocity = new Vector2(rb.velocity.x, 5);
                anim.SetBool("jumping", true);
                enemy.Jumpon();
                


            }
            else if (transform.position.x<collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-3, rb.velocity.y); 
                isHurt = true;
                Debug.Log("I have hitted" + collision);
                currentHp -= 15.0f;
                Debug.Log("Current Hp is " + currentHp);
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(3, rb.velocity.y);
                isHurt = true;
                Debug.Log("I have hitted" + collision);
                currentHp -= 15.0f;
                Debug.Log("Current Hp is " + currentHp);
            }
        }
    }
    //爬行动画
    void Crouch()
    {
        if(!Physics2D.OverlapCircle(Cellingcheck.position, 0.2f, ground))
        {

       

        if (Input.GetButton("Crouch"))
            {
                anim.SetBool("crouching", true);
                discoll.enabled = false;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                anim.SetBool("crouching", false);
                discoll.enabled = true;
            }


    }

}
    void Restart()//游戏重启：胜败乃兵家常事，大侠请重新来过
    {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }

    void ReadyToDash()//冲锋残影
    {
        isDashing = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;
        cdImage.fillAmount = 1;
    }
    void Dash()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                rb.velocity = new Vector2(dashSpeed * horizontalMove, rb.velocity.y);
                dashTimeLeft -= Time.deltaTime;
                Shadowpool.instance.GetFormPool();
            }
            if (dashTimeLeft <= 0)
            {
                isDashing = false;
            }
        }
        
    }
    
   void Die()
    {
        if (currentHp <= 0)
        {
            GetComponent<AudioSource>().enabled = false;
            Invoke("Restart", 2f);
        }
    }

    public void DamagePlayer(int damage)
    {
        currentHp -= damage;
    } 
}
