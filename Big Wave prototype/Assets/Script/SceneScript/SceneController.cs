using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�쐬��:���R
//�V�[���J�ڂ̃��\�b�h���Ă�(�V�[�������ς�������̕ύX�̃R�X�g�����炷����)
public class SceneController : MonoBehaviour
{
    [Header("�ȉ��̓Q�[���V�[���Ɉڍs���Ȃ��Ȃ�K�v�Ȃ�")]
    [Header("�Q�[���V�[���Ɉڍs����̂ɕK�v�ȃX�e�[�W�f�[�^")]
    [SerializeField] CurrentStageData _currentStageData;
    [Header("�X�e�[�W�f�[�^���X�g")]
    [SerializeField] StageDataList _stageDataList;

    public void MenuScene()//���j���[��ʂɈڍs
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ClearScene()//�N���A�V�[���Ɉڍs
    {
        SceneManager.LoadScene("ClearScene");
    }

    public void GameOverScene()//�Q�[���I�[�o�[�V�[���Ɉڍs
    {
        SceneManager.LoadScene("GameoverScene");
    }

    public void GameScene(int stageID)//�Q�[���V�[��1�ֈړ�
    {
        //�K�v�ȃf�[�^���A�^�b�`����Ă��Ȃ���Όx������������
        if(_currentStageData==null||_stageDataList==null)
        {
            Debug.Log("�K�v�ȃf�[�^��������Ă��܂���I");
            return;
        }

        _currentStageData.Rewrite(_stageDataList.Get(stageID));

        SceneManager.LoadScene("ToMainLoadScene");//��x���[�h���(ToMainLoadScene)���o�R������
    }

    public void EndGame()//�Q�[�����I������
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}