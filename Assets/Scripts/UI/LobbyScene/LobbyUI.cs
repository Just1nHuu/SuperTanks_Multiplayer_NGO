using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;
using static SuperTanksLobby;

public class LobbyUI : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button createLobbyButton;
    [SerializeField] private Button quickJoinButton;
    [SerializeField] private Button joinCodeButton;
    [SerializeField] private TMP_InputField joinCodeInputField;
    [SerializeField] private TMP_InputField playerNameInputField;
    [SerializeField] private LobbyCreateUI lobbyCreateUI;
    [SerializeField] private Transform lobbyContainer;
    [SerializeField] private Transform lobbyTemplate; 

    private void Awake()
    {
        mainMenuButton.onClick.AddListener(() =>
        {
            SuperTanksLobby.Instance.LeaveLobby();
            Loader.Load(Loader.Scene.MainMenuScene);
        });
        createLobbyButton.onClick.AddListener(() =>
        {
            lobbyCreateUI.Show();
            //SuperTanksLobby.Instance.CreateLobby("LobbyName", false);
        });
        quickJoinButton.onClick.AddListener(() =>
        {
            SuperTanksLobby.Instance.QuickJoin();
        });
        joinCodeButton.onClick.AddListener(() =>
        {
            SuperTanksLobby.Instance.JoinWithCode(joinCodeInputField.text);
        });

        lobbyTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        playerNameInputField.text = SuperTanksMultiplayer.Instance.GetPlayerName();
        playerNameInputField.onEndEdit.AddListener((string playerName) =>
        {
            SuperTanksMultiplayer.Instance.SetPlayerName(playerName);
        });

        SuperTanksLobby.Instance.OnLobbyListChanged += SuperTanksLobby_OnLobbyListChanged;
        UpdateLobbyList(new List<Lobby>());
    }

    private void SuperTanksLobby_OnLobbyListChanged(object sender, SuperTanksLobby.OnLobbyListChangedEventArgs e)
    {
        UpdateLobbyList(e.lobbyList);
    }

    private void UpdateLobbyList(List<Lobby> lobbyList)
    {
        foreach(Transform child in lobbyContainer)
        {
            if(child == lobbyTemplate) continue;
            Destroy(child.gameObject);
        }
        foreach(Lobby lobby in lobbyList)
        {
            Transform lobbyTransform = Instantiate(lobbyTemplate, lobbyContainer);
            lobbyTransform.gameObject.SetActive(true);
            lobbyTransform.GetComponent<LobbyListSingletonUI>().SetLobby(lobby);
        }
    }
    private void OnDestroy()
    {
        SuperTanksLobby.Instance.OnLobbyListChanged -= SuperTanksLobby_OnLobbyListChanged;

    }
}
