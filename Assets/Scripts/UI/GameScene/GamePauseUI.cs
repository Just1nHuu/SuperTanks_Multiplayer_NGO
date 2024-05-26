using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainmenuButton;

    private void Awake()
    {
       resumeButton.onClick.AddListener(() =>
       {
           SuperTanksGameManager.Instance.TogglePauseGame();
       });
       mainmenuButton.onClick.AddListener(() =>
       {
           SuperTanksLobby.Instance.LeaveLobby();
           NetworkManager.Singleton.Shutdown();
           Loader.Load(Loader.Scene.MainMenuScene);
       });
    }
    private void Start()
    {
        SuperTanksGameManager.Instance.OnLocalGamePaused += SuperTanksGameManager_OnLocalGamePaused;
        SuperTanksGameManager.Instance.OnLocalGameUnPaused += SuperTanksGameManager_OnLocalGameUnPaused;
        Hide();
    }

    private void SuperTanksGameManager_OnLocalGameUnPaused(object sender, EventArgs e)
    {
        Hide();
    }

    private void SuperTanksGameManager_OnLocalGamePaused(object sender, EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
