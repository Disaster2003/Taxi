using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLogo : MonoBehaviour
{
    private Text logo;

    // Start is called before the first frame update
    void Start()
    {
        // 透明にする
        if (logo == null)
            logo = GetComponent<Text>();
        logo.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        // nullチェック
        if (logo == null)
            return;

        // 黄色からの差分を徐々に加算する
        if (logo.color != Color.yellow)
        {
            logo.color = Color.Lerp(logo.color, Color.yellow, Time.deltaTime);
        }
        // 位置を上下させる
        else
        {
            Debug.Log("通った");
            Vector3 pos = transform.localPosition;
            transform.localPosition = new Vector3(pos.x, pos.y + Mathf.Sin(Time.time) * 0.1f, pos.z);
        }
    }
}
