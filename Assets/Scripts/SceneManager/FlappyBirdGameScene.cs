using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdGameScene : SceneBase
{
    void Start()
    {
        InitScene();
    }

    void InitScene()
    {
        GameManager.Instance.currentScene = this;
    }
}
