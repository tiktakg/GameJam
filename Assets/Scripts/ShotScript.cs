using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBullet;
    [SerializeField] private GameObject _spawnPointBullet;
    [SerializeField] private bool _isHaveGun = false;

    public int _spawnBullet;
 
   
    void Update()
    {
        if (Input.GetMouseButtonUp(0) & _spawnBullet < 5)
        {
            GameObject bullet = Instantiate(_prefabBullet);
            bullet.transform.localPosition = _spawnPointBullet.transform.position;
            _spawnBullet += 1;
        }

    }
}
