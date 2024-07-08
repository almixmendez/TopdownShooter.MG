using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float projectileDamage = 1f;
    private Transform playerTransform;
    private Rigidbody2D rb;
    //public string mapWalls = "Wall";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        LaunchProjectile();
    }

    private void LaunchProjectile()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
            Vector2 directionToPlayer = (playerTransform.position - transform.position).normalized;
            rb.velocity = directionToPlayer * speed;
            StartCoroutine(DestroyProjectile());
        }
        else
        {
            Debug.Log("No se encontró un GameObject con la etiqueta 'Player'. El proyectil no se lanzará.");
        }
    }

    IEnumerator DestroyProjectile()
    {
        float destroyTime = 5f;
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(projectileDamage);
            Destroy(gameObject);
        }
        //if (other.CompareTag(mapWalls))
        //{
        //    Destroy(gameObject);
        //}
    }
}
