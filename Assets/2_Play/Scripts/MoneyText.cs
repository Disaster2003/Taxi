using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    private static MoneyText instance;

    private Text text;
    private int money;

    // Start is called before the first frame update
    void Start()
    {
        // インスタンスを生成する
        if (instance == null)
        {
            instance = this;
        }

        text = GetComponent<Text>();
        if (PlayerPrefs.GetInt("Money") == 0)
        {
            money = 0;
        }
        else
        {
            money = PlayerPrefs.GetInt("Money");
        }
        text.text = money.ToString("D5");
    }

    /// <summary>
    /// インスタンスを取得する
    /// </summary>
    public static MoneyText GetInstance()
    {
        return instance;
    }

    /// <summary>
    /// 金額を取得する
    /// </summary>
    public int GetMoney() { return money; }

    /// <summary>
    /// お金を設定する
    /// </summary>
    /// <param name="_money">設定後のお金</param>
    public void SetMoneyText(int _money)
    {
        money += _money;
        text.text = money.ToString("D5");
    }

    private void OnDestroy()
    {
        // 金額を設定する
        PlayerPrefs.SetInt("Money", money);
    }
}
