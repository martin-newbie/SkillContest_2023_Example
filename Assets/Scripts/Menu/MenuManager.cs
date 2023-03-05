using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject Window_HowToPlay;
    public GameObject Window_Ranking;
    public GameObject Window_Exit;

    public void GameStart()
    {
        TempData.Instance.stageIndex = 0;
        TempData.Instance.weaponLevel = 0;
        TempData.Instance.stageScore = new float[3];

        SceneManager.LoadScene("Setting");
    }

    public void HowToPlay()
    {
        Window_HowToPlay.SetActive(true);
    }

    public void Ranking()
    {
        Window_Ranking.SetActive(true);
    }

    public void Exit()
    {
        Window_Exit.SetActive(true);
    }
}
