using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDropship : Player
{
    [Header("Drop ship")]
    public PlayerDrone dronePrefab;
    public List<PlayerDrone> drons = new List<PlayerDrone>();
    public Vector3[] dronsOffset = new Vector3[4];

    private void Start()
    {
        SpawnDrone();
    }

    void SpawnDrone()
    {
        var drone = Instantiate(dronePrefab);
        drone.InitDrone(transform, dronsOffset[weaponLevel]);
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

        if (weaponLevel < 4)
            SpawnDrone();
    }
}
