using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickleHiot : MonoBehaviour
{
    [Header("ʱ����Ʋ���")]
    public float activeTime;//��ʾʱ��
    public float activeStart;//��ʼ��ʾ��ʱ��
    public GameObject sickle;
    void Start()
    {
        
    }


    
    void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.U))
            {
                Shoot();
            }
       
       
    }
    void Shoot()
    {
       
            Instantiate(sickle, transform.position, transform.rotation);
      
       
    }
}
