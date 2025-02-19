using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFlappyGame : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.currentScene.flappyStartPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
