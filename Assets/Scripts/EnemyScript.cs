using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Transform))]

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private UiSrcipt _uiPanel;
    [SerializeField] public GameObject _prefabBullet;
    [SerializeField] public GameObject _spawnPointBullet;
    [SerializeField] public int _helth = 10;
    [SerializeField] public float _speed = 1;
    [SerializeField] public bool _IsShootEnemy;

    [SerializeField] private float leftFlagPositon;
    [SerializeField] private float rightFlagPositon;

    [SerializeField] public bool _isLeft;

    private bool _isLife = false;

    public bool _isPatrol;
    private Transform _transform;
    private int _baseHealth;

    private void Start()
    {
        _isLife = false;
        _transform = GetComponent<Transform>();
        _uiPanel = GameObject.FindFirstObjectByType<UiSrcipt>();
        _baseHealth = _helth;

    }
private void Update()
    {
        if (_helth <= 0 & gameObject.tag == "Player")
        {
            _uiPanel._isGameTurn =false;
            _uiPanel._iDeathTurn = true;
        }

        if (_helth <= 0)
        {
            Destroy(gameObject);
        }
            


        if (_helth ==  (_baseHealth * 3 / 4 ) & gameObject.tag == "Player")
            _uiPanel.numberSpriteFolHelthBar = 1;
        if (_helth == (_baseHealth * 2 / 4) & gameObject.tag == "Player")
            _uiPanel.numberSpriteFolHelthBar = 2;
        if (_helth == (_baseHealth * 1 / 4) & gameObject.tag == "Player")
            _uiPanel.numberSpriteFolHelthBar = 3;

        
            

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
        else if ((transform.localPosition.x <= leftFlagPositon) & _isLeft == false)
        {
            _isLeft = true;
            switchSight(_isLeft);
        }
    }

    public void switchSight(bool _isLeft)
    {
        if (!_isLeft & _isLeft == true)
            transform.Rotate(0, 180, 0);
        else
            transform.Rotate(0, -180, 0);
    }

}
