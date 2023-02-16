using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBullet;
    [SerializeField] private GameObject _spawnPointBullet;
    [SerializeField] private UiSrcipt _uiPanel;

    [SerializeField] private float _velcotiy = 1;
    [SerializeField] private float _jumpforse = 1;


    [SerializeField] bool _isLeft = false;
    [SerializeField] bool _isHaveGun = false;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _uiPanel = GameObject.FindFirstObjectByType<UiSrcipt>();

        transform.Rotate(0, 0, 0);

    }


    private void FixedUpdate()
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
            if (_isLeft != true)
            {
                transform.Rotate(0, 180, 0);
                _isLeft = true;
            }

            transform.position += Vector3.left * _velcotiy * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (_isLeft != false)
            {
                transform.Rotate(0, -180, 0);
                _isLeft = false;
            }
            transform.position -= Vector3.left * _velcotiy * Time.deltaTime;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //GameObject bullet = Instantiate(_prefabBullet);
            //bullet.transform.localPosition = _spawnPointBullet.transform.position;
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

        other.gameObject.AddComponent<MovePlayer>()._velcotiy = 5;
        other.tag = "Player";
        other.gameObject.GetComponent<EnemyPatrol>().enabled = false;

        _uiPanel._isPanelTurn = true;

        Time time;


        StartCoroutine(Timer(10f));
    }

    IEnumerator Timer(float time)
    {
        float currentTime = 0;

        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            Debug.Log("1");
            yield return null;
        }

    }
}
