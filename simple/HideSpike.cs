using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpike : MonoBehaviour
{
    //隐藏地刺效果
    public GameObject hideSpikeBox;
    private Animator anim;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("player"))
        {
            StartCoroutine(SpikeAttack());
        }
    }
    IEnumerator SpikeAttack()
    {
        yield return new WaitForSeconds(time);//暂停协程并提交一个唤醒条件
        anim.SetTrigger("Attack");
        Instantiate(hideSpikeBox,transform.position,Quaternion.identity);
    }
}
