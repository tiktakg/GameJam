using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class moveCamera : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Transform _transfrom;

    private void Start()
    {
        //GameObject g =  GameObject.FindFirstObjectByType<MovePlayer>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _transfrom = GetComponent<Transform>();
    }

   
    private void Update()
    {
        if(_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }
            
        _transfrom.position = new Vector3(_player.transform.position.x, _player.transform.position.y, -10);
    }



}
