using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public ContactFilter2D filter;
    public float damage = 5f;
    Collider2D hitCol;

    void Start()
    {
        hitCol = GetComponent<Collider2D>();
        StartCoroutine(HitCoroutine());
    }

    IEnumerator HitCoroutine()
    {
        var wait = new WaitForSeconds(0.3f);

        while (true)
        {
            var result = new List<Collider2D>();
            Physics2D.OverlapCollider(hitCol, filter, result);

            if(result.Count > 0)
            {
                result[0].GetComponent<Player>().OnDamage(damage);
            }

            yield return wait;
        }
    }
}
