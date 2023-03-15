using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class RakningManager : MonoBehaviour
{
    public Text scoreTxt;
    public InputField nameInput;

    float totalScore;
    DateTime nowTime;

    private void Start()
    {
        float _tempScore = 0;
        foreach (var item in TempData.Instance.stageScore)
        {
            _tempScore += item;
        }
        totalScore = _tempScore;
        nowTime = DateTime.Now;
        scoreTxt.text = string.Format("{0:#,0}", _tempScore);
    }

    public void ㅎ화확확ㅇ인인ㅂ버벝벝ㄴ느느()
    {
        if (nameInput.text.Length <= 0) return;

        nameInput.text.Replace(" ", "_");
        User.Instance.AddRanking(nameInput.text, totalScore, nowTime);

        SceneManager.LoadScene("Menu");
    }
}
