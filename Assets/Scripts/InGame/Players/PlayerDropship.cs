using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDropship : Player
{
    [Header("Drop ship")]
    public PlayerDrone dronePrefab;
    public List<PlayerDrone> drons = new List<PlayerDrone>();
    public Vector3[] dronsOffset = new Vector3[4];

    protected override void Start()
    {
        base.Start();
        for (int i = 0; i <= ㅁ무묵무기길기레렙레베벨벨; i++)
        {
            SpawnDrone(i);
        }
    }

    void SpawnDrone(int index = -1)
    {
        if (index == -1) index = ㅁ무묵무기길기레렙레베벨벨;

        var drone = Instantiate(dronePrefab);
        drone.InitDrone(transform, dronsOffset[index]);
        drons.Add(drone);
    }

    protected override void BulletShoot()
    {
        Instantiate(bullet, transform.position + new Vector3(-0.15f, 0.5f), Quaternion.identity);
        Instantiate(bullet, transform.position + new Vector3(0.15f, 0.5f), Quaternion.identity);

        foreach (var item in drons)
        {
            item.DroneAttack();
        }

    }

    public override void WeaponLevelUp()
    {
        base.WeaponLevelUp();

        if (ㅁ무묵무기길기레렙레베벨벨 < 4)
            SpawnDrone();
    }
}
