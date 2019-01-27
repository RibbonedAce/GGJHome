using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorIsLava : MonoBehaviour
{
    public float damageRadius = 100;
    public float damageDealt = 50;

    void Start()
    {
        //this.transform.GetComponent<MeshCollider>().radius = damageRadius;
    }

    void OnCollisionStay(Collision collision)
    {
        //string n = collision.gameObject.name;
        //Debug.Log(n);
    }
}
