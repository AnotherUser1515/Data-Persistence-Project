using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataRetain : MonoBehaviour
{
    public static DataRetain Instance1;
    public SaveManager saveManager;
    public TextMeshProUGUI bestScoreText;
    public string currentName;

    private void Awake()
    {
        if (Instance1 != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance1 = this;
        DontDestroyOnLoad(gameObject);

        saveManager.LoadSave();
    }

    void Update()
    {
        MenuText();
    }

    public void MenuText()
    {
        bestScoreText.text = "Best Score: " + saveManager.topPlayerName + ": " + saveManager.topScore;
    }
}
