using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class Moveleft : MonoBehaviour
{
    [SerializeField] float _speed = 1;

    private Transform _transform;
    private bool _isLeft = true;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (_isLeft)
        {
            transform.position -= Vector3.left * _speed * Time.deltaTime;
            Debug.Log("1");
        }
        else if (!_isLeft) 
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
            Debug.Log("2");
        }
           

        if (transform.localPosition.x >= 5 & _isLeft == true)
        {
            _isLeft = false;
        }
        else if(transform.localPosition.x <= -5 & _isLeft == false) 
        {
            _isLeft = true;
        }


        Debug.Log(transform.position.x);
    }
}
