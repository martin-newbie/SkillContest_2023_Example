using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomber : EnemyBase
{
    [Header("Bomber")]
    public GameObject bullet;
    public GameObject explosion;
    public float moveSpeed;
    public float shotDelay;
    float curDelay;

    private void Update()
    {
        if(shotDelay <= curDelay)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0));
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 180));
            curDelay = 0f;
        }

        transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        curDelay += Time.deltaTime;

        if (transform.position.y <= -7f)
        {
            Destroy(gameObject);
        }

    }

    protected override void DieDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        for (int i = 0; i < 360; i += 360 / 10)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, i));
        }
        Destroy(gameObject);
    }
}
