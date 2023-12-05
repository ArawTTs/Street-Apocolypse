using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playermovement : MonoBehaviour
{
    //animation and movement refrence
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Animator anim;
    
    //attack reference
    public LayerMask enemyLayers;
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public int attackDamage = 10;

    //health reference
    public HealthBar healthBar;
    public int MaxHealth = 100;
    public int currentHealth;

    //notdamagable reference

    //retry reference
    public GameObject retry;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = MaxHealth;
        healthBar.setMaxHealth(MaxHealth);
    }

    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
        { 
            if(Input.GetAxisRaw("Horizontal") > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else
                transform.localScale = new Vector3(-1, 1, 1);
        }

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;

        
        rb.MovePosition(rb.position + movement);

        anim.SetBool("IsMoving", Mathf.Abs(horizontalInput) > 0f || Mathf.Abs(verticalInput) > 0);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(attackDamage);
        }
    }

    void Attack()
    {
        //animation
        anim.SetTrigger("IsAttacking");

        //attackRange
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, enemyLayers);

        foreach(Collider2D Enemy in hitEnemies)
        {
            if(Enemy.GetComponent<enemy>())
            Enemy.GetComponent<enemy>().TakeDamage(attackDamage);

            if(Enemy.GetComponent<bomb>())
            Enemy.GetComponent<bomb>().TakeDamage(attackDamage);

             if(Enemy.GetComponent<zomage>())
            Enemy.GetComponent<zomage>().TakeDamage(attackDamage);

            if(Enemy.GetComponent<slime>())
            Enemy.GetComponent<slime>().TakeDamage(attackDamage);

            if(Enemy.GetComponent<Lily>())
            Enemy.GetComponent<Lily>().TakeDamage(attackDamage);
        }

    }

    void OnDrawGizmosSelected() 
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }

    public void TakeDamage (int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <=0)
        {
            Die();
            retry.SetActive(true);
            StartCoroutine(DelayedFunction());
        }
    }

    void Die()
    {
        Debug.Log("Player died");
        //animation
        anim.SetTrigger("IsDead");

        //disable Collider
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        //DestroyCollider
        StartCoroutine(DelayedFunction());
    }

    private IEnumerator DelayedFunction()
    {
        Debug.Log("Start Timer");

        yield return new WaitForSeconds(1.0f);
        //object is destroy
        Destroy(gameObject);
    }

}
