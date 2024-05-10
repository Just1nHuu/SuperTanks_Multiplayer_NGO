using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;

    private void Start()
    {
        SuperTanksGameManager.Instance.OnStageChanged += SuperTanksGameManager_OnStateChanged;
        Hide();
    }

    private void Awake()
    {
        playAgainButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.Shutdown();
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }
    private void SuperTanksGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (SuperTanksGameManager.Instance.isGameOver())
        {
            Show();
        }
        else
        {
            Hide();
        }
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
