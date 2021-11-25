using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{
    public int bestScore = 0;
    public string bestName = "";

    public TextMeshProUGUI bestScoreText;
    public TMP_InputField currentNameText;


    // Start is called before the first frame update
    void Start()
    {
        MainManagerX.Instance.LoadScore(ref bestName, ref bestScore);
        bestScoreText.text = "Best score: " + bestName + " - " + bestScore;

        MainManagerX.Instance.bestName = bestName;
        MainManagerX.Instance.bestScore = bestScore;


    }

    void Awake()
    {
        if (MainManagerX.Instance.currentName != "")
        {
            currentNameText.text = MainManagerX.Instance.currentName;
        }
    }

    public void StartNew()
    {
        MainManagerX.Instance.currentName = currentNameText.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
      
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else

        Application.Quit();
#endif


    }
}
