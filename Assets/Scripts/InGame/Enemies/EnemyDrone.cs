using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrone : EnemyBase
{
    [Header("Drone")]
    public float moveSpeed;

    public GameObject explosion;

    protected override void DieDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);

        if (transform.position.y <= -7f) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>()?.OnDamage(hp);
            DieDestroy();
        }
    }
}
