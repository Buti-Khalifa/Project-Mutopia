using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public Weapon weapon;
    public int ammoAmount = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            weapon.currentAmmo += ammoAmount;
            Destroy(gameObject);
        }
    }


}
