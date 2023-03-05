using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptableSingletonManager : MonoBehaviour
{
    public User user;
    public TempData temp;

    private void Start()
    {
        user.InitSingleton();
        temp.InitTempData();
        StartCoroutine(IntroAnimation());
    }

    IEnumerator IntroAnimation()
    {


        SceneManager.LoadScene("Menu");
        yield break;
    }
}
