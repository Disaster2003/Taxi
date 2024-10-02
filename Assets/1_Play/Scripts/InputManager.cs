using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // 新Inputシステムの利用に必要

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    private ActionControl AC; // インプットアクションを定義
    private Vector2 inputMove;

    // Start is called before the first frame update
    void Start()
    {
        // インスタンスを生成
        if (instance == null)
        {
            instance = this;
        }

        AC = new ActionControl();   // インプットアクションを取得
        AC.Player.Move.started += OnMove;
        AC.Player.Move.performed += OnMove;
        AC.Player.Move.canceled += OnMove;
        AC.Enable();                // InputActionを機能させる為に有効化する。

        inputMove = Vector2.zero;
    }

    /// <summary>
    /// インスタンスを取得
    /// </summary>
    public static InputManager GetInstance()
    {
        return instance;
    }

    /// <summary>
    /// Moveアクションの入力取得
    /// </summary>
    private void OnMove(InputAction.CallbackContext context)
    {
        inputMove = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// 移動量を取得する
    /// </summary>
    public Vector2 GetInputMove()
    {
        return inputMove;
    }
}
