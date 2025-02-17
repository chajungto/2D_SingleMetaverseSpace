using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCController : MonoBehaviour
{
    //���� ����
    public float radius = 1f;

    //�÷��̾� ���� ���̾�
    public LayerMask layer;

    //������ player �ݶ��̴�
    public Collider2D playerCollider;

    //NPC�� ������ �ִ� ���� ��ũ���ͺ� ������Ʈ
    public NPCInfo npcInfo;

    //NPC �̸�ǥ
    [SerializeField]
    private GameObject nameTag;

    //�� �ɱ� �г�
    [SerializeField]
    private GameObject tryTalkPanel;

    //��ȭ�� ���� UI �г�
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
            Debug.Log("�÷��̾� ����");
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

    //�ݰ� �׸���(red)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
