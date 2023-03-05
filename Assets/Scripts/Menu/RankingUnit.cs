using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingUnit : MonoBehaviour
{
    public Text nameTxt;
    public Text scoreTxt;
    public Text dateTxt;

    public void InitUnit(RankingUser user)
    {
        nameTxt.text = user.name;
        scoreTxt.text = string.Format("{0:#,0}", user.score);
        dateTxt.text = user.saveDate.ToString();
    }
}
