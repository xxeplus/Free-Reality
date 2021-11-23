using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     protected Animator Anim;
    protected AudioSource deathAudio;
    protected virtual void Start()
    {
        Anim = GetComponent<Animator>();
        deathAudio = GetComponent<AudioSource>();
        
    }
    public void dead()
    {
        
        Destroy(gameObject);
    }
    public void Jumpon()
    {
        deathAudio.Play();
   
    Anim.SetTrigger("death");
    }
   

}
