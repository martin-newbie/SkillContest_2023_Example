using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVoyage : Player
{
    protected override void BulletShoot()
    {
        if (ㅁ무묵무기길기레렙레베벨벨 >= 3)
        {
            Instantiate(bullet, transform.position + new Vector3(-0.75f, -0.25f), Quaternion.Euler(0, 0, 90 + 15));
            Instantiate(bullet, transform.position + new Vector3(0.75f, -0.25f), Quaternion.Euler(0, 0, 90 - 15));
        }
        if (ㅁ무묵무기길기레렙레베벨벨 >= 2)
        {
            Instantiate(bullet, transform.position + new Vector3(-0.5f, 0f), Quaternion.Euler(0, 0, 90));
            Instantiate(bullet, transform.position + new Vector3(0.5f, 0f), Quaternion.Euler(0, 0, 90));
        }
        if (ㅁ무묵무기길기레렙레베벨벨 >= 1)
        {
            Instantiate(bullet, transform.position + new Vector3(-0.15f, 0.5f), Quaternion.Euler(0, 0, 90));
            Instantiate(bullet, transform.position + new Vector3(0.15f, 0.5f), Quaternion.Euler(0, 0, 90));
        }
        else
        { // when level 0
            Instantiate(bullet, transform.position + new Vector3(0f, 0.5f), Quaternion.Euler(0, 0, 90));
        }
    }
}
