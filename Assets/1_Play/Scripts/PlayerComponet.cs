using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerComponet : MonoBehaviour
{
    private static PlayerComponet instance;

    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] car;
    private float intervalAnimation;

    [SerializeField] Image imgMeter;
    [SerializeField] float gasMax = 100;
    public float gas;
    
    // Start is called before the first frame update
    void Start()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
        }

        // null�`�F�b�N
        if (car.Length == 0)
        {
            Debug.Log("�Ԃ̃A�j���[�V�����摜�����ݒ�ł�");
            return;
        }
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = car[0];
        intervalAnimation = 0.1f;

        gas = gasMax;
    }

    // Update is called once per frame
    void Update()
    {
        // ���̓`�F�b�N
        Vector3 inputMove = InputManager.GetInstance().GetInputMove();
        if (inputMove == Vector3.zero)
        {
            return;
        }

        // ���͕����։�]����
        transform.rotation = Quaternion.Euler(0, (inputMove.x > 0) ? 180 : 0, 0);

        // �A�j���[�V�������Đ�����
        PlayAnimation();

        // �K�X�����炷
        gas -= Time.deltaTime;
        imgMeter.fillAmount = gas / gasMax;
    }

    /// <summary>
    /// �C���X�^���X���擾����
    /// </summary>
    public static PlayerComponet GetInstance() { return instance; }

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

    /// <summary>
    /// �K�X��⋋����
    /// </summary>
    public void ChargeGas() { gas = gasMax; }
}
