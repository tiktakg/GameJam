using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Transform))]

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private UiSrcipt _uiPanel;

    [SerializeField] private float _velcotiy = 1;
    [SerializeField] private float _jumpforse = 1;

    public bool _isLeft = false;
    [SerializeField] public bool _isLife = false;
    

    private Transform _transform;
    private GameObject _enemyObject;
    
    private float _TimeLifeEnemy;

  

    private void Start()
    {
        _uiPanel = GameObject.FindFirstObjectByType<UiSrcipt>();
        _transform = GetComponent<Transform>();


        _isLeft = true;

        if (_isLeft)
            transform.Rotate(0, 0, 0);
        else if(!_isLeft)
            transform.Rotate(0, -180, 0);

    }


    private void FixedUpdate()
    {
        MovePlayere();


        _TimeLifeEnemy -= Time.deltaTime;

        if (_uiPanel._isGameTurn == true)
        {
            _uiPanel.TimePanel.value -=Time.deltaTime;
        }


        if ((_TimeLifeEnemy <= -20) & _velcotiy == 5)
        {
            _uiPanel._isGameTurn = false;
            Vector3 position = gameObject.transform.position;
            Destroy(gameObject);
            Instantiate(Resources.Load("Player"), position, Quaternion.identity);
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy" & Input.GetKey(KeyCode.E))
        {
            setNewPlayer(other);
        }
    }

    private void setNewPlayer(Collider2D other)
    {

        Destroy(gameObject);

        _enemyObject = other.gameObject;
        _enemyObject.GetComponent<EnemyScript>()._isPatrol = false;

        ShotScript _shotScript = _enemyObject.gameObject.GetComponent<ShotScript>();
        EnemyScript enemyScript= _enemyObject.gameObject.GetComponent<EnemyScript>();
        
        MovePlayer _movePlayer = _enemyObject.gameObject.AddComponent<MovePlayer>();


        _shotScript._prefabBullet = enemyScript._prefabBullet;
        _shotScript._spawnPointBullet = enemyScript._spawnPointBullet;

        _shotScript.isShootPlayer = true;
        _shotScript.enabled = true;

        _movePlayer._velcotiy = 5;
        _movePlayer._isLeft = true;
        _movePlayer._isLife = true;

        if (!_isLeft)
            _enemyObject.transform.Rotate(0, 0, 0);
        else if (_isLeft)
            _enemyObject.transform.Rotate(0, -180, 0);

        _enemyObject.tag = "Player";
      

        _uiPanel._isGameTurn = true;
        _TimeLifeEnemy = 10f;
    }
    private void MovePlayere()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * _velcotiy * _jumpforse * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.up * _velcotiy * _jumpforse * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (_isLeft != false )
            {
                transform.Rotate(0, 180, 0);
                _isLeft = false;
            }

            transform.position += Vector3.left * _velcotiy * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (_isLeft != true )
            {
                transform.Rotate(0, -180, 0);
                _isLeft = true;
            }

            transform.position -= Vector3.left * _velcotiy * Time.deltaTime;
        }
    }









}
