using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveleft : MonoBehaviour
{
    [SerializeField] float _speed = 1;
    private Transform _transform;
    private bool t = false;
    void Start()
    {
        _transform = GetComponent<Transform>();
        _speed = 1;
    }

    // Update is called once per frame
    void Update()
    {


        transform.position -= Vector3.left * _speed * Time.deltaTime;


        if (transform.position.x >= -6)
        {
            
            _speed *= 1;
        }

        if(transform.position.x >= 6) 
        {
            _speed *= -1;
        }





    }
}
