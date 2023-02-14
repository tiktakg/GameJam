using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _velcotiy = 1;
    [SerializeField] private float _jumpforse = 1;

    private Transform _transform;
 


    void Start()
    {
        _transform = GetComponent<Transform>();
        
    }

   
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            transform.position += Vector3.up * _velcotiy * _jumpforse * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * _velcotiy * Time.deltaTime;
            //transform.Rotate(0, 180, 0);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.position -= Vector3.left * _velcotiy * Time.deltaTime;
            //transform.Rotate(0, -180, 0);
        }
    }
}
