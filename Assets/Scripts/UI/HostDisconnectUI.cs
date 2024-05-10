using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class HostDisconnectUI : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;

    private void Start()
    {
        NetworkManager.Singleton.OnClientDisconnectCallback += NetworkManager_OnClientDisconnectCallback;

        Hide();
    }
    private void NetworkManager_OnClientDisconnectCallback(ulong clientId)
    {
        Debug.Log("clientId: " + clientId + " ServerClientId: " + NetworkManager.ServerClientId);
        if (clientId != NetworkManager.ServerClientId)
        {
            Debug.Log("HostDisconnectUI: NetworkManager_OnClientDisconnectCallback");
            Show();
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
