using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDays : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �e�L�X�g��ݒ肷��
        GetComponent<Text>().text = PlayerPrefs.GetInt("Days").ToString() + "���撣����...";
    }
}
