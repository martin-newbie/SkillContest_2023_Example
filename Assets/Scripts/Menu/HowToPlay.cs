using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public GameObject[] descContents;
    int openIdx;

    private void OnEnable()
    {
        openIdx = 0;
        OpenContent();
    }

    public void Right()
    {
        if (openIdx < descContents.Length - 1) openIdx++;
        else openIdx = 0;

        OpenContent();
    }

    public void Left()
    {
        if (openIdx > 0) openIdx--;
        else openIdx = descContents.Length - 1;

        OpenContent();
    }

    void OpenContent()
    {
        for (int i = 0; i < descContents.Length; i++)
        {
            descContents[i].SetActive(i == openIdx);
        }
    }
}
