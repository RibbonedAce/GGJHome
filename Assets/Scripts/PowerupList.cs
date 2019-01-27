using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupList : MonoBehaviour
{

    List<PowerupsBaseClass> pList = new List<PowerupsBaseClass>();
    private int maxPowerups;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateList(PowerupsBaseClass powerup)
    {
        if(pList.Count < maxPowerups)
        {
            pList.Add(powerup);
        }
    }

    public void Activate()
    {
        pList[0].Activate();

    }
}
