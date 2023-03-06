using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChopper : EnemyBase
{

    [Header("Chopper")]
    public GameObject bullet;
    public GameObject explosion;
    public float attackDelay = 2f;

    float curDelay;
    Vector3 finalPos;
    Coroutine atkCoroutine;

    public void InitChopper(Vector3 _finalPos)
    {
        finalPos = _finalPos;

        transform.position = finalPos + new Vector3(2 * RandomBetween(1, -1), 6);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, finalPos) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, finalPos, Time.deltaTime * 15f);
            return;
        }


        curDelay += Time.deltaTime;
        if (curDelay >= attackDelay)
        {
            atkCoroutine = StartCoroutine(AttackCoroutine());
            curDelay = 0f;
        }

    }

    IEnumerator AttackCoroutine()
    {
        var dir = InGameManager.Instance.curPlayer.transform.position - transform.position;
        float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 3; i++)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, z));
            yield return new WaitForSeconds(0.3f);
        }

        yield break;
    }

    protected override void DieDestroy()
    {
        if (atkCoroutine != null) StopCoroutine(atkCoroutine);

        Instantiate(explosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    T RandomBetween<T>(params T[] objs)
    {
        return objs[Random.Range(0, objs.Length)];
    }
}
