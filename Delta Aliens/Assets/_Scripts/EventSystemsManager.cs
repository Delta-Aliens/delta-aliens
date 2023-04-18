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

    public event Action onEndGame;
    public event Action onRestartGame;
    public event Action onQuitGame;

    public event Action<int> onUpdateCoin;

    public void EndGame()
    {
        if (onEndGame != null)
        {
            onEndGame();
        }
    }

    public void RestartGame()
    {
        if (onRestartGame != null)
        {
            onRestartGame();
        }
    }

    public void QuitGame()
    {
        if (onQuitGame != null)
        {
            onQuitGame();
        }
    }

    public void UpdateCoin(int coin)
    {
        if (onUpdateCoin != null)
        {
            onUpdateCoin(coin);
        }
    }
}
