using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private float damage;
    private float collisionTime;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Health>().TakeDamage(damage);
            collisionTime = 0f;
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (collisionTime < 1f)
            {
                collisionTime += Time.deltaTime;
            }
            else
            {
                col.gameObject.GetComponent<Health>().TakeDamage(damage);
                collisionTime = 0f;
            }
        }
    }
}
