using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peekaboo : PowerupsBaseClass
{
    public float duration;

    public override void Activate(Vector3 position)
    {
        base.Activate(position);
        GameController.Instance.TurnInvisible(duration);
    }
}
