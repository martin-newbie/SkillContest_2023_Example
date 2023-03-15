using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTram : EnemyBase
{
    [Header("Tram")]
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject meteor;
    public GameObject explosion;

    Coroutine mainLogic;

    int phaseLevel;

    public bool isEnd = false;

    SimpleGauge bossHp;

    protected override void DieDestroy()
    {
        phaseLevel = 0;
        StopCoroutine(mainLogic);
        StartCoroutine(Outro());
    }

    IEnumerator Outro()
    {
        float delay = 0.25f;
        float cur = 0f;
        while (transform.position.y < 6.5f)
        {
            if (cur >= delay)
            {
                Instantiate(explosion, transform.position + (Vector3)Random.insideUnitCircle, Quaternion.identity, transform);
                cur = 0f;
            }

            cur += Time.deltaTime;
            transform.Translate(Vector3.up * Time.deltaTime);
            yield return null;
        }
        isEnd = true;
        yield break;
    }

    protected override void Start()
    {
        base.Start();
        bossHp = InGameManager.Instance.canvas.bossHp;
        mainLogic = StartCoroutine(StartIntro());
    }

    IEnumerator StartIntro()
    {
        transform.position = new Vector3(0, 6.5f);

        bossHp.gameObject.SetActive(true);
        StartCoroutine(gaugeFill(1f));
        yield return StartCoroutine(MoveTo(new Vector3(0, 3f)));

        phaseLevel = 1;
        yield return new WaitUntil(() => hp / maxHp <= 0.5f);

        cur1 = 0f;
        cur2 = 0f;

        delay1 = 0.2f;
        delay2 = 2f;

        phaseLevel = 2;

        yield break;

        IEnumerator gaugeFill(float duration)
        {
            float timer = 0f;

            while (timer < duration)
            {
                bossHp.SetGauge(timer / duration);

                timer += Time.deltaTime;
                yield return null;
            }
        }
    }

    private void Update()
    {
        if (phaseLevel == 1) Phase1();
        if (phaseLevel == 2) Phase2();

    }

    float delay1 = 1f;
    float cur1 = 0f;

    float delay2 = 2.4f;
    float cur2 = 0f;

    float delay3 = 0.3f;
    float cur3 = 0f;

    void Phase1()
    {
        if (delay1 <= cur1)
        {

            for (int i = 0; i < 360; i += Random.Range(35, 55))
            {
                Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, i));
            }

            cur1 = 0f;
        }


        if (delay2 <= cur2)
        {

            var dir = (InGameManager.Instance.curPlayer.transform.position - transform.position);
            float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            for (int i = -45; i < 45; i += 3)
            {
                var temp = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, i + z));
                temp.GetComponent<EnemyBullet>().moveSpeed = Random.Range(1f, 5f);
            }


            cur2 = 0f;
        }

        cur1 += Time.deltaTime;
        cur2 += Time.deltaTime;

        bossHp.SetGauge(hp / maxHp);
    }

    int dir = 1;
    void Phase2()
    {
        if (delay1 <= cur1)
        {
            for (int i = 0; i < 8; i++)
            {
                Instantiate(meteor, new Vector3(-3.5f + i, 6), Quaternion.identity);
            }

            cur1 = 0f;
        }


        if (delay2 <= cur2)
        {
            for (int i = -45; i < 45; i += 6)
            {
                var temp = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, i - 90f));
                temp.GetComponent<EnemyBullet>().moveSpeed = Random.Range(1f, 5f);
            }

            cur2 = 0f;
        }

        float calc = transform.position.x + dir * Time.deltaTime * 3f;
        if(delay3 <= cur3 || calc < -3f || calc > 3f)
        {
            dir *= -1;
            cur3 = 0f;
            delay3 = Random.Range(0.3f, 1f);
        }

        transform.Translate(Vector3.right * dir * Time.deltaTime * 3f);

        cur1 += Time.deltaTime;
        cur2 += Time.deltaTime;
        cur3 += Time.deltaTime;

        bossHp.SetGauge(hp / maxHp);
    }

    public override void OnDamage(float dmg)
    {
        if (phaseLevel != 0)
            base.OnDamage(dmg);
    }

    IEnumerator MoveTo(Vector3 target)
    {
        float dur = Vector3.Distance(transform.position, target) * 0.4f;
        float timer = 0f;
        Vector3 start = transform.position;

        while (timer < dur)
        {
            transform.position = Vector3.Lerp(transform.position, target, timer / dur);
            timer += Time.deltaTime;
            yield return null;
        }


        yield break;
    }

}
