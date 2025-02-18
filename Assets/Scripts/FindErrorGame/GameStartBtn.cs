using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartBtn : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1f;
        FindErrorGameManager.Instance.StartPanel.SetActive(false);
        Debug.Log("Ω√¿€");
    }
}
