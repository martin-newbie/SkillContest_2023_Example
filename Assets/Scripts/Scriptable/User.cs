using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "User", menuName ="Game/User", order =int.MinValue), Serializable]
public class User : ScriptableObject
{
    private static User _instance = null;
    public static User Instance => _instance;

    public List<RankingUser> rankingDatas = new List<RankingUser>();

    // call at game start
    public void InitSingleton()
    {
        _instance = this;
    }

    public void AddRanking(string name, float score, DateTime saveDate)
    {
        RankingUser user = new RankingUser(name, score, saveDate);
        rankingDatas.Add(user);
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
}

[Serializable]
public class RankingUser
{
    public string name;
    public float score;
    public DateTime saveDate;

    public RankingUser(string _name, float _score, DateTime _saveDate)
    {
        name = _name;
        score = _score;
        saveDate = _saveDate;
    }
}