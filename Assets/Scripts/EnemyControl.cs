using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private float health = 3f;
    [SerializeField] private float maxHealth = 3f;
    [SerializeField] private float speed;
    [SerializeField] private float minDistance;
    [SerializeField] private Transform player;
    [SerializeField] private float damageAmount = 1f;
    [SerializeField] private float attackCooldown = 1f;

    private PlayerHealth playerHealth;
    private bool canAttack = true;

    private void Start()
    {
        health = maxHealth;

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void Update()
    {
        Follow();
    }

    private void Follow()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }
    }

    private void Attack()
    {
        canAttack = true;

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }

        StartCoroutine(AttackCooldown());
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        Debug.Log("Enemy took damage. New health: " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canAttack)
        {
            Debug.Log("Choqué al player");
            Attack();
            Destroy(gameObject);
        }
    }
}
