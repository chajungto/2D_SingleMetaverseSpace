using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBase : MonoBehaviour
{
    protected virtual void Start()
    {
        InitScene();
    }

    protected virtual void InitScene()
    {
        GameManager.Instance.currentScene = this;
    }

    //MainScene
    public bool isAbleToTalk = false;                               //��ȭ ���� ����

    public List<GameObject> npcPanel = new List<GameObject>();      //NPC Panel ����Ʈ


}
