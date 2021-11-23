using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpike : MonoBehaviour
{
    //���صش�Ч��
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
        yield return new WaitForSeconds(time);//��ͣЭ�̲��ύһ����������
        anim.SetTrigger("Attack");
        Instantiate(hideSpikeBox,transform.position,Quaternion.identity);
    }
}
