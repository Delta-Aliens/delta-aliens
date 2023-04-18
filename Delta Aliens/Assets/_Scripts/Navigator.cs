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
        OnEnable();

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void OnDisable() {
        EventSystemsManager.Instance.onEndGame -= OnEndGame;
        EventSystemsManager.Instance.onRestartGame -= OnRestartGame;
    }

    void OnEnable() {
        EventSystemsManager.Instance.onEndGame += OnEndGame;
        EventSystemsManager.Instance.onRestartGame += OnRestartGame;
    }

    public void SwitchScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Switching to scene: " + sceneName);
    }

    public void OnEndGame()
    {
        Debug.Log("End Game");
        SwitchScene("Credits");
    }

    public void OnRestartGame()
    {
        Debug.Log("Restart Game");
        SwitchScene("Main_Menu");
    }
}
