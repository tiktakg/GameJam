using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckForPlayer : MonoBehaviour
{

    [SerializeField] public Animator anim;
    [SerializeField] private GameObject _enemyObject;
    [SerializeField] private float _speedFolow;
    [SerializeField] private bool _isLeft = false;

    [SerializeField] private bool[] _MethodAattakEnemy;

    [SerializeField] private float _distanceToAttack = 0.05f;

    private GameObject _playerObject;
    private ShotScript _shotScript;
    private EnemyScript _enemyScript;



    [SerializeField] private bool _isSeePlayer = false;

    private float _enemyPostion;
    private float _playerPostion;
    private float _time;
    private int I = 0;


    private Vector3 _vectorPos = new Vector3();

    private void Start()
    {
        _enemyObject.gameObject.GetComponent<EnemyScript>();
        anim = GetComponent<Animator>();

        _shotScript = _enemyObject.gameObject.AddComponent<ShotScript>();
        _enemyScript = _enemyObject.gameObject.GetComponent<EnemyScript>();


        _shotScript._prefabBullet = _enemyScript._prefabBullet;
        _shotScript._spawnPointBullet = _enemyScript._spawnPointBullet;

        _shotScript.enabled = false;

    }

    private void Update()
    {
        _enemyPostion = _enemyObject.transform.localPosition.x;
        _playerPostion = _playerObject.transform.localPosition.x;

       

        _time += Time.deltaTime;

        if (_isSeePlayer)
        {

            _folowForPlayer();
            _Attack();



        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<MovePlayer>()._isLife == true)
            {
                _playerObject = other.gameObject;
                _shotScript.enabled = true;
                _fightWithPlayer(other, false);
            }
        }
    }

    private void _fightWithPlayer(Collider2D collision, bool _seePlayer)
    {

        _isSeePlayer = !_seePlayer;
        _enemyObject.gameObject.GetComponent<EnemyScript>()._isPatrol = _seePlayer;
    }


    private void _folowForPlayer()
    {
        if (_enemyPostion >= _playerPostion)
        {
            Debug.Log("Left");
            _enemyScript._isLeft = 0;

        }
        else if (_enemyPostion <= _playerPostion)
        {
            Debug.Log("right");

            _enemyScript._isLeft = 1;
        }
    }

    private void _Attack()
    {
        if (_MethodAattakEnemy[0])
        {
            if ((_time % 2) < 0.01)
            {
                _shotScript.isShootPlayer = false;
                _shotScript.isShootEnemy = true;
                _shotScript.ShootEnemy(!_isLeft);
            }
        }
        else if (_MethodAattakEnemy[1])
        {

            if (_playerPostion < (_enemyPostion + _distanceToAttack) & !_isLeft)
            {
                Destroy(_enemyObject);
                _playerObject.gameObject.GetComponent<EnemyScript>()._helth = 0;
            }
            else if (_playerPostion > (_enemyPostion - _distanceToAttack) & _isLeft)
            {
                Destroy(_enemyObject);
                _playerObject.gameObject.GetComponent<EnemyScript>()._helth = 0;

            }
        }
        else if (_MethodAattakEnemy[2])
        {
            if (_playerPostion < (_enemyPostion + _distanceToAttack) & !_isLeft)
            {
                _enemyScript._anim.Play("VitaliaAtakyet");

                if ((_time % 2) < 0.01)
                    _playerObject.gameObject.GetComponent<EnemyScript>()._helth -= 1;
            }
            else if (_playerPostion > (_enemyPostion - _distanceToAttack) & _isLeft)
            {
                _enemyScript._anim.Play("VitaliaAtakyet");

                if ((_time % 2) < 0.01)
                    _playerObject.gameObject.GetComponent<EnemyScript>()._helth -= 1;


            }
            else
                _enemyScript._anim.Play("VitalyBechit");

        }

    }

}


