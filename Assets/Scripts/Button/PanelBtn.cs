using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBtn : MonoBehaviour
{
    [SerializeField]
    List<GameObject> panelList = new List<GameObject>();

    public void OpenPanel()
    {
        foreach(GameObject panel in panelList)
        {
            panel.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        foreach (GameObject panel in panelList)
        {
            panel.SetActive(false);
        }
    }
}
