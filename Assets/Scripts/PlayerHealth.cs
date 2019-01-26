﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float m_playerHealth { get; private set; }
    [SerializeField]
    public float m_maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        m_playerHealth = m_maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            m_playerHealth -= collision.collider.GetComponent<Enemy>().m_damage;
            Debug.Log("Current Health" + m_playerHealth);
        }
    }
}