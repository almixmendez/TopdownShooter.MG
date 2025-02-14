using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    //private Vector3 mousePos;
    //private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public float damage = 1f;
    public float speed = 5f;

    void Start()
    {
        //mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
        rb = GetComponent<Rigidbody2D>();

        ////mousePos = mainCam.ScreenToWorldPoint(/*Input.mousePosition*/ new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCam.transform.position.z - transform.position.z));
        //Vector3 direction = mousePos - transform.position;
        //direction.z = 0f;
        ////Vector3 rotation = transform.position - mousePos;
        //rb.velocity = direction.normalized * force; /*new Vector2(direction.x, direction.y).normalized * force;*/
        //float rot = Mathf.Atan2(direction.y, direction.x)/*rotation.y, rotation.x)*/ * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, rot /*+ 90*/);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        rb.AddForce(Vector2.right * force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyControl enemyComponent = collision.gameObject.GetComponent<EnemyControl>();

        if (enemyComponent != null)
        {
            enemyComponent.TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }
}
