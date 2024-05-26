using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class HostDisconnectUI : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;
    private bool isServerAcceptingConnections = true;


    private void Awake()
    {
        playAgainButton.onClick.AddListener(() =>
        {
            SuperTanksLobby.Instance.LeaveLobby();
            NetworkManager.Singleton.Shutdown();
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    private void Start()
    {
        NetworkManager.Singleton.OnClientDisconnectCallback += NetworkManager_OnClientDisconnectCallback;

        Hide();
    }

    private void NetworkManager_OnClientDisconnectCallback(ulong clientId)
    {
        if (clientId == NetworkManager.Singleton.LocalClientId)
        {
            Show();
        }
        Debug.Log("The client disconnected: " + clientId);
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
