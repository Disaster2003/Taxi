using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCoin : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // ���̌i�F��
        if (GetComponent<SpriteRenderer>().color == Color.clear)
        {
            Destroy(gameObject);
        }

        // ��ֈړ�
        transform.position += new Vector3(0, 2 * Time.deltaTime);

        // ���������X�ɉ��Z����
        GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.clear, 0.5f * Time.deltaTime);
    }
}
