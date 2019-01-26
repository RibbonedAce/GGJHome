using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private int m_clipSize;
    public int m_maxClipSize = 20;

    void Start()
    {
        m_clipSize = m_maxClipSize;
    }

    void Update()
    {
        DecreaseClip();
        if (m_clipSize <= 0)
        {
            Reload();
        }
    }

    void DecreaseClip()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            m_clipSize--;
        }
    }

    void Reload()
    {
        m_clipSize = m_maxClipSize;
    }
}
