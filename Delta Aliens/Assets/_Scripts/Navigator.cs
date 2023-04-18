using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigator : MonoBehaviour
{

    //making sure there is only 1 instance in the scene
    #region SINGLETON PATTERN
    private static Navigator _instance;
    
    public static Navigator Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Navigator>();
            }

            return _instance;
        }
    }
    #endregion

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        EventSystemsManager.Instance.onEndGame += EndGame;
        EventSystemsManager.Instance.onRestartGame += RestartGame;
        EventSystemsManager.Instance.onQuitGame += QuitGame;
    }

    private void OnEnable() {
        EventSystemsManager.Instance.onEndGame += EndGame;
        EventSystemsManager.Instance.onRestartGame += RestartGame;
        EventSystemsManager.Instance.onQuitGame += QuitGame;
    }

    public void SwitchScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }


    public void EndGame()
    {
        Debug.Log("End Game");
        SceneManager.LoadScene("Credits");
    }

    public void RestartGame()
    {
        Debug.Log("Restart Game");
        SceneManager.LoadScene("Main_Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
