using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PV : MonoBehaviour
{
    public float waitTime = 10.0f; //���b�����Ă������瓮�悪����邩�i�G�f�B�^���ŕύX���āj

    float elapsedTime = 0.0f;   //�o�ߎ���
    Vector3 lastMousePosition;  //�}�E�X�̈ʒu
    bool isPlayeng = false;     //�Đ������ǂ����t���O
    VideoPlayer player;         //����v���C���[�R���|�[�l���g


    private void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.loopPointReached += Stop;        //���悪�I�������Stop���Ă΂��悤�C�x���g���d����

        lastMousePosition = Input.mousePosition;    //�����}�E�X�ʒu
    }

    // Update is called once per frame
    void Update()
    {
        //�Đ����ĂȂ�
        if (isPlayeng == false)
        {
            //���Ԍv��
            elapsedTime += Time.deltaTime;

            //�������삵����o�ߎ��ԃ��Z�b�g
            if (Input.anyKeyDown || (Input.mousePosition != lastMousePosition))
            {
                elapsedTime = 0.0f;
                lastMousePosition = Input.mousePosition;
            }


            //�w�肵�����Ԃ��o�߂�����Đ�
            if (elapsedTime > waitTime)
            {
                elapsedTime = 0.0f;
                Play();
            }
        }

        //�Đ���
        else
        {
            //�����L�[�������ꂽ��PV��~
            if (Input.anyKeyDown)
            {
                Stop(player);
            }
        }
    }


    /// <summary>
    /// �Đ�
    /// </summary>
    private void Play()
    {
        player.Play();
        isPlayeng = true;
    }


    /// <summary>
    /// ��~
    /// </summary>
    /// <param name="vp">�v���C���[�i�����o�ϐ��ɂ��Ă邩�炢��Ȃ��񂾂��ǁA����I��������ɌĂ΂��悤�ɂ��邽�߂ɕK�v</param>
    private void Stop(VideoPlayer vp)
    {
        player.Stop();
        isPlayeng = false;
    }
}
