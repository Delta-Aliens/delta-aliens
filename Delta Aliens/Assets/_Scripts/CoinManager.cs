using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coins = 0;

    [SerializeField] private TMP_Text coinsText;

    public GetWeb getWebScript;

    #region SINGLETON PATTERN
    private static CoinManager _instance;
    
    public static CoinManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<CoinManager>();
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

        OnEnable();
    }

    private void OnDisable() {
        EventSystemsManager.Instance.onUpdateCoin -= OnUpdateCoin;
    }

    private void OnEnable() {
        EventSystemsManager.Instance.onUpdateCoin += OnUpdateCoin;
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        // Call the GetCurrency method from the GetWeb script
        StartCoroutine(getWebScript.GetCurrency());
    }

    void Update()
    {
        // Call the GetCurrency method from the GetWeb script every 5 seconds
        if (Time.frameCount % 600 == 0)
        {
            // Call the GetCurrency method from the GetWeb script
            StartCoroutine(getWebScript.GetCurrency());
        }
    }

    public void OnUpdateCoin(int coin)
    {
        coins = coin;
        coinsText.text = coins.ToString();
    }
}
