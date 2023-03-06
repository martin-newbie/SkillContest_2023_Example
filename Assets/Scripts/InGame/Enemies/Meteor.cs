using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float moveSpeed = 3f;

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);

        if (transform.position.y <= -7f) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().OnDamage(15f);
        }
    }
}
