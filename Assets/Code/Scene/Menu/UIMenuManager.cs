using System;
using System.Collections;
using UnityEngine;

public class UIMenuManager : MonoBehaviour
{

    [SerializeField]
    private VoidEventChannelSO _startNewGameEventChannel;
    [SerializeField]
    private VoidEventChannelSO _countinueGameEventChannel;

    [SerializeField]
    private UIMenu _mainMenuPannel;

    private void Start()
    {
        SetMainMenu();
    }

    //private IEnumerable Start() {
    //   yield return new WaitForSeconds(0.4f);

    //}

    private void SetMainMenu()
    {
        _mainMenuPannel.NewGameButtonAction += StartNewGame;
        _mainMenuPannel.SettingsButtonAction += OpenSettingPannel;
        _mainMenuPannel.ExitButtonAction += Exit;
    }

    private void Exit()
    {

    }

    private void OpenSettingPannel()
    {
         
    }

    private void StartNewGame()
    {
        Debug.Log("Start_Game");
    }
}
