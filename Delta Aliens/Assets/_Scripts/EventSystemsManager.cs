using UnityEngine;
using System.Collections;
using System;

public class EventSystemsManager : MonoBehaviour
{
    //making sure there is only 1 instance in the scene
    #region SINGLETON PATTERN
    private static EventSystemsManager _instance;

    public static EventSystemsManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<EventSystemsManager>();
            }

            return _instance;
        }
    }
    #endregion

    //destroys the game object if it's already found in the game
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public event Action onPaused;
    public event Action onResumed;
    public event Action onRestartGame;

    public void RestartGame()
    {
        if(onRestartGame != null)
        {
            onRestartGame();
        }
    }
  
    public void ResumedGame()
    {
        if(onResumed != null)
        {
            onResumed();
        }
    }

    public void PausedGame()
    {
        if(onPaused != null)
        {
            onPaused();
        }
    }
}