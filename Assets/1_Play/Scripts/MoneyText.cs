using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    private static MoneyText instance;

    private Text txtMoney;
    private int money;

    // Start is called before the first frame update
    void Start()
    {
        // インスタンスを生成する
        if (instance == null)
        {
            instance = this;
        }

        txtMoney = GetComponent<Text>();
        money = 0;
        txtMoney.text = money.ToString("D5");
    }

    /// <summary>
    /// インスタンスを取得する
    /// </summary>
    public static MoneyText GetInstance()
    {
        return instance;
    }

    /// <summary>
    /// お金を設定する
    /// </summary>
    /// <param name="_money">設定後のお金</param>
    public void SetMoneyText(int _money)
    {
        money = _money;
        txtMoney.text = money.ToString("D5");
    }
}
