using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject customer;
    [SerializeField] GameObject gasStation;

    // Update is called once per frame
    void Update()
    {
        // �V�[�����ɁuCharacter�v�^�O�������Ă���I�u�W�F�N�g�����鎞�́A
        // �����������Ȃ�
        if(GameObject.FindGameObjectsWithTag("Character").Length == 0)
        {
            return;
        }

        // �K�\�����X�^���h�̐���
        if (DistanceText.distance % 50 == 0)
        {
            Instantiate(gasStation);
        }
        // �q�̐���
        if (DistanceText.distance % 30 == 0)
        {
            Instantiate(customer);
        }
    }
}
