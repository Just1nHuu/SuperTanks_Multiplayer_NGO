using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class SuperTanksMultiplayer : MonoBehaviour
{
    public static SuperTanksMultiplayer Instance { get; private set; }
    private bool isNotConnected = false;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartHost()
    {
        NetworkManager.Singleton.ConnectionApprovalCallback += NetworkManager_ConnectionApprovalCallback;
        NetworkManager.Singleton.StartHost();
    }

    private void NetworkManager_ConnectionApprovalCallback(NetworkManager.ConnectionApprovalRequest connectionApprovalRequest, NetworkManager.ConnectionApprovalResponse connectionApprovalResponse)
    {
            connectionApprovalResponse.Approved = true;
    }

    public bool isCheckiNotConnected()
    {
        return isNotConnected;
    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();   
    }
}
