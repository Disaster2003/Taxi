using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// シーンの状態
    /// </summary>
    private enum STATE_SCENE
    {
        TITLE = 0,  // タイトル画面
        PLAY = 1,   // プレイ画面
        RESULT = 2, // 結果画面
    }
    private STATE_SCENE state_scene;

    // Start is called before the first frame update
    void Start()
    {
        // シーン移動での破壊を防ぐ
        DontDestroyOnLoad(gameObject);

        // シーンの初期化
        state_scene = STATE_SCENE.TITLE;
    }

    // Update is called once per frame
    void Update()
    {
        //Escが押された時
        if (Input.GetKey(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
        }

        switch (state_scene)
        {
            case STATE_SCENE.TITLE:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    NextScene(STATE_SCENE.PLAY);
                }
                break;
            case STATE_SCENE.PLAY:
                //逆走上限
                if (DistanceText.distance <= -999)
                {
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
                }
                // 次の日へ
                if (DistanceText.distance <= 0)
                {

                }
                // 結果画面へ
                else if(PlayerComponet.GetInstance().gas <= 0)
                {
                    NextScene(STATE_SCENE.RESULT);
                }
                break;
            case STATE_SCENE.RESULT:
                // タイトルへ
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    NextScene(STATE_SCENE.TITLE);
                }
                break;
        }
    }

    /// <summary>
    /// 次のシーンへ
    /// </summary>
    private void NextScene(STATE_SCENE _state_scene)
    {
        if(_state_scene == STATE_SCENE.TITLE)
        {
            // 値の初期化
            PlayerPrefs.SetInt("Days", 0);
            PlayerPrefs.SetInt("Money", 0);
        }

        state_scene = _state_scene;
        SceneManager.LoadSceneAsync((int)state_scene);
    }
}
