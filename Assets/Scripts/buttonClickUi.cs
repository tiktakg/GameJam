using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonClickUi : MonoBehaviour
{
    [SerializeField] private int _numberScene;
    public void buttonStart()
    {
        SceneManager.LoadScene(_numberScene);
    }
}
