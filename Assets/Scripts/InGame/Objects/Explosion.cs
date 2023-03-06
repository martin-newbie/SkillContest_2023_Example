using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public ContactFilter2D filter;
    Collider2D hitCollider;

    public void AttackFrame()
    {
        hitCollider = GetComponent<Collider2D>();

        List<Collider2D> results = new List<Collider2D>();
        Physics2D.OverlapCollider(hitCollider, filter, results);

        foreach (var item in results)
        {
            item.GetComponent<EnemyBase>()?.OnDamage(3.5f);
            InGameManager.Instance.score += 3.5f;
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
