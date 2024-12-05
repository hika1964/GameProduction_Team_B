using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�G�̎��S���[�V����
//���b���[�V������������A���������ă��f���̕����\���ɂ���
public class EnemyDeadMotion : MonoBehaviour
{
    [SerializeField] Animator _enemy_animator;
    [SerializeField] string _deadTriggerName;
    [Header("���j���ɐ�������G�t�F�N�g")]
    [SerializeField] DefeatEffect _defeatEffect;
    [Header("�\����Ԃ�؂�ւ���I�u�W�F�N�g")]
    [SerializeField] ChangeActiveObject[] _changeObjects;
    bool _startMotion = false;

    public void Trigger()
    {
        
        _enemy_animator.SetTrigger(_deadTriggerName);
        _startMotion = true;
       
    }

    void Update()
    { 
        UpdateEffect();
    }

    void UpdateEffect()
    {
        if (!_startMotion) return;

        //���j���ɐ�������G�t�F�N�g
        _defeatEffect.GenerateDefeatEffect();

        //�\����Ԃ�؂�ւ���I�u�W�F�N�g
        for (int i = 0; i < _changeObjects.Length; i++)
        {
            _changeObjects[i].UpdateActive();
        }
    }

   
}