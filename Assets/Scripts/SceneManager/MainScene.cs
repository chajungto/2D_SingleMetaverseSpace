using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : SceneBase
{
    void Start()
    {
        Time.timeScale = 1.0f;
        InitScene();
    }

    void InitScene()
    {
        GameManager.Instance.currentScene = this;
    }
}
