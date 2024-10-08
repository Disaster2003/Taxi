using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAction : MonoBehaviour
{
    private bool isHitCheck;

    private enum STATE_CUTOMER
    {
        NONE,
        RIDE,
    }
    private STATE_CUTOMER stateCustomer;

    private float distanceTmp;
    private int distanceClear;

    private enum KIND_OF_CHARACTER
    {
        DQN,
        NORMAL,
        RICH,
    }
    [SerializeField] Sprite[] dqnArray;
    [SerializeField] Sprite[] normalArray;
    [SerializeField] Sprite[] richArray;
    private Dictionary<KIND_OF_CHARACTER, Sprite[]> objectSprite;

    [SerializeField] GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(10, -4);
        isHitCheck = false;

        stateCustomer = STATE_CUTOMER.NONE;

        objectSprite
            = new Dictionary<KIND_OF_CHARACTER, Sprite[]>
            {
             { KIND_OF_CHARACTER.DQN, new Sprite[2] },
             { KIND_OF_CHARACTER.NORMAL, new Sprite[2] },
             { KIND_OF_CHARACTER.RICH, new Sprite[2] }
            };
        for (int i = 0; i < 2; i++)
        {
            objectSprite[KIND_OF_CHARACTER.DQN][i] = dqnArray[i];
            objectSprite[KIND_OF_CHARACTER.NORMAL][i] = normalArray[i];
            objectSprite[KIND_OF_CHARACTER.RICH][i] = richArray[i];
        }
        int whatKind = Random.Range(0, 3);
        switch (whatKind)
        {
            case 0:
                distanceClear = Random.Range(10, 20);
                break;
            case 1:
                distanceClear = Random.Range(20, 30);
                break;
            case 2:
                distanceClear = Random.Range(40, 50);
                break;
        }
        int whichGender = Random.Range(0, 2);
        GetComponent<SpriteRenderer>().sprite = objectSprite[(KIND_OF_CHARACTER)whatKind][whichGender];
    }

    // Update is called once per frame
    void Update()
    {
        switch (stateCustomer)
        {
            case STATE_CUTOMER.NONE:
                // 入力チェック
                Vector3 inputMove = InputManager.GetInstance().GetInputMove();
                if (inputMove == Vector3.zero)
                {
                    return;
                }

                if (isHitCheck)
                {
                    // 乗車
                    if (inputMove.y < 0)
                    {
                        stateCustomer = STATE_CUTOMER.RIDE;
                        GetComponent<SpriteRenderer>().color = Color.clear;
                        distanceTmp = DistanceText.distance;
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
                // 客の移動
                else
                {
                    transform.position += new Vector3(movementOfAmount, 0);
                }
                break;
            case STATE_CUTOMER.RIDE:
                if(distanceTmp - distanceClear > DistanceText.distance)
                {
                    // お金の支払い
                    MoneyText.GetInstance().SetMoneyText(distanceClear);

                    // お金獲得
                    Instantiate(coin, transform.position, Quaternion.identity);

                    // 
                    Destroy(gameObject);
                }
                break;
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
