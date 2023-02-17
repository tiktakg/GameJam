using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private PlayerScript _playerObject;
    [SerializeField] private UiSrcipt _uiPanel;

    [SerializeField] private float _velcotiy = 1;
    [SerializeField] private float _jumpforse = 1;

    [SerializeField] public bool _isLeft = false;
    
    private Transform _transform;
    private GameObject _enemyObject;
    

    private float _TimeLifeEnemy;
    private float _currentTime;

    private bool _isLife = true;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _uiPanel = GameObject.FindFirstObjectByType<UiSrcipt>();
        _playerObject = GameObject.FindFirstObjectByType<PlayerScript>();



        if (_isLeft)
            transform.Rotate(0, 0, 0);
        else if(!_isLeft)
            transform.Rotate(0, -180, 0);

    }


    private void FixedUpdate()
    {
        MovePlayere();



        _TimeLifeEnemy -= Time.deltaTime;
        Debug.Log(_TimeLifeEnemy);


        if ((_TimeLifeEnemy <= -10))
        { 
           Instantiate(_playerObject,transform);
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
        _enemyObject.gameObject.AddComponent<MovePlayer>()._velcotiy = 5;
        _enemyObject.gameObject.AddComponent<ShotScript>();
        _enemyObject.tag = "Player";
        _enemyObject.gameObject.GetComponent<EnemyScript>().enabled = false;

        _uiPanel._isPanelTurn = true;
        _TimeLifeEnemy = 50f;
        _isLife = false;
    }
    private void MovePlayere()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * _velcotiy * _jumpforse * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) & transform.localPosition.y > -6)
        {
            transform.position -= Vector3.up * _velcotiy * _jumpforse * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (_isLeft != false)
            {
                transform.Rotate(0, 180, 0);
                _isLeft = false;
            }

            transform.position += Vector3.left * _velcotiy * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (_isLeft != true)
            {
                transform.Rotate(0, -180, 0);
                _isLeft = true;
            }
            transform.position -= Vector3.left * _velcotiy * Time.deltaTime;
        }
    }









}
