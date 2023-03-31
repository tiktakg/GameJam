using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class ControlSript : MonoBehaviour
{
    private TMP_Text text; 

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }


    void Update()
    {
        text.text = TakeCountEnemy().ToString();
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
