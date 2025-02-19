using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryFlappyGame : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("FlappyBirdGameScene");
    }
}
