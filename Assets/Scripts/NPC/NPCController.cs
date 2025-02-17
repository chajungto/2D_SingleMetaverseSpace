using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCController : MonoBehaviour
{
    //감지 범위
    public float radius = 1f;

    //플레이어 잡을 레이어
    public LayerMask layer;

    //감지될 player 콜라이더
    public Collider2D playerCollider;

    //NPC가 가지고 있는 정보 스크립터블 오브젝트
    public NPCInfo npcInfo;

    //NPC 이름표
    [SerializeField]
    private GameObject nameTag;

    //말 걸기 패널
    [SerializeField]
    private GameObject tryTalkPanel;

    //대화가 나올 UI 패널
    [SerializeField]
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
