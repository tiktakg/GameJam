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

    private float y;
    private void Start()
    {
        _transform = GetComponent<Transform>();
        _shotPlayer = GameObject.FindFirstObjectByType<ShotScript>();
        _movePlayer = GameObject.FindFirstObjectByType<MovePlayer>();
        isFlyRight = _movePlayer._isLeft;
        y = _transform.position.y;
    }


    private void Update()
    {
        Vector3 _vector = new Vector3(transform.position.x + _speed * Time.deltaTime, y,0);
        if(isFlyRight)
            transform.position = _vector;
        else if(!isFlyRight)
            transform.position = _vector;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        _shotPlayer._spawnBullet -= 1;


    }

}
