using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//�쐬��:���R
//���ʂ��o�[�Œ��߂���
public class ChangeAudioVolume : MonoBehaviour
{
    [SerializeField] AudioMixer _audioMixer;
    [Header("���ʂ̖��O")]
    [SerializeField] string _audioTypeName;//���ʂ̖��O
    [Header("�Z�[�u���鉹�ʂ̎��")]
    [SerializeField] AudioType _audioType;
    [Header("���ߗp�X���C�_�[")]
    [SerializeField] Slider _slider;//���ߗp�X���C�_�[

    void Start()
    {
        //�o�[�̒l�Ɍ��݂̉��ʂ�����
        //�Z�[�u�f�[�^���猻�݂̉��ʂ�����Ă���(�������audioMixer�̒l������)
        float audioVolume;
        _audioMixer.GetFloat(_audioTypeName, out audioVolume);
        audioVolume = SaveData.GetAudioVolume(_audioType,audioVolume);
        _slider.value = audioVolume;
    }

   public void SetAudioVolume(float volume)//���ʂ̕ύX
   {
        //�ύX�����特�ʂ��Z�[�u����
        _audioMixer.SetFloat(_audioTypeName, volume);
        SaveData.SaveAudioVolume(_audioType, volume);
   }
}