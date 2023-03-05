using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : StageBase
{
    private void Start()
    {
        
    }

    IEnumerator Wave1()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(enemies[0], new Vector3(-3, 6), Quaternion.identity);

            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(5f);
    }

    IEnumerator Wave2()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(enemies[0], new Vector3(3, 6), Quaternion.identity);

            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(5f);
    }


}
