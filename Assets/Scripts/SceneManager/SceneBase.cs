using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBase : MonoBehaviour
{
    //MainScene
    public bool isAbleToTalk = false;                               //대화 가능 여부

    public List<GameObject> npcPanel = new List<GameObject>();      //NPC Panel 리스트


    //FindErrorGameScene

    public GameObject StartPanel;               //시작 패널

    public GameObject EndPanel;                 //종료 패널

    public GameObject DescriptionPanel;         //설명 패널

    public int score = 0;                           //점수


    //Flappy
    public GameObject flappyStartPanel;

    public GameObject flappyEndPanel;

}
