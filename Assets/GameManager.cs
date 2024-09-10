using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// �V�[���̏��
    /// </summary>
    private enum STATE_SCENE
    {
        TITLE = 0,  // �^�C�g�����
        PLAY = 1,   // �v���C���
        RESULT = 2, // ���ʉ��
    }
    private STATE_SCENE state_scene;

    // Start is called before the first frame update
    void Start()
    {
        // �V�[���ړ��ł̔j���h��
        DontDestroyOnLoad(gameObject);

        // �V�[���̏�����
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
    /// ���̃V�[����
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
