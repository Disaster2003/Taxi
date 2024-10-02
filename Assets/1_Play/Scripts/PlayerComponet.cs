using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //�VInput�V�X�e���̗��p�ɕK�v

public class PlayerComponet : MonoBehaviour
{
    ActionControl AC; //�C���v�b�g�A�N�V�������`
    Vector3 InputMove;

    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] car;
    private float intervalAnimation;
    
    // Start is called before the first frame update
    void Start()
    {
        AC = new ActionControl();   // �C���v�b�g�A�N�V�������擾
        AC.Player.Move.started += OnMove;
        AC.Player.Move.performed += OnMove;
        AC.Player.Move.canceled += OnMove;
        AC.Enable();                // InputAction���@�\������ׂɗL��������B

        InputMove = Vector2.zero;

        // null�`�F�b�N
        if (car.Length == 0)
        {
            Debug.Log("�Ԃ̃A�j���[�V�����摜�����ݒ�ł�");
            return;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = car[0];
        intervalAnimation = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        // null�`�F�b�N
        if (InputMove == Vector3.zero)
            return;

        // ���͕����ֈړ��E��]����
        transform.position += 5 * InputMove.normalized * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, (InputMove.x > 0) ? 180 : 0, 0);

        // �A�j���[�V�������Đ�����
        PlayAnimation();
    }

    /// <summary>
    /// Move�A�N�V�����̓��͎擾
    /// </summary>
    private void OnMove(InputAction.CallbackContext context)
    {
        InputMove = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// �A�j���[�V�������Đ�����
    /// </summary>
    private void PlayAnimation()
    {
        // null�`�F�b�N
        if (car.Length == 0)
        {
            Debug.Log("�Ԃ̃A�j���[�V�����摜�����ݒ�ł�");
            return;
        }

        if(intervalAnimation <= 0)
        {
            intervalAnimation = 0.1f;
            for (int i = 0; i < car.Length; i++)
            {
                if(spriteRenderer.sprite == car[i])
                {
                    // �ŏ��̉摜��
                    if(i == car.Length - 1)
                    {
                        spriteRenderer.sprite = car[0];
                        break;
                    }
                    // ���̉摜��
                    else
                    {
                        spriteRenderer.sprite = car[i + 1];
                        break;
                    }
                }
            }
        }
        // ���Ԍo��
        intervalAnimation += -Time.deltaTime;
    }
}
