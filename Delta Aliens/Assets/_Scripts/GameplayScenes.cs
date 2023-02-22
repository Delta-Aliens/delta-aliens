using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayScenes : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static GameplayScenes _instance;

    public static GameplayScenes Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameplayScenes>();
                if (_instance == null)
                {
                    GameObject container = new GameObject("SceneManager");
                    _instance = container.AddComponent<GameplayScenes>();
                }
            }
            return _instance;
        }
    }
    #endregion

    public int sceneIndex;

    public void NextLevel()
    {
        int next_scene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(next_scene);
        sceneIndex++;
    }

    public void LoadGame()
    {

    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    void Awake()
    {
        GameplayEvents.Instance.onWeeklyTestDay += WeeklyTestEnable;

        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.isLoaded)
        {  
	        // do whatever necessary when loaded
        }
    }
}