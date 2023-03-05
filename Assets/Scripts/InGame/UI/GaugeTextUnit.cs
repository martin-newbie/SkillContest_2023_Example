using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class GaugeTextUnit : MonoBehaviour
{
    RectTransform rect;
    public Text gaugeText;
    public Image gaugeImage;
    public Vector2 startAnchor;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        var pos = rect.anchoredPosition;
        pos.y = startAnchor.y + gaugeImage.rectTransform.sizeDelta.y * gaugeImage.fillAmount;

        gaugeText.text = string.Format("{0:0}%", gaugeImage.fillAmount * 100f);
        rect.anchoredPosition = pos;
    }
}
