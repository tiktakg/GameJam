using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSript : MonoBehaviour
{
    private int count;
    void Start()
    {
        GameObject[] enemyGameObject = GameObject.FindObjectsOfType<GameObject>();


        foreach (GameObject obj in enemyGameObject)
        {
            if (obj.tag == "Enemy")
            {
                count++;
            }
        }

    }


    void Update()
    {

        if (TakeCountEnemy() == 0)
        {
            Destroy(gameObject);
        }

    }

    int TakeCountEnemy()
    {
        GameObject[] enemyGameObject = GameObject.FindObjectsOfType<GameObject>();
        int count = 0;

        foreach (GameObject obj in enemyGameObject)
        {
            if (obj.tag == "Enemy")
            {
                count++;
            }
        }

        return count;
    }
}
