using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRobot : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _transform;
    [SerializeField] private int t = 0;
    [SerializeField] private BoxCollider2D box;
    void Start()
    {
        _transform = GetComponent<Transform>();
        box= GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.left * t * Time.deltaTime;

      
        
    }
}
