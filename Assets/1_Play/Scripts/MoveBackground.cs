using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private const float POSITION_END = -38;

    // Start is called before the first frame update
    void Start()
    {
        // 初期配置
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // 入力チェック
        float inputMove = InputManager.GetInstance().GetInputMove().x;
        if (inputMove == 0)
        {
            return;
        }

        // 背景を左へ移動
        transform.position += new Vector3(5 * inputMove * -Time.deltaTime, 0);

        // 画像の同じ部分に戻し、ずっと続いているように錯覚させる
        if (transform.position.x < POSITION_END)
        {
            transform.position = Vector3.zero;
        }
        if(transform.position.x > 0)
        {
            transform.position = new Vector3(POSITION_END, 0, 0);
        }
    }
}
