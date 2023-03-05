using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    public RankingUnit unitPrefab;

    public Transform unitParent;
    public List<RankingUnit> unitList = new List<RankingUnit>();

    void Start()
    {
        var data = User.Instance.GetFiveTopRankers();

        foreach (var item in data)
        {
            var unit = Instantiate(unitPrefab, unitParent);
            unit.InitUnit(item);
            unitList.Add(unit);
        }

        unitPrefab.gameObject.SetActive(false);
    }

}
