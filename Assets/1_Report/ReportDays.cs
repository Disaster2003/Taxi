using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReportDays : MonoBehaviour
{
    public static Text txtDays;

    // Start is called before the first frame update
    void Start()
    {
        txtDays = GetComponent<Text>();
        int tmp = 0;
        if (PlayerPrefs.GetInt("Days") == 0)
        {
            tmp = 1;
        }
        else
        {
            tmp = PlayerPrefs.GetInt("Days");
            tmp++;
        }
        PlayerPrefs.SetInt("Days", tmp);
        txtDays.text = "- " + tmp + " “ú–Ú -";
    }

    // Update is called once per frame
    void Update()
    {
        txtDays.color = Color.Lerp(txtDays.color, Color.clear, 0.5f * Time.deltaTime);
    }
}
