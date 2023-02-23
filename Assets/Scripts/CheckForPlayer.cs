using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckForPlayer : MonoBehaviour
{

    [SerializeField] private GameObject _enemyObject;


    private GameObject _playerObject;

    private ShotScript _shotScript;
    private EnemyScript _enemyScript;

    
    private bool _isSeePlayer = false;

    private float _enemyPostion;
    private float _playerPostion;
    private float _time;

    private Vector3 _vectorPos = new Vector3();

    private void Start()
    {
        _enemyObject.gameObject.GetComponent<EnemyScript>();

        _shotScript = _enemyObject.gameObject.AddComponent<ShotScript>();
        _enemyScript = _enemyObject.gameObject.gameObject.GetComponent<EnemyScript>();

        _shotScript._prefabBullet = _enemyScript._prefabBullet;
        _shotScript._spawnPointBullet = _enemyScript._spawnPointBullet;

    }

    private void Update()
    {
        _enemyPostion = _enemyObject.transform.localPosition.x;
        _playerPostion = _playerObject.transform.localPosition.x;

        _vectorPos = new Vector3(_enemyObject.transform.localPosition.x, _enemyObject.transform.localPosition.y, _enemyObject.transform.localPosition.z);

        _time += Time.deltaTime;

        if (_isSeePlayer)
        {

            if ((_time % 2) < 0.01)
            {
                _shotScript.Shoot();
            }


            if (_enemyPostion > _playerPostion)
            {

                _vectorPos = new Vector3(_enemyPostion - 0.003f, _enemyObject.transform.localPosition.y, _enemyObject.transform.localPosition.z);
            }
            else if (_enemyPostion < _playerPostion)
            {
                _vectorPos = new Vector3(_enemyPostion + 0.003f, _enemyObject.transform.localPosition.y, _enemyObject.transform.localPosition.z);
            }

            if (_enemyPostion != _playerPostion)
            {
                _enemyObject.transform.position = _vectorPos;
            }

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _fightWithPlayer(collision, false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _fightWithPlayer(collision, true);
        }
    }
    private void _fightWithPlayer(Collider2D collision, bool _seePlayer)
    {
        _playerObject = collision.gameObject;
        _isSeePlayer = !_seePlayer;
        _enemyObject.gameObject.GetComponent<EnemyScript>()._isPatrol = _seePlayer;
    }
}

