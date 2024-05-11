using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionResponseMessageUI : MonoBehaviour
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

        Hide();
    }

    private void SuperTanksMultiplayer_OnFailedToJoinGame(object sender, EventArgs e)
    {
        Show();

        messageText.text = NetworkManager.Singleton.DisconnectReason;

        if(messageText.text == "")
        {
            messageText.text = "Failed to join game";
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

    private void OnDestroy()
    {
        SuperTanksMultiplayer.Instance.OnFailedToJoinGame -= SuperTanksMultiplayer_OnFailedToJoinGame;
    }
}
