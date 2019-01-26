using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    [SerializeField]
    public float m_speed;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = this.GetComponent<Rigidbody>();
        m_rigidbody.AddForce(transform.forward * m_speed, ForceMode.VelocityChange);
        Destroy(gameObject, 7f);

        m_rigidbody.MovePosition(m_rigidbody.position + transform.forward * Input.GetAxis("Vertical"));
        m_rigidbody.MovePosition(m_rigidbody.position + transform.right * Input.GetAxis("Horizontal"));
    }


    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
