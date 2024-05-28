using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class RoomPlayer : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    [SerializeField] private GameObject readyGameObject;
    [SerializeField] private TextMeshPro playerNameText;
    private void Start()
    {
        SuperTanksMultiplayer.Instance.OnDataNetworkListChanged += SuperTanksMultiplayer_OnDataNetworkListChanged;
        RoomReady.Instance.OnReadyChanged += RoomReady_OnReadyChanged;
        UpdatePlayer();
    }

    private void RoomReady_OnReadyChanged(object sender, EventArgs e)
    {
        UpdatePlayer();
    }

    private void SuperTanksMultiplayer_OnDataNetworkListChanged(object sender, EventArgs e)
    {
        UpdatePlayer();
    }

    private void UpdatePlayer()
    {
        if(SuperTanksMultiplayer.Instance.IsPlayerIndexConnected(playerIndex))
        {
            Show();

            PlayerData playeData = SuperTanksMultiplayer.Instance.GetPlayerDataFromPlayeIndex(playerIndex);
            readyGameObject.SetActive(RoomReady.Instance.IsPlayerReady(playeData.clientId));
            Debug.Log(RoomReady.Instance.IsPlayerReady(playeData.clientId));
            playerNameText.text = playeData.playerName.ToString();   
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
