using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponStatus : MonoBehaviour
{
    public Image weaponImage;
    public Text weaponLevel;

    public Sprite[] weaponSprites;

    public void InitWeapon(int index)
    {
        weaponImage.sprite = weaponSprites[index];
    }

    public void SetWeaponLevel(int level)
    {
        weaponLevel.text = string.Format("LV.{0:0}", level);
    }
}
