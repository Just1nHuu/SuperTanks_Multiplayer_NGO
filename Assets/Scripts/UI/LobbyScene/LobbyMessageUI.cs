using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class LobbyMessageUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(() => Hide());
    }

    private void Start()
    {
        SuperTanksMultiplayer.Instance.OnFailedToJoinGame += SuperTanksMultiplayer_OnFailedToJoinGame;
        SuperTanksLobby.Instance.OnCreateLobbyStarted += SuperTanksLobby_OnCreateLobbyStarted;
        SuperTanksLobby.Instance.OnCreateLobbyFailed += SuperTanksLobby_OnCreateLobbyFailed;
        SuperTanksLobby.Instance.OnQuickJoinFailed += SuperTanksLobby_OnQuickJoinFailed;
        SuperTanksLobby.Instance.OnJoinFailed += SuperTanksLobby_OnJoinFailed;
        SuperTanksLobby.Instance.OnJoinStarted += SuperTanksLobby_OnJoinStarted;

        Hide();
    }

    private void SuperTanksLobby_OnCreateLobbyStarted(object sender, EventArgs e)
    {
        ShowMessage("Creating Lobby...");
    }
    private void SuperTanksLobby_OnCreateLobbyFailed(object sender, EventArgs e)
    {
        ShowMessage("Failed to create Lobby!");
    }
    private void SuperTanksLobby_OnQuickJoinFailed(object sender, EventArgs e)
    {
        ShowMessage("Could not find a Lobby to Quick Join !");
    }
    private void SuperTanksLobby_OnJoinFailed(object sender, EventArgs e)
    {
        ShowMessage("Failed to join Lobby!");
    }
    private void SuperTanksLobby_OnJoinStarted(object sender, EventArgs e)
    {
        ShowMessage("Joining Lobby ... ");
    }
    private void SuperTanksMultiplayer_OnFailedToJoinGame(object sender, EventArgs e)
    {
        if(NetworkManager.Singleton.DisconnectReason=="")
        {
            ShowMessage("Failed to connect");
        }
        else
        {
            ShowMessage(NetworkManager.Singleton.DisconnectReason);
        }   
    }

    private void ShowMessage(string message)
    {
        Show();

        messageText.text = message;
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        SuperTanksMultiplayer.Instance.OnFailedToJoinGame -= SuperTanksMultiplayer_OnFailedToJoinGame;
    }
}
