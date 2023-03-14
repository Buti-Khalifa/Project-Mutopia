using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public PlayerController player;
    public TextMeshProUGUI text;

    void Start()
    {
        UpdateHealthText();
    }

    void Update()
    {
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        text.text = $"Health: {player.health}";
    }

}
