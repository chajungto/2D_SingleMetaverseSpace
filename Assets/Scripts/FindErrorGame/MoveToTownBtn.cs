using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToTownBtn : MonoBehaviour
{
    public void MoveToTown()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainScene");
    }
}
