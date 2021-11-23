using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image healthPointImage;
    public Image healthPointEffect;

    private nex player;
    [SerializeField] private float hurtSpeed = 0.003f;//ÑªÌõ»º³åÐ§¹û

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<nex>();
    }

    private void Update()
    {
        healthPointImage.fillAmount = player.currentHp / player.maxHp;

        if (healthPointEffect.fillAmount >= healthPointImage.fillAmount)
        {
            healthPointEffect.fillAmount -= hurtSpeed;
        }
        else
        {
            healthPointEffect.fillAmount = healthPointImage.fillAmount;
        }
    }

}
