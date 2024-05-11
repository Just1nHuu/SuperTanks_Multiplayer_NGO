using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;

public class CharacterSelectReady : NetworkBehaviour
{
    public static CharacterSelectReady Instance { get; private set; }

    private Dictionary<ulong, bool> playerReadyDictionary;

    private void Awake()
    {

        Instance = this;
        playerReadyDictionary = new Dictionary<ulong, bool>();
        Debug.Log("CharacterSelectReady Awake");
    }

    public void SetPlayerReady()
    {
        Debug.Log("Set player ready");
        SetPlayerReadyServerRpc();
    }


    [ServerRpc(RequireOwnership = false)]
    private void SetPlayerReadyServerRpc(ServerRpcParams serverRpcParams = default)
    {
        Debug.Log("Set player ready");
        playerReadyDictionary[serverRpcParams.Receive.SenderClientId] = true;
        Debug.Log("Player ready: " + serverRpcParams.Receive.SenderClientId);
        bool allClientsReady = true;
        foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds)
        {
            if (!playerReadyDictionary.ContainsKey(clientId) || !playerReadyDictionary[clientId])
            {
                allClientsReady = false;
                break;
            }
        }

        if (allClientsReady)
        {
            Loader.LoadNetwork(Loader.Scene.GameScene);
        }
        Debug.Log("All players ready: " + allClientsReady);
    }

}
