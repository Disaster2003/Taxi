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
        // �����ɂ���
        if (logo == null)
            logo = GetComponent<Text>();
        logo.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        // null�`�F�b�N
        if (logo == null)
            return;

        // ���F����̍��������X�ɉ��Z����
        if (logo.color != Color.yellow)
        {
            logo.color = Color.Lerp(logo.color, Color.yellow, Time.deltaTime);
        }
        // �ʒu���㉺������
        else
        {
            Debug.Log("�ʂ���");
            Vector3 pos = transform.localPosition;
            transform.localPosition = new Vector3(pos.x, pos.y + Mathf.Sin(Time.time) * 0.1f, pos.z);
        }
    }
}
