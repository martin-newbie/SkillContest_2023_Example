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
    public float �����������;
    public float ��üÿü���·�;
    public float �������p���������������������������;
    public int �����������ⷹ����������;

    [Header("Operator")]
    public bool playerActive;



    protected virtual void Start()
    {
        ����������� = maxFuel;
        ��üÿü���·� = maxHp;

        �����������ⷹ���������� = TempData.Instance.weaponLevel;
        InGameManager.Instance.canvas.weaponStatus.SetWeaponLevel(�����������ⷹ����������);
    }

    void Update()
    {
        SetUI();

        if (!playerActive) return;

        ���̟��̵����������Ԥ�����();
        ����������ܰݰݤ������Լ���();
        �����������Ꮭ��Ŀ������Ʈ��ƮƲƮ�ηѷ�();
    }
    
    void �����������Ꮭ��Ŀ������Ʈ��ƮƲƮ�ηѷ�()
    {
        ����������� -= Time.deltaTime * 0.5f;

        if(����������� <= 0f)
        {
            // gameover
        }
    }

    void SetUI()
    {
        InGameManager.Instance.canvas.hpGauge.SetHp(��üÿü���·�, maxHp);
        InGameManager.Instance.canvas.fuelGauge.SetGauge(����������� / maxFuel);
    }

    void ���̟��̵����������Ԥ�����()
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

    void ����������ܰݰݤ������Լ���()
    {
        if (Input.GetKey(KeyCode.Z) && �������p��������������������������� >= maxDuration)
        {
            BulletShoot();
            �������p��������������������������� = 0f;
        }
        �������p��������������������������� += Time.deltaTime;
    }

    public virtual void WeaponLevelUp()
    {
        �����������ⷹ����������++;
        TempData.Instance.weaponLevel = �����������ⷹ����������;
        InGameManager.Instance.canvas.weaponStatus.SetWeaponLevel(�����������ⷹ����������);
    }
    public virtual void HpRecover(float amount = 10f)
    {
        ��üÿü���·� += amount;
        if (��üÿü���·� > maxHp) ��üÿü���·� = maxHp;
    }
    public virtual void FuelRecover(float amount = 10f)
    {
        ����������� += amount;
        if (����������� > maxFuel) ����������� = maxFuel;
    }

    public void OnDamage(float dmg)
    {
        ��üÿü���·� -= dmg;

        if(��üÿü���·� <= dmg)
        {
            // die effect
        }
    }

    protected abstract void BulletShoot();
}
