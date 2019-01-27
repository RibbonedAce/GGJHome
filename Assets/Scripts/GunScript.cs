using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject projectile;

    public int m_clipSize;
    public int m_maxClipSize = 5;
    bool m_reloading = false;

    public AudioClip shootClip;
    public AudioClip reloadClip;
    private AudioSource _audioSource;

    void Start()
    {
        m_clipSize = m_maxClipSize;
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance != null && GameController.Instance.Paused)
        {
            return;
        }
        if (m_clipSize == 0 && !m_reloading)
        {
            Debug.Log("Reloading...");
            m_reloading = true;
            StartCoroutine(reloadC());
            //Invoke("Reload", 2);
            Debug.Log("Done Reloading");
        }
        if (Input.GetButtonDown("Fire1") && m_clipSize != 0 && !m_reloading)
        {
            //Debug.Log("Shooting");
            DecreaseClip();
            Shoot();
        }
    }

    IEnumerator reloadC()
    {
        _audioSource.clip = reloadClip;
        _audioSource.Play();
        yield return new WaitForSeconds(2);
        Reload();
        m_reloading = false;
    }

    void Shoot()
    {
        //Shoot in the forward direction of this object
        Instantiate(projectile, this.transform.position, transform.rotation);
        _audioSource.clip = shootClip;
        _audioSource.Play();
    }

    void DecreaseClip()
    {
        m_clipSize--;
    }

    void Reload()
    {
        m_clipSize = m_maxClipSize;
        //m_reloading = false;
    }
}
