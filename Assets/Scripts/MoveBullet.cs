using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class MoveBullet : MonoBehaviour
{

    [SerializeField] private float _speed;

    public bool isFlyRightPlayer = true;
    public bool isFlyRightEnemy = true;
    [SerializeField] public bool isShootPlayer;
    [SerializeField] public bool isShootEnemy;

    public Rigidbody2D rb;
  
    private ShotScript _shotPlayer;
    private MovePlayer _movePlayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       

        _shotPlayer = GameObject.FindFirstObjectByType<ShotScript>();
        _movePlayer = GameObject.FindFirstObjectByType<MovePlayer>();
        isFlyRightPlayer = _movePlayer._isLeft;
       
    }


    private void Update()
    {


        Vector3 _vector = new Vector3(0, 0, 0);
        if (isShootPlayer)
        {
            if (isFlyRightPlayer)
                _vector = new Vector3(_speed * Time.deltaTime, 0, 0);
            else if (!isFlyRightPlayer)
                _vector = new Vector3(-_speed * Time.deltaTime, 0, 0);
        }
        else if (!isShootPlayer)
        {
            if (isFlyRightEnemy)
                _vector = new Vector3( _speed * Time.deltaTime, 0, 0);
            else if (!isFlyRightEnemy)
                _vector = new Vector3(-_speed * Time.deltaTime, 0, 0);
        }


        rb.velocity = _vector;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.tag == "Ground")
        {
            Destroy(gameObject);
            _shotPlayer._spawnBullet -= 1;
        }

        if ((collision.tag == "Enemy" & isShootPlayer))
        {
            Destroy(gameObject);
            _shotPlayer._spawnBullet -= 1;

            collision.gameObject.GetComponent<EnemyScript>()._helth--;
           
        }
        else if(collision.tag == "Player" &  !isShootPlayer)
        {
            Destroy(gameObject);
            _shotPlayer._spawnBullet -= 1;
            collision.gameObject.GetComponent<EnemyScript>()._helth--;
        }
        else if (collision.tag == "Player" & isShootEnemy)
        {
            Destroy(gameObject);
            _shotPlayer._spawnBullet -= 1;
            collision.gameObject.GetComponent<EnemyScript>()._helth--;
        }



    }

}
