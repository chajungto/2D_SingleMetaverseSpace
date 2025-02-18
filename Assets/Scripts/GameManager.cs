using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;        //�̱���

    public static GameManager Instance          //�̱��� ������Ƽ
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public bool isAbleToTalk = false;                               //��ȭ ���� ����

    public List<GameObject> npcPanel = new List<GameObject>();      //NPC Panel ����Ʈ

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
