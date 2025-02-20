using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBase : MonoBehaviour
{
    protected virtual void Start()
    {
        InitScene();
    }

    protected virtual void InitScene()
    {
        GameManager.Instance.currentScene = this;
    }
}
