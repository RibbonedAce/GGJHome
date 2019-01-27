using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float m_health;
    [SerializeField]
    public float m_damage;

    public GameObject postDeathEffect;

    public Transform target;

    private NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        if(m_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        _navMeshAgent.SetDestination(target.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Bullets"))
        {
            m_health -= 5;
        }
    }

    private void OnDestroy()
    {
        Instantiate(postDeathEffect, transform.position, transform.rotation);
    }
}
