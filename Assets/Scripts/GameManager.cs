using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;        //ΩÃ±€≈Ê

    public static GameManager Instance          //ΩÃ±€≈Ê «¡∑Œ∆€∆º
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

    public bool isAbleToTalk = false;                               //¥Î»≠ ∞°¥… ø©∫Œ

    public List<GameObject> npcPanel = new List<GameObject>();      //NPC Panel ∏ÆΩ∫∆Æ

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
