using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionPanel : MonoBehaviour
{
    public void ClosePanel()
    {
        FindErrorGameManager.Instance.DescriptionPanel.SetActive(false);
    }

    public void OpenPanel()
    {
        FindErrorGameManager.Instance.DescriptionPanel.SetActive(true);
    }
    
}
