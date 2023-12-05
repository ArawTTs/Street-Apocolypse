using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    //healthbar & health reference
    public int MaxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;

    //animator and movement reference
    public Animator anim;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float stoppingDistance = 2f;

    public GameObject damageArea;
    //private bool canAttack = true;
    //public float attackCooldown = 2.0f;
    private float timer;

    //roaming reference
    public Transform player;

    //scorepoint reference
    killcounter killcounterscript;

    void Start()
    {
        currentHealth = MaxHealth;
        healthBar.setMaxHealth(MaxHealth); 
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        killcounterscript = GameObject.Find("KCO").GetComponent<killcounter>();
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = player.position - transform.position;
            float distance = direction.magnitude;

            // Flipping the enemy based on the player's position
            if (direction.x > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else if (direction.x < 0)
                transform.localScale = new Vector3(-1, 1, 1);

            if (distance > stoppingDistance)
            {
                direction.Normalize();
                Vector2 movement = direction * moveSpeed * Time.deltaTime;
                rb.MovePosition(rb.position + movement);

                // Set the animation for movement
                anim.SetBool("IsWalkng", true);
            }
            else
            {
                // Stop moving when within the stopping distance
                rb.velocity = Vector2.zero;
                 anim.SetBool("IsWalkng", false);

                float area = Vector2.Distance(transform.position, player.transform.position);
                Debug.Log(area);

                if(area < 1)
                {
                    timer += Time.deltaTime;

                    if(timer> 2)
                    {
                        timer = 0;
                        anim.SetTrigger("Attack");
                        damageArea.SetActive(true);
                        StartCoroutine(cooldown());

                    }
                }

            }
        }
        
    }

    public void TakeDamage (int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <=0)
        {
            Die();
            StartCoroutine(DelayedFunction());
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");
        //animation
        anim.SetTrigger("dead");

        //disables collider
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        killcounterscript.AddKill();
    }

    private IEnumerator DelayedFunction()
    {
        Debug.Log("Start Timer");

        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }

    private IEnumerator cooldown()
    {
        //animation
        Debug.Log("cooldown");
        //anim.SetTrigger("Attack");
        yield return new WaitForSeconds(0.2f);
        damageArea.SetActive(false);
        
    }

    /*private IEnumerator ResetAttackCooldown()
    {
        Debug.Log("COOLDOWND");
        yield return new WaitForSeconds(attackCooldown);
        damageArea.SetActive(false);
        canAttack = true; // Reset attack cooldown
    }*/
    
}
