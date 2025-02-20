using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCController : MonoBehaviour
{
    public float radius = 1f;           //���� ����

    public LayerMask layer;             //�÷��̾� ���� ���̾�

    public Collider2D playerCollider;   //������ player �ݶ��̴�

    public NPCInfo npcInfo;             //NPC�� ������ �ִ� ���� ��ũ���ͺ� ������Ʈ

    [SerializeField]                    //NPC �̸�ǥ
    private GameObject nameTag;

    [SerializeField]                    //�� �ɱ� �г�
    private GameObject tryTalkPanel;

    [SerializeField]                    //��ȭ�� ���� UI �г�
    public GameObject scriptPanel;

    [SerializeField]
    private Player player;

    void Start()
    {
        nameTag.GetComponent<SpriteRenderer>().sprite = npcInfo.NpcSprtie;
        player = FindObjectOfType<Player>();
    }


    void Update()
    {
        playerCollider = Physics2D.OverlapCircle(transform.position, radius, layer);
        if(playerCollider != null)
        {
            tryTalkPanel.SetActive(true);
        }
        else
        {
            tryTalkPanel.SetActive(false);
        }

        if(tryTalkPanel.activeSelf)
        {
            player.isAbleToTalk = true;
        }

    }

    //�ݰ� �׸���(red)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
