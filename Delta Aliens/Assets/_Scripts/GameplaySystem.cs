using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.SceneManagement;

public class GameplaySystem : MonoBehaviour
{
    public PlayerController Player;
    private bool gamePaused;
    bool state_frozen = false;

    //making sure there is only 1 instance in the scene
    #region SINGLETON PATTERN
    private static GameplaySystem _instance;
    
    public static GameplaySystem Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameplaySystem>();
            }

            return _instance;
        }
    }
    #endregion

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        gamePaused = false;
    }

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        //Pause
        EventSystemsManager.Instance.onPaused += onPauseGame;
        EventSystemsManager.Instance.onResumed += onResumedGameManager;
    }
    public void GameStartNew()
    {

    }

    // TODO: Connect with the UI GamePause Object
    public void onResumedGameManager()
    {
        if(!state_frozen)
        {
            Player.UnFrozen();
            gamePaused = false;
        }
        Time.timeScale = 1f;
    }

    void onPauseGame()
    {
        if(!gamePaused)
        {
            state_frozen = Player.isFrozen;
            gamePaused = true;

            Player.SetFrozen();
            Time.timeScale = 0f;
        }
        
        
    }

    

}