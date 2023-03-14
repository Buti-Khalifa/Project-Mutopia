using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCooldown : MonoBehaviour
{
    PlayerController player;
    public Image dashCooldownImage;

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        UpdateDashCooldown();
    }

    void Update()
    {
        UpdateDashCooldown();
    }

    void UpdateDashCooldown()
    {
        dashCooldownImage.fillAmount = player.dashCooldownTimer / player.dashCooldown;
    }



}


