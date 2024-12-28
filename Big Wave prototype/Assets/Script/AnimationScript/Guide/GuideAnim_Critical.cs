using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�N���e�B�J���̏󋵂ɂ���āA�K�C�h�̖��̃A�j���[�V�����𓮂���
public class GuideAnim_Critical : MonoBehaviour
{
    [Header("�A�j���[�V�����̐��������bool��")]
    [SerializeField] string _successBoolName;
    [Header("�A�j���[�V�����̎��s��trigger��")]
    [SerializeField] string _failTriggerName; 

    [Header("�K�C�h�̖�󂲂Ƃ̃A�j���[�^�[")]
    [Header("��")]
    [SerializeField] Animator _eastGuide;
    [Header("��")]
    [SerializeField] Animator _westGuide;
    [Header("��")]
    [SerializeField] Animator _southGuide;
    [Header("�k")]
    [SerializeField] Animator _northGuide;

    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] Trick _trick;
    [SerializeField] Critical _critical;

    const int currentCriticalButtonIndex = 0;//���݂̃N���e�B�J���̃{�^���������v�f�ԍ�

    void Start()
    {
        _trick.TrickAction += OrderAnim;
    }

    void OrderAnim()
    {
        bool criticalNow = _critical.CriticalNow;//�N���e�B�J����������
        TrickButton currentButton = _critical.CriticalButton[currentCriticalButtonIndex];//���݂�(�N���e�B�J����)�{�^��
        Animator guideAnimator = GuideAnimator(currentButton);

        //�N���e�B�J�����s�̎��̂�trigger���o��
        guideAnimator.SetBool(_successBoolName,criticalNow);
        if (!criticalNow) guideAnimator.SetTrigger(_failTriggerName);
    }

    //���ꂽ�g���b�N�̃{�^���̎�ނɑΉ������A�j���[�V������Ԃ�
    Animator GuideAnimator(TrickButton trickButton)
    {
        switch(trickButton)
        {
            case TrickButton.east: return _eastGuide;
            case TrickButton.west: return _westGuide;
            case TrickButton.south: return _southGuide;
            case TrickButton.north: return _northGuide;
        }

        //��O
        return null;
    }
}