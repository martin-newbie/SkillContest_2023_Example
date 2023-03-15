using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : StageBase
{

    private void Start()
    {
        waveList.Add(Wave1);
        waveList.Add(Wave2);
        waveList.Add(Wave3);
        waveList.Add(Wave4);
        waveList.Add(Wave5);
        waveList.Add(Wave6);
    }

    IEnumerator Wave1()
    {
        InGameManager.Instance.PrintMessage("press z to attack");
        yield return new WaitForSeconds(5f);
    }

    IEnumerator Wave2()
    {
        InGameManager.Instance.PrintMessage("press x to heal");
        yield return new WaitForSeconds(5f);
    }

    IEnumerator Wave3()
    {
        InGameManager.Instance.PrintMessage("press c to bomb");
        yield return new WaitForSeconds(5f);
    }

    IEnumerator Wave4()
    {
        InGameManager.Instance.PrintMessage("if hp below 0 will be game over");
        yield return new WaitForSeconds(5f);
    }

    IEnumerator Wave5()
    {
        InGameManager.Instance.PrintMessage("if fuel below 0 will be game over");
        yield return new WaitForSeconds(5f);
    }

    IEnumerator Wave6()
    {
        InGameManager.Instance.PrintMessage("enjoy your game");
        yield return new WaitForSeconds(5f);
    }


    void SpawnItem(int index, Transform transform)
    {
        Instantiate(items[index], transform.position, Quaternion.identity);
    }
}
