using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorIsLava : PowerupsBaseClass
{
    public float damageRadius = 100;
    public float damageDealt = 50;

    public override void Activate(Vector3 position)
    {
        base.Activate(position);
        Instantiate(Resources.Load<GameObject>("FloorIsLavaCircle"), position, Quaternion.identity);
        Debug.Log("It's been used");
    }
}
