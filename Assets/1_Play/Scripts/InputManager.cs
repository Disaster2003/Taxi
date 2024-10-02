using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // �VInput�V�X�e���̗��p�ɕK�v

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    private ActionControl AC; // �C���v�b�g�A�N�V�������`
    private Vector2 inputMove;

    // Start is called before the first frame update
    void Start()
    {
        // �C���X�^���X�𐶐�
        if (instance == null)
        {
            instance = this;
        }

        AC = new ActionControl();   // �C���v�b�g�A�N�V�������擾
        AC.Player.Move.started += OnMove;
        AC.Player.Move.performed += OnMove;
        AC.Player.Move.canceled += OnMove;
        AC.Enable();                // InputAction���@�\������ׂɗL��������B

        inputMove = Vector2.zero;
    }

    /// <summary>
    /// �C���X�^���X���擾
    /// </summary>
    public static InputManager GetInstance()
    {
        return instance;
    }

    /// <summary>
    /// Move�A�N�V�����̓��͎擾
    /// </summary>
    private void OnMove(InputAction.CallbackContext context)
    {
        inputMove = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// �ړ��ʂ��擾����
    /// </summary>
    public Vector2 GetInputMove()
    {
        return inputMove;
    }
}
