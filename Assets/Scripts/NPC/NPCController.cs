using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCController : MonoBehaviour
{
    public float radius = 1f;           //감지 범위

    public LayerMask layer;             //플레이어 잡을 레이어

    public Collider2D playerCollider;   //감지될 player 콜라이더

    public NPCInfo npcInfo;             //NPC가 가지고 있는 정보 스크립터블 오브젝트

    [SerializeField]                    //NPC 이름표
    private GameObject nameTag;

    [SerializeField]                    //말 걸기 패널
    private GameObject tryTalkPanel;

    [SerializeField]                    //대화가 나올 UI 패널
    public GameObject scriptPanel;

    
    void Start()
    {
        nameTag.GetComponent<SpriteRenderer>().sprite = npcInfo.NpcSprtie;
    }


    void Update()
    {
        playerCollider = Physics2D.OverlapCircle(transform.position, radius, layer);
        if(playerCollider != null)
        {
            Debug.Log("플레이어 감지");
            tryTalkPanel.SetActive(true);
        }
        else
        {
            tryTalkPanel.SetActive(false);
        }

        if(tryTalkPanel.activeSelf)
        {
            GameManager.Instance.isAbleToTalk = true;
        }

    }

    //반경 그리기(red)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
