using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveSpawner : MonoBehaviour
{
    List<Transform> transformList = new List<Transform>();
    int currentWave = 1;

    // Start is called before the first frame update
    void Start()
    {
        fillTList();
    }

    // Update is called once per frame
    void Update()
    {
        //Check to see if there are any enemies left
        if(transformList[currentWave - 1].childCount == 0)
        {
            newWave();
        }
    }

    void fillTList()
    {
        //Total amount of children in this Object
        int tCount = transform.childCount;
        //Iterate through each child and add them to transformList
        for (int i = 1; i <= tCount; i++)
        {
            string search = string.Format("Wave{0}", i);
            transformList.Add(this.transform.Find(search));
        }
    }

    void newWave()
    {
        //Check to see if we are on the last Wave
        if(currentWave != transform.childCount)
        {
            //Disable current Wave
            transformList[currentWave - 1].gameObject.SetActive(false);
            currentWave++;
            //Enable next Wave
            transformList[currentWave - 1].gameObject.SetActive(true);
        }
    }
}
