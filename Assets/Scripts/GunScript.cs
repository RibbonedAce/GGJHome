using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject projectile;
    //public float speed = 20;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Shoot in the forward direction of this object
        //Vector3 fwdDirection = this.transform.forward;

        Instantiate(projectile, this.transform.position, transform.rotation);

    }

}
