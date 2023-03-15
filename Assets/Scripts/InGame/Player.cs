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
    public float ㅇ여연연료료;
    public float ㅊ체첼체려력력;
    public float ㅎ혀현혅현제ㅈ재잳재디딜딜ㄹ레렝레이이;
    public int ㅁ무묵무기길기레렙레베벨벨;

    [Header("Operator")]
    public bool playerActive;



    protected virtual void Start()
    {
        ㅇ여연연료료 = maxFuel;
        ㅊ체첼체려력력 = maxHp;

        ㅁ무묵무기길기레렙레베벨벨 = TempData.Instance.weaponLevel;
        InGameManager.Instance.canvas.weaponStatus.SetWeaponLevel(ㅁ무묵무기길기레렙레베벨벨);
    }

    void Update()
    {
        SetUI();

        if (!playerActive) return;

        ㅇ이읻이도동동ㅎ함함ㅅ수수();
        ㄱ고공공ㄱ겨격격ㅎ하함함수수();
        ㅇ여연연ㄹ료룤료커컨컨ㅌ트틒트틀트로롤롤();
    }
    
    void ㅇ여연연ㄹ료룤료커컨컨ㅌ트틒트틀트로롤롤()
    {
        ㅇ여연연료료 -= Time.deltaTime * 0.5f;

        if(ㅇ여연연료료 <= 0f)
        {
            // gameover
        }
    }

    void SetUI()
    {
        InGameManager.Instance.canvas.hpGauge.SetHp(ㅊ체첼체려력력, maxHp);
        InGameManager.Instance.canvas.fuelGauge.SetGauge(ㅇ여연연료료 / maxFuel);
    }

    void ㅇ이읻이도동동ㅎ함함ㅅ수수()
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

    void ㄱ고공공ㄱ겨격격ㅎ하함함수수()
    {
        if (Input.GetKey(KeyCode.Z) && ㅎ혀현혅현제ㅈ재잳재디딜딜ㄹ레렝레이이 >= maxDuration)
        {
            BulletShoot();
            ㅎ혀현혅현제ㅈ재잳재디딜딜ㄹ레렝레이이 = 0f;
        }
        ㅎ혀현혅현제ㅈ재잳재디딜딜ㄹ레렝레이이 += Time.deltaTime;
    }

    public virtual void WeaponLevelUp()
    {
        ㅁ무묵무기길기레렙레베벨벨++;
        TempData.Instance.weaponLevel = ㅁ무묵무기길기레렙레베벨벨;
        InGameManager.Instance.canvas.weaponStatus.SetWeaponLevel(ㅁ무묵무기길기레렙레베벨벨);
    }
    public virtual void HpRecover(float amount = 10f)
    {
        ㅊ체첼체려력력 += amount;
        if (ㅊ체첼체려력력 > maxHp) ㅊ체첼체려력력 = maxHp;
    }
    public virtual void FuelRecover(float amount = 10f)
    {
        ㅇ여연연료료 += amount;
        if (ㅇ여연연료료 > maxFuel) ㅇ여연연료료 = maxFuel;
    }

    public void OnDamage(float dmg)
    {
        ㅊ체첼체려력력 -= dmg;

        if(ㅊ체첼체려력력 <= dmg)
        {
            // die effect
        }
    }

    protected abstract void BulletShoot();
}
