using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorIsLava : PowerupsBaseClass
{
    public override void Activate(Vector3 position)
    {
        base.Activate(position);
        Instantiate(Resources.Load<GameObject>("FloorIsLavaCircle"), position, Quaternion.identity);
        Debug.Log("It's been used");
    }
}