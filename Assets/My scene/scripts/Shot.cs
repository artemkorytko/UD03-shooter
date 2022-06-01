using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject pistol;
    private float _power = 100f;
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                hit.rigidbody.AddForceAtPosition(ray.direction * _power, hit.point);
                Instantiate(bullet, hit.point, transform.rotation);
            }
        }
    }
}
