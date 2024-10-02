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
        // �C���X�^���X�𐶐�����
        if (instance == null)
        {
            instance = this;
        }

        text = GetComponent<Text>();
        money = 0;
        text.text = money.ToString("D5");
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
        text.text = money.ToString("D5");
    }
}
