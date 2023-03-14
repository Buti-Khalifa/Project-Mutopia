using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoText : MonoBehaviour
{
    public Weapon weapon;
    public TextMeshProUGUI text;

    void Start()
    {
        UpdateAmmoText();
    }

    void Update()
    {
        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        text.text = $"{weapon.currentClip} | {weapon.currentAmmo}";
    }
}
