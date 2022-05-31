using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    private SaveManager saveManager;
    private DataRetain dataRetain;

    void Start()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        dataRetain = GameObject.Find("DataRetainer").GetComponent<DataRetain>();
    }

    public void StartGame()
    {
        dataRetain.currentName = playerName.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit
#endif
    }
}
