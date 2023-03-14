using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    // add the ability for the player to dash
    public float dashSpeed = 10.0f;
    public float dashTime = 0.5f;
    public float dashCooldown = 1.0f;
    public float dashCooldownTimer = 0.0f;
    public bool isDashing = false;

    public Animator anim;

    public Rigidbody2D rb;
    public Weapon weapon;

    Vector2 moveDirection;
    Vector2 mousePosition;

    public float health, maxHealth = 100f;

    private void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            weapon.Reload();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dashCooldownTimer <= 0)
            {
                isDashing = true;
                dashCooldownTimer = dashCooldown;
            }
        }

        if (isDashing)
        {
            if (dashTime >= 0)
            {
                dashTime -= Time.deltaTime;
                moveSpeed = dashSpeed;
            }
            else
            {
                dashTime = 0.5f;
                moveSpeed = 5.0f;
                isDashing = false;
            }
        }
        else
        {
            dashCooldownTimer -= Time.deltaTime;
        }



        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Make sure player health doesn't go above max health
        if (health > maxHealth)
        {
            health = maxHealth;
        }


    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;



    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Animation Setup if player is Idle or Running
    private void LateUpdate()
    {
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            anim.SetBool("isRunning?", true);
        }
        else
        {
            anim.SetBool("isRunning?", false);
        }
    }



}
