using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceText : MonoBehaviour
{
    private Text text;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        distance = Random.Range(250, 500);
        text.text = distance.ToString("f2") + "km";
    }

    // Update is called once per frame
    void Update()
    {
        // 入力チェック
        Vector3 inputMove = InputManager.GetInstance().GetInputMove();
        if (inputMove == Vector3.zero)
            return;

        // 距離の更新
        distance -= inputMove.x * Time.deltaTime;
        text.text = distance.ToString("f2") + "km";
    }
}
