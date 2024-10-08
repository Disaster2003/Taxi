using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerComponet : MonoBehaviour
{
    private static PlayerComponet instance;

    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] car;
    private float intervalAnimation;

    [SerializeField] Image imgMeter;
    [SerializeField] float gasMax = 100;
    public float gas;
    
    // Start is called before the first frame update
    void Start()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
        }

        // nullチェック
        if (car.Length == 0)
        {
            Debug.Log("車のアニメーション画像が未設定です");
            return;
        }
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = car[0];
        intervalAnimation = 0.1f;

        gas = gasMax;
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

        // 入力方向へ回転する
        transform.rotation = Quaternion.Euler(0, (inputMove.x > 0) ? 180 : 0, 0);

        // アニメーションを再生する
        PlayAnimation();

        // ガスを減らす
        gas -= Time.deltaTime;
        imgMeter.fillAmount = gas / gasMax;
    }

    /// <summary>
    /// インスタンスを取得する
    /// </summary>
    public static PlayerComponet GetInstance() { return instance; }

    /// <summary>
    /// アニメーションを再生する
    /// </summary>
    private void PlayAnimation()
    {
        // nullチェック
        if (car.Length == 0)
        {
            Debug.Log("車のアニメーション画像が未設定です");
            return;
        }

        if(intervalAnimation <= 0)
        {
            intervalAnimation = 0.1f;
            for (int i = 0; i < car.Length; i++)
            {
                if(spriteRenderer.sprite == car[i])
                {
                    // 最初の画像へ
                    if(i == car.Length - 1)
                    {
                        spriteRenderer.sprite = car[0];
                        break;
                    }
                    // 次の画像へ
                    else
                    {
                        spriteRenderer.sprite = car[i + 1];
                        break;
                    }
                }
            }
        }
        // 時間経過
        intervalAnimation += -Time.deltaTime;
    }

    /// <summary>
    /// ガスを補給する
    /// </summary>
    public void ChargeGas() { gas = gasMax; }
}
