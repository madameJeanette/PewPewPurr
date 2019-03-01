using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float lifeTime = 0.4f;
    float speed = 20;

    float timer;
    Vector2 direction;

    public Vector2 Direction { set { direction = value; } }

  
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= lifeTime)
        {
            GameObject.Destroy(this.gameObject);
        }

        this.GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<EnemyController>() != null)
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(collider.gameObject);
        }
    }
}
