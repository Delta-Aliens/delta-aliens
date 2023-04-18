using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplaySystem : MonoBehaviour
{
    public PlayerController Player;

    public ItemCollector IC;

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
    }

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    void LateUpdate() {
        if (IC.bottles == 10) {
            EventSystemsManager.Instance.EndGame();
        }
    }
}