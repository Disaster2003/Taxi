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
        // �V�[�����ɁuGasStation�v�^�O�������Ă���I�u�W�F�N�g�����鎞�́A
        // �����������Ȃ�
        if (GameObject.FindGameObjectsWithTag("GasStation").Length != 0)
        {
            return;
        }
        // �K�\�����X�^���h�̐���
        else if (DistanceText.distance % 50 < 1)
        {
            Instantiate(gasStation);
        }

        // �V�[�����ɁuCharacter�v�^�O�������Ă���I�u�W�F�N�g�����鎞�́A
        // �����������Ȃ�
        if (GameObject.FindGameObjectsWithTag("Character").Length != 0)
        {
            return;
        }
        // �q�̐���
        else if (DistanceText.distance % 30 < 1)
        {
            Instantiate(customer);
        }
    }
}
