using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public float maxHp;
    public float hp;

    private void Start()
    {
        hp = maxHp;
    }

    public void OnDamage(float dmg)
    {
        hp -= dmg;

        if(hp <= 0)
        {
            DieDestroy();
        }
    }

    protected abstract void DieDestroy();
}
