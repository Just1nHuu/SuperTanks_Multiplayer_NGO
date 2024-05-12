using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CharacterSelectPlayer : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    private void Start()
    {
        SuperTanksMultiplayer.Instance.OnDataNetworkListChanged += SuperTanksMultiplayer_OnDataNetworkListChanged;
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
