using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCoin : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // 次の景色へ
        if (GetComponent<SpriteRenderer>().color == Color.clear)
        {
            Destroy(gameObject);
        }

        // 上へ移動
        transform.position += new Vector3(0, 2 * Time.deltaTime);

        // 差分を徐々に加算する
        GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.clear, 0.5f * Time.deltaTime);
    }
}
