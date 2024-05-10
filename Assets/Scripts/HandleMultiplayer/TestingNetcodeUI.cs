    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class TestingNetcodeUI : MonoBehaviour
{
    [SerializeField] private Button startHostButton;
    [SerializeField] private Button startClientButton;

    private void Awake()
    {
        startClientButton.onClick.AddListener(() =>
        {
            Debug.Log("Client");
            SuperTanksMultiplayer.Instance.StartClient();
            Hide();
        });

        startHostButton.onClick.AddListener(() =>
        {
            Debug.Log("Host");
            SuperTanksMultiplayer.Instance.StartHost();
            Hide();
        });
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
