using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    UIManager uiManager;

    void Awake()
    {
        
        #if UNITY_EDITOR
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 45;
        #endif

        uiManager = FindObjectOfType<UIManager>();


    }
    public void HardRestartGame()
    {
        uiManager.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
