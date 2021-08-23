using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI BestScoreText;

    private void Start()
    {
        BestScoreText.text = "Best : " + GameManager.singleton.BestScore;
    }
    public void GameStart()
    {
        SceneManager.LoadScene("Main");
        GameManager.singleton.GameInit();
    }

    public void GameExit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
