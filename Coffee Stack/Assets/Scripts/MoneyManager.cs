using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public int money;
    public Text moneyCounter;
    public TextMeshPro moneyLabel;

    public static MoneyManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        moneyLabel.text = PlayerPrefs.GetInt("Money").ToString();
    }


    void Update()
    {
        
    }

    public void GetMoney(int moneyValue)
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + moneyValue);
        moneyLabel.text = PlayerPrefs.GetInt("Money").ToString();

    }
}
