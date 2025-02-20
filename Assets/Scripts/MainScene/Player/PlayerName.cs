using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    [SerializeField]
    private InputField playerNameInputField;            //플레이어 이름 입력창

    private void Start()
    {
        playerNameInputField.characterLimit = 8;        //8글자의 제한
    }

    public void DecidePlayerName()
    {
        if (playerNameInputField != null)
        {
            PlayerPrefs.SetString("playerName", playerNameInputField.text);
            PlayerPrefs.Save();
            SceneManager.LoadScene("MainScene");
        }
    }
}
