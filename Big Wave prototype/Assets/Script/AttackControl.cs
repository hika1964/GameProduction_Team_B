using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttackControl : MonoBehaviour
{
    [SerializeField] float damageAdjustment = 1f;//�_���[�W�����W��
    Enemy enemy;
    Player player;
    JumpControl jumpcontrol;
    public bool attacked;//�U�����������Ă��Ȃ����̔���

    // Start is called before the first frame update
    void Start()
    {
       attacked = false;
       enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
       player = GameObject.FindWithTag("Player").GetComponent<Player>();
       jumpcontrol = GameObject.FindWithTag("Player").GetComponent<JumpControl>();
    }

    // Update is called once per frame
    void Update()
    {
            Attack();//�U��
    }

    //�U��(�W�����v���ɍ��N���b�N)
    //trick������ēG�Ƀ_���[�W��^����Atrick�̒l�ɂ���ă_���[�W���ς��(�_���[�W�̒l��trick�~damagecoefficient)
    void Attack()
    {
        if (Input.GetButtonDown("Fire1")||Input.GetKeyDown("j"))
        {
            if (jumpcontrol.jumpNow == true)
            {
                if (enemy != null)
                {
                    enemy.Damage(player.trick * damageAdjustment);
                }

                attacked = true;//�U������
                player.ConsumeTRICK();
            }
        }

        if(jumpcontrol.jumpNow == false)//���ʂɐڒn���Ă���Ȃ�
        {
            attacked = false;//�U�����Ă��Ȃ�
        }
    }
}