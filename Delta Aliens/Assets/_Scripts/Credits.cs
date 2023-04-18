using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        EventSystemsManager.Instance.onRestartGame += OnRestartGame;
    }

    void OnEnable() {
        EventSystemsManager.Instance.onRestartGame += OnRestartGame;
    }

    void OnDisable() {
        EventSystemsManager.Instance.onRestartGame -= OnRestartGame;
    }

    // Update is called once per frame
    void Update()
    {

        // After the animation is done, go back to the main menu
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Credits") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            EventSystemsManager.Instance.RestartGame();
        }
        
    }

    public void OnRestartGame()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
