using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class MoneyManager : MonoBehaviour
{
    public int money;
    public int tempMoney;
    public Text moneyCounter;
    public TextMeshPro moneyLabel;
    public static MoneyManager Instance;

    // Money Anim

    [SerializeField] private GameObject PileOfMoneyParent;
    [SerializeField] private Vector3[] InitalPosition;
    [SerializeField] private Quaternion[] InitalRotation;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    void Start()
    {
        tempMoney = 0;
        moneyLabel.text = tempMoney.ToString();
        moneyCounter.text = PlayerPrefs.GetInt("Money").ToString();

        //

        InitalPosition = new Vector3[4];
        InitalRotation = new Quaternion[4];

        for (int i = 0; i < PileOfMoneyParent.transform.childCount; i++)
        {
            InitalPosition[i] = PileOfMoneyParent.transform.GetChild(i).position;
            InitalRotation[i] = PileOfMoneyParent.transform.GetChild(i).rotation;
        }
    }
    void Update()
    {
        
    }

    public void GetMoney(int moneyValue)
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + moneyValue);
        tempMoney += moneyValue;
        moneyLabel.text = tempMoney.ToString();

    }

    private void Reset()
    {
        for (int i = 0; i < PileOfMoneyParent.transform.childCount; i++)
        {
            PileOfMoneyParent.transform.GetChild(i).position = InitalPosition[i];
            PileOfMoneyParent.transform.GetChild(i).rotation = InitalRotation[i];
        }
    }

    public void RewardPileOfCoin(int noCoin)
    {
        var delay = 0f;

        PileOfMoneyParent.SetActive(true);


        for (int i = 0; i < PileOfMoneyParent.transform.childCount; i++)
        {
            PileOfMoneyParent.transform.GetChild(i).DOScale(1f, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);

            PileOfMoneyParent.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(new Vector2(485f, 885f), 0.8f).
                SetDelay(delay + 0.5f).SetEase(Ease.InBack);

            PileOfMoneyParent.transform.GetChild(i).DORotate(Vector3.zero, 0.05f).SetDelay(delay + 0.5f).SetEase(Ease.Flash).
                OnComplete(CountCoinsByComplete);

            PileOfMoneyParent.transform.GetChild(i).DOScale(0f, 0.3f).SetDelay(delay + 1.8f).SetEase(Ease.OutBack);

            delay += 0.1f;
        }

        Reset();
    }

    private void CountCoinsByComplete()
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 1);
        moneyCounter.text = PlayerPrefs.GetInt("Money").ToString();
    }
}
