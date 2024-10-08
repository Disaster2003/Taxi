using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDays : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // nullチェック
        if (PlayerPrefs.GetInt("Days") == 0)
        {
            Debug.Log("日数が未設定です");
            return;
        }

        // テキストを設定する
        GetComponent<Text>().text = PlayerPrefs.GetInt("Days").ToString() + "日頑張った...";
    }
}
