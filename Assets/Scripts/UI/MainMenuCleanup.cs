using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenuCleanup : MonoBehaviour
{
    private void Awake()
    {
        if (NetworkManager.Singleton != null)
        {
            Destroy(NetworkManager.Singleton.gameObject);
        }

        if (SuperTanksMultiplayer.Instance != null)
        {
            Destroy(SuperTanksMultiplayer.Instance.gameObject);
        }

        if (SuperTanksLobby.Instance != null)
        {
            Destroy(SuperTanksLobby.Instance.gameObject);
        }
    }
}
