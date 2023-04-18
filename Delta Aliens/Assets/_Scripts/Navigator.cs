using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that handles scene navigation and game quitting.
/// </summary>
public class Navigator : MonoBehaviour
{
    // Singleton pattern to ensure only one instance exists in the scene.
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

    /// <summary>
    /// Ensures the game object is not destroyed when a new scene is loaded.
    /// </summary>
    void Awake()
    {
        OnEnable();

        // Destroy the game object if there is already an instance in the scene.
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Ensures the game object is not destroyed when a new scene is loaded.
    /// </summary>
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// Unsubscribe from event handlers when object is disabled.
    /// </summary>
    void OnDisable() {
        // Unsubscribe from event handlers when object is disabled.
        EventSystemsManager.Instance.onEndGame -= OnEndGame;
        EventSystemsManager.Instance.onRestartGame -= OnRestartGame;
        EventSystemsManager.Instance.onQuitGame -= QuitGame;
    }

    /// <summary>
    /// Subscribe to event handlers when object is enabled.
    /// </summary>
    void OnEnable() {
        // Subscribe to event handlers when object is enabled.
        EventSystemsManager.Instance.onEndGame += OnEndGame;
        EventSystemsManager.Instance.onRestartGame += OnRestartGame;
        EventSystemsManager.Instance.onQuitGame += QuitGame;
    }

    /// <summary>
    /// Loads a new scene.
    /// </summary>
    /// <param name="sceneName">The name of the scene to load.</param>
    public void SwitchScene(string sceneName) {
        SceneManager.LoadScene(sceneName); // Load the scene.
        Debug.Log("Switching to scene: " + sceneName);
    }

    /// <summary>
    /// Handles the end game event by switching to the Credits scene.
    /// </summary>
    public void OnEndGame()
    {
        Debug.Log("End Game");
        SwitchScene("Credits");
    }

    /// <summary>
    /// Handles the restart game event by switching to the Main_Menu scene.
    /// </summary>
    public void OnRestartGame()
    {
        Debug.Log("Restart Game");
        SwitchScene("Main_Menu");
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
