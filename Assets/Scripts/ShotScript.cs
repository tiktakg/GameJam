using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    [SerializeField] public GameObject _prefabBullet;
    [SerializeField] public GameObject _spawnPointBullet;
    [SerializeField] public bool _isHaveGun = false;

    public int _spawnBullet;
 
   
    private void Update()
    {
        if (Input.GetMouseButtonUp(0) & _spawnBullet < 10)
        {
            Shoot();

        }

    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(_prefabBullet, new Vector3(_spawnPointBullet.transform.position.x, _spawnPointBullet.transform.position.y, 0), Quaternion.identity);
        _spawnBullet += 1;
    }

}
