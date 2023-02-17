using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBullet;
    [SerializeField] private GameObject _spawnPointBullet;

    [SerializeField] private float leftFlagPositon;
    [SerializeField] private float rightFlagPositon;

    [SerializeField] public float _speed = 1;

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
           

        if ((transform.localPosition.x >= rightFlagPositon) & _isLeft == true)
        {
            _isLeft = false;
            switchSight(_isLeft);
        }
        else if((transform.localPosition.x <= leftFlagPositon) & _isLeft == false) 
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
