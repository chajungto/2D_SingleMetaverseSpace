using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ΩÃ±€≈Ê
    private static GameManager instance;

    //ΩÃ±€≈Ê «¡∑Œ∆€∆º
    public static GameManager Instance
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

    //¥Î»≠ ∞°¥… ø©∫Œ
    public bool isAbleToTalk = false;

    //panel ∏ÆΩ∫∆Æ
    public List<GameObject> npcPanel = new List<GameObject>();

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
