using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "User", menuName = "Game/User", order = int.MinValue), Serializable]
public class User : ScriptableObject
{
    private static User _instance = null;
    public static User Instance => _instance;

    RankerContainer rankerContainer = new RankerContainer();
    public List<RankingUser> rankingDatas = new List<RankingUser>();

    string dataSavePath => Application.dataPath + "/savedata.json";

    // call at game start
    public void InitSingleton()
    {
        _instance = this;
        JsonLoad();
    }

    public void AddRanking(string name, float score, DateTime saveDate)
    {
        RankingUser user = new RankingUser(name, score, saveDate);
        rankingDatas.Add(user);
        JsonSave();
    }

    public List<RankingUser> GetFiveTopRankers()
    {
        List<RankingUser> result = new List<RankingUser>();

        var ordered = rankingDatas.OrderByDescending((item) => item.score).ToList();

        // 최대 5개 정보, 5개 미만일 경우 반복문을 그만큼만
        int count = 0;
        for (int i = 0; i < ordered.Count(); i++)
        {
            if (count < 5)
                result.Add(ordered[i]);
            else
                break;

            count++;
        }

        return result;
    }

    string jsonKey => "rankingSave";

    void JsonSave()
    {
        rankerContainer.users = rankingDatas;
        string result = JsonUtility.ToJson(rankerContainer, true);

        File.WriteAllText(dataSavePath, result);
    }

    void JsonLoad()
    {
        string result = "";

        if (File.Exists(dataSavePath))
        {
            result = File.ReadAllText(dataSavePath);
        }

        if (!string.IsNullOrEmpty(result))
        {
            rankerContainer = JsonUtility.FromJson<RankerContainer>(result);
            rankingDatas = rankerContainer.users;
        }
        else
        {
            rankerContainer = new RankerContainer();
            rankingDatas = new List<RankingUser>();
        }

    }

}

[Serializable]
public class RankerContainer
{
    public List<RankingUser> users = new List<RankingUser>();
}

[Serializable]
public class RankingUser
{
    public string name;
    public float score;
    public string saveDate;

    public RankingUser(string _name, float _score, DateTime _saveDate)
    {
        name = _name;
        score = _score;
        saveDate = _saveDate.ToString();
    }
}