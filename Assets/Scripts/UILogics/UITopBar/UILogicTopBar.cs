using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogicTopBar : MonoBehaviour
{

    [SerializeField] private GameObject _canvasTopBar;
    [SerializeField] private GameObject _canvasSettings;

    private void Start()
    {
        Init();
    }

    private void Init()
    {

    }
    public void CanvasTopBarIsActiveTrue()
    {
        _canvasTopBar.SetActive(true);
    }
    public void CanvasTopBarIsActiveFalse()
    {
        _canvasTopBar.SetActive(false);
    }
    public void SettingsIsActiveTrue()
    {
        _canvasSettings.SetActive(true);
    }
    public void SettingsIsActiveFalse()
    {
        _canvasSettings.SetActive(false);
    }

}
