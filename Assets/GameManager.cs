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
        REPORT = 1, // �������
        PLAY = 2,   // �v���C���
        RESULT = 3, // ���ʉ��
    }
    private STATE_SCENE state_scene;

    private float sceneInterval = 0;

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
            // �l�̏�����
            PlayerPrefs.SetInt("Days", 0);
            PlayerPrefs.SetInt("Money", 0);
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
                    sceneInterval = 3;
                    NextScene(STATE_SCENE.REPORT);
                }
                break;
            case STATE_SCENE.REPORT:
                // �����A�v���C
                if (sceneInterval <= 0)
                {
                    sceneInterval = 1;
                    NextScene(STATE_SCENE.PLAY);
                }
                sceneInterval += -Time.deltaTime;
                break;
            case STATE_SCENE.PLAY:
                if(sceneInterval > 0)
                {
                    sceneInterval += -Time.deltaTime;
                    return;
                }

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
                else if (DistanceText.distance <= 0)
                {
                    NextScene(STATE_SCENE.REPORT);
                }
                // ���ʉ�ʂ�
                else if(PlayerComponet.GetInstance().GetGas() <= 0)
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
