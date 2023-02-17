using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveBullet : MonoBehaviour
{

    [SerializeField] private float _speed;

    public bool isFlyRight = true;

    private Transform _transform;
    private ShotScript _shotPlayer;
    private MovePlayer _movePlayer;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _shotPlayer = GameObject.FindFirstObjectByType<ShotScript>();
        _movePlayer = GameObject.FindFirstObjectByType<MovePlayer>();
        isFlyRight = _movePlayer._isLeft;
    }


    private void Update()
    {
        if(isFlyRight)
            transform.position += Vector3.right * _speed * Time.deltaTime;
        else if(!isFlyRight)
            transform.position += Vector3.left * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        _shotPlayer._spawnBullet -= 1;


    }

}
