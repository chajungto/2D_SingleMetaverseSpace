using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBase : MonoBehaviour
{
    //MainScene
    public bool isAbleToTalk = false;                               //��ȭ ���� ����

    public List<GameObject> npcPanel = new List<GameObject>();      //NPC Panel ����Ʈ


    //FindErrorGameScene

    public GameObject StartPanel;               //���� �г�

    public GameObject EndPanel;                 //���� �г�

    public GameObject DescriptionPanel;         //���� �г�

    public int score = 0;                           //����


    //Flappy
    public GameObject flappyStartPanel;

    public GameObject flappyEndPanel;

}
