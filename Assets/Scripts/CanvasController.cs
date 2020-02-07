using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : Singleton<CanvasController>
{
    public enum CanvasState {playLevel,endLevel}
    public GameObject EndLevelPanel;
    public GameObject RestartButton;

    private void Start()
    {
        ChangeCanvasState(CanvasState.playLevel);
        PlayerData.PlayerWin += PlayerData_PlayerWin;
        Restarter.Restart += Restarter_Restart;
    }

    private void Restarter_Restart(object sender, System.EventArgs e)
    {
        ChangeCanvasState(CanvasState.playLevel);
    }
    private void PlayerData_PlayerWin(object sender, System.EventArgs e)
    {
        ChangeCanvasState(CanvasState.endLevel);
    }

    public void ChangeCanvasState(CanvasState canvasState)
    {
        switch (canvasState)
        {
            case CanvasState.playLevel:
                EndLevelPanel.SetActive(false);
                RestartButton.SetActive(true);
                break;
            case CanvasState.endLevel:
                EndLevelPanel.SetActive(true);
                RestartButton.SetActive(false);
                break;
        }
    }
}
