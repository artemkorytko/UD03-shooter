using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float power;
    [SerializeField] private GameObject pistol;

    void Start()
    {
        transform.position = pistol.transform.position + new Vector3(1.5f, 0, 0);
    }
    void Update()
    {
        rb.AddForce(new Vector3(1,0,0) * power);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null)
        {
            Destroy(this);
        }
    }
}
