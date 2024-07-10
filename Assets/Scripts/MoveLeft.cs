using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    public float screenRange = -10;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < screenRange) // Fijate qué num entra mejor en la pantalla
        {
            Destroy(gameObject);
        }
    }
}
