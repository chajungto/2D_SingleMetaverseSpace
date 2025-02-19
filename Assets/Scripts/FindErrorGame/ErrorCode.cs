using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ErrorCode : MonoBehaviour
{
    public List<Collider2D> lines = new List<Collider2D>();            //검출될 라인들의 충돌

    void OnTriggerEnter2D(Collider2D collider)
    {
        lines.Add(collider);
        Debug.Log("추가");
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        lines.Remove(collider);
        Debug.Log("제거");
    }

    private void OnRemove()
    {
        if (lines.Count == 2)
        {
            Destroy(this.gameObject);
            Debug.Log("눌림");
            GameManager.Instance.currentScene.score++;
        }
    }
}
