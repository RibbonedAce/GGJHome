using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorIsLavaDamageCircle : MonoBehaviour
{
    public float damageRadius = 100f;
    public float damageDealt = 50f;

    private void Start()
    {
        updateRadius();
    }

    void updateRadius()
    {
        Vector3 newRadius = new Vector3(this.transform.localScale.x * damageRadius, this.transform.localScale.y, this.transform.localScale.z * damageRadius);
        this.transform.localScale = newRadius;
    }
}
