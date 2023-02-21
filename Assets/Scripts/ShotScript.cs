using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    [SerializeField] public GameObject _prefabBullet;
    [SerializeField] public GameObject _spawnPointBullet;
    [SerializeField] public bool _isHaveGun = false;

    public int _spawnBullet;
 
   
    void Update()
    {
        if (Input.GetMouseButtonUp(0) & _spawnBullet < 10)
        {
            GameObject bullet = Instantiate(_prefabBullet);
            bullet.transform.localPosition = _spawnPointBullet.transform.position;
            _spawnBullet += 1;
        }

    }
}
