using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionPanel : MonoBehaviour
{
    public void ClosePanel()
    {
        GameManager.Instance.currentScene.DescriptionPanel.SetActive(false);
    }

    public void OpenPanel()
    {
        GameManager.Instance.currentScene.DescriptionPanel.SetActive(true);
    }
    
}
