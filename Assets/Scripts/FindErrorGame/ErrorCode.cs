using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ErrorCode : MonoBehaviour
{
    public List<Collider2D> lines = new List<Collider2D>();            //����� ���ε��� �浹

    void OnTriggerEnter2D(Collider2D collider)
    {
        lines.Add(collider);
        Debug.Log("�߰�");
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        lines.Remove(collider);
        Debug.Log("����");
    }

    private void OnRemove()
    {
        if (lines.Count == 2)
        {
            Destroy(this.gameObject);
            Debug.Log("����");
            GameManager.Instance.currentScene.score++;
        }
    }
}
