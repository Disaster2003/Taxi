using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class GasStationManAction : MonoBehaviour
{
    private int price;
    [SerializeField] Text txtPrice;
    private bool isHitCheck;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(10, -4);
        price = PlayerPrefs.GetInt("Days") * 10;
        txtPrice.text = price.ToString() + "�~";
        isHitCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ���̓`�F�b�N
        Vector3 inputMove = InputManager.GetInstance().GetInputMove();
        if (inputMove == Vector3.zero)
        {
            return;
        }

        if (isHitCheck)
        {
            if (MoneyText.GetInstance().GetMoney() >= price)
            {
                if (inputMove.y < 0)
                {
                    // �K�X�̕⋋
                    MoneyText.GetInstance().SetMoneyText(-price);
                    PlayerComponet.GetInstance().ChargeGas();
                    Destroy(gameObject);
                }
            }
        }

        float movementOfAmount = 5 * inputMove.x * -Time.deltaTime;
        // �悹�Ȃ��Ȃ�폜
        if (transform.position.x + movementOfAmount <= -10)
        {
            Destroy(gameObject);
        }
        // �o�b�N���Ă������Ȃ�
        else if (transform.position.x + movementOfAmount >= 10)
        {
            return;
        }
        // �K�\�����X�^���h�̈ړ�
        else
        {
            transform.position += new Vector3(movementOfAmount, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isHitCheck = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isHitCheck = false;
    }
}
