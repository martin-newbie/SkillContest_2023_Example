using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFuel : ItemBase
{
    protected override void TriggerEvent(Collider2D collision)
    {
        collision.GetComponent<Player>().FuelRecover();
    }
}
