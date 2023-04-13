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
    }
    public void GameStartNew()
    {

    }

}