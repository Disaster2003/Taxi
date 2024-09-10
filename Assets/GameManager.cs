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
        switch (state_scene)
        {
            case STATE_SCENE.TITLE:
                NextScene(STATE_SCENE.PLAY);
                break;
            case STATE_SCENE.PLAY:
                break;
            case STATE_SCENE.RESULT:
                NextScene(STATE_SCENE.RESULT);
                break;
        }
    }

    /// <summary>
    /// 次のシーンへ
    /// </summary>
    private void NextScene(STATE_SCENE _state_scene)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            state_scene = _state_scene;
            SceneManager.LoadSceneAsync((int)state_scene);
        }
    }
}
