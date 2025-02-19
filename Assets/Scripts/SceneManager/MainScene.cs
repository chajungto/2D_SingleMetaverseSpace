using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : SceneBase
{
    //public List<GameObject> npcPanel = new List<GameObject>();      //NPC Panel ����Ʈ

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
