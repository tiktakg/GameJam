using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGameSrcipt : MonoBehaviour
{
    [SerializeField] public Slider TimePanel;
    [SerializeField] public bool _isGameTurn = false;
    [SerializeField] public bool _iDeathTurn = false;

    [SerializeField] private GameObject _GamePanel;
    [SerializeField] private GameObject _DeathPanel;
    [SerializeField] private Sprite[] spriteForHealthBar;
    [SerializeField] private Image _helthBar;

    public int numberSpriteFolHelthBar;
    private void Start()
    {
        TimePanel.value = TimePanel.maxValue;
        _GamePanel.SetActive(false);
        _DeathPanel.SetActive(false);
    }
    private void Update()
    {
        _helthBar.sprite = spriteForHealthBar[numberSpriteFolHelthBar];

        _GamePanel.SetActive(_isGameTurn);
        _DeathPanel.SetActive(_iDeathTurn);

    }
}
