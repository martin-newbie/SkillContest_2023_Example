using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : StageBase
{
    void Start()
    {
        waveList.Add(Wave6);
    }

    IEnumerator Wave1()
    {
        for (int i = 0; i < 5; i++)
        {
            var temp = Instantiate(enemies[0], new Vector3(-3, 6), Quaternion.identity);

            if (i == 4) temp.GetComponent<EnemyBase>().dieAction += () => SpawnItem(1, temp.transform);

            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(5f);
    }

    IEnumerator Wave2()
    {
        for (int i = 0; i < 5; i++)
        {
            var temp = Instantiate(enemies[0], new Vector3(3, 6), Quaternion.identity);

            if (i == 4) temp.GetComponent<EnemyBase>().dieAction += () => SpawnItem(1, temp.transform);

            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(5f);
    }

    IEnumerator Wave3()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(enemies[1], new Vector3(5, Random.Range(3f, 0f)), Quaternion.Euler(0, 0, Random.Range(80f, 100f)));
            Instantiate(enemies[1], new Vector3(-5, Random.Range(3f, 0f)), Quaternion.Euler(0, 0, Random.Range(260f, 280f)));

            yield return new WaitForSeconds(0.8f);
        }

        yield return new WaitForSeconds(5f);
    }

    IEnumerator Wave4()
    {
        Instantiate(enemies[4], new Vector3(-2.25f, 6f), Quaternion.Euler(0, 0, 0));
        yield return new WaitForSeconds(1.35f);

        var temp = Instantiate(enemies[4], new Vector3(2.54f, 6f), Quaternion.Euler(0, 0, 0));
        temp.GetComponent<EnemyBase>().dieAction += () => SpawnItem(1, temp.transform);

        yield return new WaitForSeconds(5f);
    }

    IEnumerator Wave5()
    {
        List<EnemyBase> curEnemy = new List<EnemyBase>();

        for (int i = 0; i < 7; i++)
        {
            var temp = Instantiate(enemies[3]);
            temp.GetComponent<EnemyChopper>().InitChopper(new Vector3(-3 + i, 1));
            curEnemy.Add(temp);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(3f);

        for (int i = 0; i < 7; i++)
        {
            var temp = Instantiate(enemies[3]);
            temp.GetComponent<EnemyChopper>().InitChopper(new Vector3(3 - i, 1));
            curEnemy.Add(temp);
            yield return new WaitForSeconds(0.1f);
        }

        while (curEnemy.Count > 0)
        {
            for (int i = 0; i < curEnemy.Count; i++)
            {
                if (curEnemy[i].hp <= 0)
                {
                    var remove = curEnemy[i];

                    curEnemy.Remove(remove);
                    Destroy(remove.gameObject);
                }
            }
            yield return null;
        }

        yield return new WaitForSeconds(5f);
    }

    IEnumerator Wave6()
    {
        var boss = Instantiate(enemies[5]);
        yield return new WaitUntil(() => (boss as BossTram).isEnd);
    }


    void SpawnItem(int index, Transform transform)
    {
        Instantiate(items[index], transform.position, Quaternion.identity);
    }
}
