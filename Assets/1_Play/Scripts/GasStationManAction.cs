using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasStationManAction : MonoBehaviour
{
    private bool isHitCheck;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(10, -4);
        isHitCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 入力チェック
        Vector3 inputMove = InputManager.GetInstance().GetInputMove();
        if (inputMove == Vector3.zero)
        {
            return;
        }

        if (isHitCheck)
        {
            if (MoneyText.GetInstance().GetMoney() >= 20)
            {
                if (inputMove.y < 0)
                {
                    // ガスの補給
                    MoneyText.GetInstance().SetMoneyText(-20);
                    PlayerComponet.GetInstance().ChargeGas();
                    Destroy(gameObject);
                }
            }
        }

        float movementOfAmount = 5 * inputMove.x * -Time.deltaTime;
        // 乗せないなら削除
        if (transform.position.x + movementOfAmount <= -10)
        {
            Destroy(gameObject);
        }
        // バックしても消さない
        else if (transform.position.x + movementOfAmount >= 10)
        {
            return;
        }
        // ガソリンスタンドの移動
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
