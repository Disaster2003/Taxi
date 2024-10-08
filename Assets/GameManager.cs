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
        //Esc�������ꂽ��
        if (Input.GetKey(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
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
                //�t�����
                if (DistanceText.distance <= -999)
                {
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
                }
                // ���̓���
                if (DistanceText.distance <= 0)
                {

                }
                // ���ʉ�ʂ�
                else if(PlayerComponet.GetInstance().gas <= 0)
                {
                    NextScene(STATE_SCENE.RESULT);
                }
                break;
            case STATE_SCENE.RESULT:
                // �^�C�g����
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    NextScene(STATE_SCENE.TITLE);
                }
                break;
        }
    }

    /// <summary>
    /// ���̃V�[����
    /// </summary>
    private void NextScene(STATE_SCENE _state_scene)
    {
        if(_state_scene == STATE_SCENE.TITLE)
        {
            // �l�̏�����
            PlayerPrefs.SetInt("Days", 0);
            PlayerPrefs.SetInt("Money", 0);
        }

        state_scene = _state_scene;
        SceneManager.LoadSceneAsync((int)state_scene);
    }
}
