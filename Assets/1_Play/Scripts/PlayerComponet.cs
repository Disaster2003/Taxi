using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //新Inputシステムの利用に必要

public class PlayerComponet : MonoBehaviour
{
    ActionControl AC; //インプットアクションを定義
    Vector3 InputMove;

    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] car;
    private float intervalAnimation;
    
    // Start is called before the first frame update
    void Start()
    {
        AC = new ActionControl();   // インプットアクションを取得
        AC.Player.Move.started += OnMove;
        AC.Player.Move.performed += OnMove;
        AC.Player.Move.canceled += OnMove;
        AC.Enable();                // InputActionを機能させる為に有効化する。

        InputMove = Vector2.zero;

        // nullチェック
        if (car.Length == 0)
        {
            Debug.Log("車のアニメーション画像が未設定です");
            return;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = car[0];
        intervalAnimation = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        // nullチェック
        if (InputMove == Vector3.zero)
            return;

        // 入力方向へ移動・回転する
        transform.position += 5 * InputMove.normalized * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, (InputMove.x > 0) ? 180 : 0, 0);

        // アニメーションを再生する
        PlayAnimation();
    }

    /// <summary>
    /// Moveアクションの入力取得
    /// </summary>
    private void OnMove(InputAction.CallbackContext context)
    {
        InputMove = context.ReadValue<Vector2>();
    }

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
}
