using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHelper : MonoBehaviour
{
    public TMP_InputField PlayerNameInputField;
    public TMP_Text HighScoreText;

    public void Start()
    {
        string highScore = "Best Score: " + DataManager.Instance.HighScorePlayerName + " - " + DataManager.Instance.HighScore;
        HighScoreText.text = highScore;
    }

    public void StartButtonClick()
    {
        // Collect player name from the input field and store it during the instance
        DataManager.Instance.PlayerName = PlayerNameInputField.text;
        SceneManager.LoadScene(1);
    }

    public void QuitButtonClick()
    {
        DataManager.Instance.SaveData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
