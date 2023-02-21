using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class EnemyScript : MonoBehaviour
{
    [SerializeField] public GameObject _prefabBullet;
    [SerializeField] public GameObject _spawnPointBullet;
    [SerializeField] public GameObject _checkPlayerPoint;

    [SerializeField] public float _speed = 1;
    
    [SerializeField] private float leftFlagPositon;
    [SerializeField] private float rightFlagPositon;


    [SerializeField] private bool _isLeft;

    private Transform _transform;
    private GameObject _player;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        Debug.Log("p" + _player.transform.localPosition.x);
        Debug.Log( "c" + _checkPlayerPoint.transform.position.x);;
 
        if (_checkPlayerPoint.transform.localPosition.x < _player.transform.localPosition.x)
        {
            Debug.Log("1");
        }

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
