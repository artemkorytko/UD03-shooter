using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    [SerializeField] private float sensetivity = 2000f;
    [SerializeField] private Transform player;

    private float _mouseX;
    private float _mouseY;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * sensetivity * Time.deltaTime;
        //_mouseY = Input.GetAxis("Mouse Y") * sensetivity * Time.deltaTime;
        _mouseY = Mathf.Clamp(Input.GetAxis("Mouse Y") * sensetivity * Time.deltaTime, -35, 35);
        player.Rotate(_mouseX * new Vector3(0, 1, 0));
        transform.Rotate(_mouseY * new Vector3(-1, 0, 0));
        
    }
}
