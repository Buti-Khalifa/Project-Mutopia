using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLootPickups : MonoBehaviour
{
    // get the name of the picked up loot and apply an effect to the player.
    string lootName;
    PlayerController playerController;
    Bullet bullet;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        bullet = GetComponent<Bullet>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Loot"))
        {
            lootName = collision.gameObject.name;


            if (lootName == "Health")
            {
                playerController.health += 25;
                Destroy(collision.gameObject);
            }
            else if (lootName == "SpeedBoost")
            {
                // Increase movement speed by 50% for 10 seconds
                playerController.moveSpeed *= 1.5f;
                Destroy(collision.gameObject);

                // Reset movement speed to normal after 10 seconds
                Invoke("ResetSpeed", 10f);
            }
            else if (lootName == "Inf_Dash")
            {
                playerController.dashCooldown = 0;
                Destroy(collision.gameObject);

                // Reset dash cooldown to normal after 10 seconds
                Invoke("ResetDashCooldown", 10f);

            }
            else if (lootName == "Damage_Multi")
            {
                bullet.damage *= 1.5f;
                Destroy(collision.gameObject);

                // Reset damage multiplier to normal after 10 seconds
                Invoke("ResetDamageMultiplier", 10f);
            }



        }


    }

    void ResetSpeed()
    {
        playerController.moveSpeed /= 1.5f;
    }

    void ResetDashCooldown()
    {
        playerController.dashCooldown = 1;
    }

    void ResetDamageMultiplier()
    {
        bullet.damage /= 1.5f;
    }
}
