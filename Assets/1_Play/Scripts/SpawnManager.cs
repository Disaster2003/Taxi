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
        // シーン内に「Character」タグを持っているオブジェクトがある時は、
        // 何も生成しない
        if(GameObject.FindGameObjectsWithTag("Character").Length == 0)
        {
            return;
        }

        // ガソリンスタンドの生成
        if (DistanceText.distance % 50 == 0)
        {
            Instantiate(gasStation);
        }
        // 客の生成
        if (DistanceText.distance % 30 == 0)
        {
            Instantiate(customer);
        }
    }
}
