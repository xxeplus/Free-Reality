using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpikeBox : MonoBehaviour
{
    public int damage;
    public float destroyTime;

    private nex currentHp;
    void Start()
    {
        currentHp = GameObject.FindGameObjectWithTag("player").GetComponent<nex>();
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player") )
        {
            currentHp.DamagePlayer(damage);
        }
    }
}
