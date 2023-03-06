using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public float maxHp;
    public float hp;

    public Action dieAction;

    protected virtual void Start()
    {
        hp = maxHp;
        dieAction += DieDestroy;
    }

    public virtual void OnDamage(float dmg)
    {
        hp -= dmg;

        if(hp <= 0)
        {
            dieAction?.Invoke();
        }
    }

    protected abstract void DieDestroy();
}
