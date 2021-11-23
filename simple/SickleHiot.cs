using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickleHiot : MonoBehaviour
{
    [Header("时间控制参数")]
    public float activeTime;//显示时间
    public float activeStart;//开始显示的时间
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
