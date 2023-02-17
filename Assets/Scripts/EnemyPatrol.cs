using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private GameObject leftFlag;
    [SerializeField] private GameObject rightFlag;

    [SerializeField] float _speed = 1;

    [SerializeField] private bool _isLeft;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }
    private void Update()
    {

        if (_isLeft)
        {
            transform.position -= Vector3.left * _speed * Time.deltaTime;
        }
        else if (!_isLeft)
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }
           

        if ((transform.localPosition.x >= rightFlag.transform.position.x) & _isLeft == true)
        {
            _isLeft = false;
            switchSight(_isLeft);
        }
        else if((transform.localPosition.x <= leftFlag.transform.position.x) & _isLeft == false) 
        {
            _isLeft = true;
            switchSight(_isLeft);
        }
    }

    private void switchSight(bool _isLeft)
    {
        if (_isLeft)
            transform.Rotate(0,180 , 0);
        else
            transform.Rotate(0, -180, 0);
    }
}
