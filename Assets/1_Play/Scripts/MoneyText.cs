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
        // �C���X�^���X�𐶐�����
        if (instance == null)
        {
            instance = this;
        }

        txtMoney = GetComponent<Text>();
        money = 0;
        txtMoney.text = money.ToString("D5");
    }

    /// <summary>
    /// �C���X�^���X���擾����
    /// </summary>
    public static MoneyText GetInstance()
    {
        return instance;
    }

    /// <summary>
    /// ������ݒ肷��
    /// </summary>
    /// <param name="_money">�ݒ��̂���</param>
    public void SetMoneyText(int _money)
    {
        money = _money;
        txtMoney.text = money.ToString("D5");
    }
}
