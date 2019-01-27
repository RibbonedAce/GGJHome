using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupList : MonoBehaviour
{

    public List<PowerupsBaseClass> pList = new List<PowerupsBaseClass>();
    public int maxPowerups = 3;
    public AudioClip powerUpClip;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Vector3 position = new Vector3(this.transform.position.x, this.transform.position.y - this.transform.position.y + 0.000001f, this.transform.position.z);
            Activate(position);
            Debug.Log("Use Powerup");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup") && (other.gameObject.name == "FILPowerup"))
        {
            Debug.Log("Added FILPowerup");
            UpdateList(new FloorIsLava());
            Destroy(other.gameObject);
        }
        //if((collision.gameObject.name == "Peakaboo") && collision.collider.CompareTag("Powerup"))
        //{

        //}
    }

    public void UpdateList(PowerupsBaseClass powerup)
    {
        if(pList.Count < maxPowerups)
        {
            pList.Add(powerup);
        }
    }

    public void Activate(Vector3 position)
    {
        pList[pList.Count - 1].Activate(position);
        pList.RemoveAt(pList.Count - 1);
        _audioSource.clip = powerUpClip;
        _audioSource.Play();
    }
}
