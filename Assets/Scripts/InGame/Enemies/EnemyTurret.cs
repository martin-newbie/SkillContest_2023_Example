using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : EnemyBase
{
    [Header("Turret")]
    public SpriteRenderer laserSprite;
    public float moveSpeed;
    BoxCollider2D laserCol;

    protected override void DieDestroy()
    {
        laserSprite.gameObject.SetActive(false);
    }

    private void OnBecameVisible()
    {
        StartCoroutine(LaserOpen(0.5f));
    }

    protected override void Start()
    {
        base.Start();
        laserCol = laserSprite.GetComponent<BoxCollider2D>();
    }

    IEnumerator LaserOpen(float duration)
    {
        float timer = 0f;
        Vector2 size = laserSprite.size;

        while (timer <= duration)
        {
            size.y = Mathf.Lerp(0f, 12f, timer / duration);

            laserSprite.size = size;

            laserCol.size = size;
            laserCol.offset = new Vector2(0, size.y / 2f);

            timer += Time.deltaTime;
            yield return null;
        }


        yield break;
    }

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * moveSpeed;

        if (transform.position.y <= -7f) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().OnDamage(maxHp);
        }
    }
}
