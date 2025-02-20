using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : SceneBase
{
    protected override void Start()
    {
        InitScene();
        PlayerPrefs.SetFloat("RecentxPos", 0f);
        PlayerPrefs.SetFloat("RecentyPos", 0f);
    }

}
