using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class moveCamera : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Transform _transfrom;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _transfrom = GetComponent<Transform>();
    }

   
    void Update()
    {
        Vector3 vector = new Vector3(_player.transform.position.x, _player.transform.position.y,-10);

        _transfrom.position = vector;
    }
}
