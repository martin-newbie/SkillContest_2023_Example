using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{

    [Header("Prefabs")]
    public GameObject bullet;

    [Header("Status")]
    public float maxHp;
    public float maxFuel;
    public float moveSpeed;
    public float maxDuration = 0.15f;

    [Header("Values")]
    public float fuel;
    public float hp;
    public float curDelay;
    public int weaponLevel;

    [Header("Operator")]
    public bool playerActive;



    void Start()
    {
        fuel = maxFuel;
        hp = maxHp;

        weaponLevel = TempData.Instance.weaponLevel;
        InGameManager.Instance.canvas.weaponStatus.SetWeaponLevel(weaponLevel);
    }

    void Update()
    {
        SetUI();

        if (!playerActive) return;

        MoveFunc();
        AttackFunc();
        FuelControl();
    }
    
    void FuelControl()
    {
        fuel -= Time.deltaTime * 0.5f;

        if(fuel <= 0f)
        {
            // gameover
        }
    }

    void SetUI()
    {
        InGameManager.Instance.canvas.hpGauge.SetHp(hp, maxHp);
        InGameManager.Instance.canvas.fuelGauge.SetGauge(fuel / maxFuel);
    }

    void MoveFunc()
    {
        int dirX = 0;
        int dirY = 0;

        if (Input.GetKey(KeyCode.LeftArrow)) dirX = -1;
        if (Input.GetKey(KeyCode.RightArrow)) dirX = 1;
        if (Input.GetKey(KeyCode.UpArrow)) dirY = 1;
        if (Input.GetKey(KeyCode.DownArrow)) dirY = -1;


        float moveX = dirX * Time.deltaTime;
        float moveY = dirY * Time.deltaTime;

        Vector3 moveVec = new Vector3(moveX, moveY) * moveSpeed;

        if (!InGameManager.Instance.IsInsideBorder_X(transform.position.x + moveVec.x, 0.25f))
            moveVec.x = 0f;
        if (!InGameManager.Instance.IsInsideBorder_Y(transform.position.y + moveVec.y, 0.25f))
            moveVec.y = 0f;


        transform.position += moveVec;
    }

    void AttackFunc()
    {
        if (Input.GetKey(KeyCode.Z) && curDelay >= maxDuration)
        {
            BulletShoot();
            curDelay = 0f;
        }
        curDelay += Time.deltaTime;
    }

    public virtual void WeaponLevelUp()
    {
        weaponLevel++;
        InGameManager.Instance.canvas.weaponStatus.SetWeaponLevel(weaponLevel);
    }
    public virtual void HpRecover(float amount = 10f)
    {
        hp += amount;
        if (hp > maxHp) hp = maxHp;
    }
    public virtual void FuelRecover(float amount = 10f)
    {
        fuel += amount;
        if (fuel > maxFuel) fuel = maxFuel;
    }

    public void OnDamage(float dmg)
    {
        hp -= dmg;

        if(hp <= dmg)
        {
            // die effect
        }
    }

    protected abstract void BulletShoot();
}
