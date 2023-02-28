using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    [SerializeField] public GameObject _prefabBullet;
    [SerializeField] public GameObject _spawnPointBullet;
    [SerializeField] public bool _isHaveGun = false;

    public int _spawnBullet;
    public bool isShootPlayer = false;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) & _spawnBullet < 10 & isShootPlayer == true)
        {
            ShootPlayer();
        }


    }

    public void ShootPlayer()
    {
        GameObject bullet = Instantiate(_prefabBullet, new Vector3(_spawnPointBullet.transform.position.x, _spawnPointBullet.transform.position.y, 0), Quaternion.identity);
        bullet.GetComponent<MoveBullet>().isShootPlayer = true;
        _spawnBullet += 1;
    }
    public void ShootEnemy(bool isLeft)
    {
        GameObject bullet = Instantiate(_prefabBullet, new Vector3(_spawnPointBullet.transform.position.x, _spawnPointBullet.transform.position.y, 0), Quaternion.identity);
        bullet.GetComponent<MoveBullet>().isShootPlayer = false;
        bullet.GetComponent<MoveBullet>().isFlyRightEnemy = isLeft;
        _spawnBullet += 1;
    }
    

}
