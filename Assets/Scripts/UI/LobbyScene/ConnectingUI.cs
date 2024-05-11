using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectingUI : MonoBehaviour
{

    private void Start()
    {
        SuperTanksMultiplayer.Instance.OnTryingToJoinGame += SuperTanksMultiplayer_OnTryingToJoinGame;
        SuperTanksMultiplayer.Instance.OnFailedToJoinGame += SuperTanksMultiplayer_OnFailedToJoinGame;
        Hide();
    }

    private void SuperTanksMultiplayer_OnTryingToJoinGame(object sender, EventArgs e)
    {
        Show();
    }
    private void SuperTanksMultiplayer_OnFailedToJoinGame(object sender, EventArgs e)
    {
        Hide();
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
        SuperTanksMultiplayer.Instance.OnTryingToJoinGame -= SuperTanksMultiplayer_OnTryingToJoinGame;
        SuperTanksMultiplayer.Instance.OnFailedToJoinGame -= SuperTanksMultiplayer_OnFailedToJoinGame;
    }
   
}
