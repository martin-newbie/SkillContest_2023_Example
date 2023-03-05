using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    [Header("Info UI")]
    public Image curFlightImage;

    [Header("UI Object")]
    public Image[] buttons;
    public StatusGauge statusGauge;

    [Header("Data")]
    public Sprite[] flightSprite;

    public Sprite defaultButton;
    public Sprite highlightButton;

    public int curIndex;

    [Header("Status")]
    [SerializeField] float[] hp;
    [SerializeField] float[] dmg;
    [SerializeField] float[] speed;
    [SerializeField] float[] fuel;
    [SerializeField] float[] acc;

    private void Start()
    {
        FlightButtonClick(0);
    }

    public void FlightButtonClick(int index)
    {
        curIndex = index;

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == index) buttons[i].sprite = highlightButton;
            else buttons[i].sprite = defaultButton;
        }

        curFlightImage.sprite = flightSprite[index];
        statusGauge.SetGaugeValue(hp[index], dmg[index], speed[index], fuel[index], acc[index]);
    }

    public void GameStart()
    {
        TempData.Instance.curFlightIndex = curIndex;
        SceneManager.LoadScene("InGame");
    }
}
