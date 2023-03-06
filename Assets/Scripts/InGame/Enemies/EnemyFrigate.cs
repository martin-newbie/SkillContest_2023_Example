using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrigate : EnemyBase
{
    [Header("Frigate")]
    public GameObject bullet;
    public GameObject explosion;
    public float moveSpeed;
    public float atkDelay;
    float curDelay;

    private void Update()
    {
        if (curDelay >= atkDelay)
        {
            Attack();
            curDelay = 0f;
        }

        curDelay += Time.deltaTime;

        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);


        if (transform.position.x > 10f || transform.position.x < -10f) Destroy(gameObject);
    }

    void Attack()
    {
        for (int i = 0; i < 360; i += Random.Range(35, 55))
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, i));
        }
    }

    protected override void DieDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
