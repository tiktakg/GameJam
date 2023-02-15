using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _velcotiy = 1;
    [SerializeField] private float _jumpforse = 1;

    private Transform _transform;

    [SerializeField] bool _isLeft = false;
 


    void Start()
    {
        _transform = GetComponent<Transform>();
        transform.Rotate(0, 0, 0);

    }

   
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            transform.position += Vector3.up * _velcotiy * _jumpforse * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A))
        {
            if (_isLeft != true)
            {
                transform.Rotate(0, 180, 0);
                _isLeft = true;
            }

            transform.position += Vector3.left * _velcotiy * Time.deltaTime;
           

        }
        else if(Input.GetKey(KeyCode.D))
        {
            if(_isLeft != false)
            {
                transform.Rotate(0, -180, 0);
                _isLeft = false;
            }

            
            
            transform.position -= Vector3.left * _velcotiy * Time.deltaTime;

            
        }

    }
}
