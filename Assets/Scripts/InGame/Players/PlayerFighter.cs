using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : Player
{
    protected override void BulletShoot()
    {
        if (weaponLevel >= 3)
        {
            Instantiate(bullet, transform.position + new Vector3(-0.1f, 0.25f), Quaternion.identity);
            Instantiate(bullet, transform.position + new Vector3(0.1f, 0.25f), Quaternion.identity);
        }
        if (weaponLevel >= 2)
        {
            Instantiate(bullet, transform.position + new Vector3(0f, 0.5f), Quaternion.identity);
        }
        if (weaponLevel >= 1)
        {
            Instantiate(bullet, transform.position + new Vector3(-0.15f, 0.5f), Quaternion.identity);
            Instantiate(bullet, transform.position + new Vector3(0.15f, 0.5f), Quaternion.identity);
        }
        else
        { // when level 0
            Instantiate(bullet, transform.position + new Vector3(0f, 0.5f), Quaternion.identity);
        }
    }
}
