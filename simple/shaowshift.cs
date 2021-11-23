using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaowshift : MonoBehaviour
{
    private Transform player;

    private SpriteRenderer thisSprite;
    private SpriteRenderer playerSprite;
    private Color color;

    [Header("ʱ����Ʋ���")]
    public float activeTime;//��ʾʱ��
    public float activeStart;//��ʼ��ʾ��ʱ��

    [Header("��͸���ȿ���")]
    private float alpha;
    public float alphaSet;//��ʼֵ
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
            //���ض����
        }
    }
    
}
