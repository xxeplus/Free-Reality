using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaowshift : MonoBehaviour
{
    private Transform player;

    private SpriteRenderer thisSprite;
    private SpriteRenderer playerSprite;
    private Color color;

    [Header("时间控制参数")]
    public float activeTime;//显示时间
    public float activeStart;//开始显示的时间

    [Header("不透明度控制")]
    private float alpha;
    public float alphaSet;//初始值
    public float alphaMultiplider;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        thisSprite = GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();
        alpha = alphaSet;
        thisSprite.sprite = playerSprite.sprite;
        transform.position = player.position;
        transform.localScale = player.localScale;
        transform.rotation = player.rotation;
        activeStart = Time.time;
    }
    void Update()
    {
        alpha *= alphaMultiplider; 

        color = new Color(0.5f, 0.5f, 1, alpha);

        thisSprite.color = color;
        if (Time.time >= activeStart + activeTime)
        {
            Shadowpool.instance.ReturnPool(this.gameObject);
            //返回对象池
        }
    }
    
}
