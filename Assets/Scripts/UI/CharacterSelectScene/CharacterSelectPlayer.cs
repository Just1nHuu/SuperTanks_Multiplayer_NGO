using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class CharacterSelectPlayer : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    [SerializeField] private GameObject readyGameObject;
    [SerializeField] private TextMeshPro playerNameText;
    private void Start()
    {
        SuperTanksMultiplayer.Instance.OnDataNetworkListChanged += SuperTanksMultiplayer_OnDataNetworkListChanged;
        CharacterSelectReady.Instance.OnReadyChanged += CharacterSelectReady_OnReadyChanged;
        UpdatePlayer();
    }

    private void CharacterSelectReady_OnReadyChanged(object sender, EventArgs e)
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
            readyGameObject.SetActive(CharacterSelectReady.Instance.IsPlayerReady(playeData.clientId));
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
