﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Transform))]

public class EnemyScript : MonoBehaviour
{
    [SerializeField] public GameObject _prefabBullet;
    [SerializeField] public GameObject _spawnPointBullet;
    [SerializeField] public int _helth = 10;
    [SerializeField] public float _speed = 1;
    [SerializeField] public bool _IsShootEnemy;

    [SerializeField] private float leftFlagPositon;
    [SerializeField] private float rightFlagPositon;

    [SerializeField] public int _isLeft;

    public Animator _anim;


    private Transform _transform;
    private UiGameSrcipt _uiPanel;

    public bool _isPatrol;
    private int _baseHealth;


    private void Start()
    {
        _transform = GetComponent<Transform>();
        _uiPanel = GameObject.FindFirstObjectByType<UiGameSrcipt>();
        _baseHealth = _helth;
        _anim = GetComponent<Animator>();


    }
    private void Update()
    {
        if (_helth <= 0 & gameObject.tag == "Player")
        {
            _uiPanel._isGameTurn = false;
            _uiPanel._iDeathTurn = true;
        }

        if (_helth <= 0)
        {
            Destroy(gameObject);
        }



        if (_helth <= (_baseHealth * 3 / 4) & gameObject.tag == "Player")
            _uiPanel.numberSpriteFolHelthBar = 1;
        if (_helth <= (_baseHealth * 2 / 4) & gameObject.tag == "Player")
            _uiPanel.numberSpriteFolHelthBar = 2;
        if (_helth <= (_baseHealth * 1 / 4) & gameObject.tag == "Player")
            _uiPanel.numberSpriteFolHelthBar = 3;



        if (_isLeft == 0)
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;

            if(transform.localEulerAngles !=  new Vector3(0, -180, 0))
            {
                transform.Rotate(0,0, 0);
            }
          
        }
        else if (_isLeft == 1)
        {
            transform.position -= Vector3.left * _speed * Time.deltaTime;

            if ((transform.localEulerAngles != new Vector3(0, 0, 0) ))
            {
                transform.Rotate(0, -180, 0);
            }
        }
    }



}
