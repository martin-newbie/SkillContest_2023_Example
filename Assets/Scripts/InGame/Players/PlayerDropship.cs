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
        for (int i = 0; i <= �����������ⷹ����������; i++)
        {
            SpawnDrone(i);
        }
    }

    void SpawnDrone(int index = -1)
    {
        if (index == -1) index = �����������ⷹ����������;

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

        if (�����������ⷹ���������� < 4)
            SpawnDrone();
    }
}
