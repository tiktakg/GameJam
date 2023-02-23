using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class EnemyScript : MonoBehaviour
{
    [SerializeField] public GameObject _prefabBullet;
    [SerializeField] public GameObject _spawnPointBullet;

    [SerializeField] public float _speed = 1;
    
    [SerializeField] private float leftFlagPositon;
    [SerializeField] private float rightFlagPositon;


    [SerializeField] public bool _isLeft;

    public bool _isPatrol;
    private Transform _transform;
    private GameObject _player;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        
        if (_isLeft & _isPatrol == true)
        {
            transform.position -= Vector3.left * _speed * Time.deltaTime;
        }
        else if (!_isLeft & _isPatrol == true)
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
        if (!_isLeft)
            transform.Rotate(0,180 , 0);
        else
            transform.Rotate(0, -180, 0);
    }
}
