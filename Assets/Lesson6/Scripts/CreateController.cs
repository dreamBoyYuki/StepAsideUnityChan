using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateController : MonoBehaviour
{
    //carPrefab������
    public GameObject carPrefab;
    //coinPrefab������
    public GameObject coinPrefab;
    //cornPrefab������
    public GameObject conePrefab;
    //�X�^�[�g�n�_
    private int startPos;
    //�S�[���n�_
    private int goalPos = 360;
    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;

    //�����\�n�_
    private int createOKPos;
    //�������f�n�_
    private int createCheckPos;
    //�A�C�e�������Ԋu
    private int createDistance = 15;


    void Start()
    {
        startPos = (int)this.gameObject.transform.position.z;

        createOKPos = startPos;
    }


    void Update()
    {
        createCheckPos = (int)this.gameObject.transform.position.z;

        //�����ꏊ�̂����W���i�����Ԋu�̔{���łȂ��j�܂��́i�����\�n�_����Ȃ��j�܂���(���̐����\�n�_���S�[���t�߂ɂȂ�)���������Ȃ�
        //�������W��(�����Ԋu�̔{��)����(�����\�n�_)����(���̐����\�n�_���S�[���t�߂ɂȂ�Ȃ�)�������p��
        if (((createCheckPos % createDistance) != 0 ) || createCheckPos != createOKPos || (goalPos <= createOKPos + createDistance)) return;

        createOKPos += createDistance;

        ItemCreate(createCheckPos);
    }

    private void ItemCreate(int createPos)
    {
        //�ǂ̃A�C�e�����o���̂��������_���ɐݒ�
        int num = Random.Range(1, 11);
        if (num <= 2)
        {
            //�R�[����x�������Ɉ꒼���ɐ���
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab);
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, createPos);
            }
        }
        else
        {
            //���[�����ƂɃA�C�e���𐶐�
            for (int j = -1; j <= 1; j++)
            {
                //�A�C�e���̎�ނ����߂�
                int item = Random.Range(1, 11);
                //�A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
                int offsetZ = Random.Range(-5, 6);
                //60%�R�C���z�u:30%�Ԕz�u:10%�����Ȃ�
                if (1 <= item && item <= 6)
                {
                    //�R�C���𐶐�
                    GameObject coin = Instantiate(coinPrefab);
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, createPos + offsetZ);
                }
                else if (7 <= item && item <= 9)
                {
                    //�Ԃ𐶐�
                    GameObject car = Instantiate(carPrefab);
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, createPos + offsetZ);
                }
            }
        }
    }
}
