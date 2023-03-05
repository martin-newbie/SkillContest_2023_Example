using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleSkill : MonoBehaviour
{
    public Image fillGauge;

    public void SetFill(float fillAmount)
    {
        fillGauge.fillAmount = fillAmount;

        fillGauge.gameObject.SetActive(fillAmount > 0f);
    }
}
