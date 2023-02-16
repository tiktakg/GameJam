using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiSrcipt : MonoBehaviour
{
    [SerializeField] public GameObject _panelUI;
    [SerializeField] public bool _isPanelTurn = false;

    private void Start()
    {
       _panelUI.SetActive(false);
    }
    private void FixedUpdate()
    {

        _panelUI.SetActive(_isPanelTurn);

    }
}
