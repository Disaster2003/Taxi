using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private const float POSITION_END = -38;

    // Start is called before the first frame update
    void Start()
    {
        // �����z�u
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // ���̓`�F�b�N
        float inputMove = InputManager.GetInstance().GetInputMove().x;
        if (inputMove == 0)
        {
            return;
        }

        // �w�i�����ֈړ�
        transform.position += new Vector3(5 * inputMove * -Time.deltaTime, 0);

        // �摜�̓��������ɖ߂��A�����Ƒ����Ă���悤�ɍ��o������
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
