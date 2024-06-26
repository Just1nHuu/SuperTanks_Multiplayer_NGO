using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
 
    private void Start()
    {
        SuperTanksGameManager.Instance.OnLocalPlayerReadyChanged += SuperTanksGameManager_OnLocalPlayerReadyChanged;
        Show();
    }


    private void SuperTanksGameManager_OnLocalPlayerReadyChanged(object sender, System.EventArgs e)
    {
        if (SuperTanksGameManager.Instance.IsLocalPlayerReady())
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

