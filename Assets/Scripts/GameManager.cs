using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;        //ΩÃ±€≈Ê

    public SceneBase currentScene;              //«ˆ¿Á æ¿

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
}
