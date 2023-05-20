using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    //Unity�����̃I�u�W�F�N�g
    private GameObject unitychan;
    //Unity�����ƃJ�����̋���
    private float difference;

    //��ʊO�ɏo���Ƃ��ɓ������
    [SerializeField] private GameObject destroyWall;
    //�ǂƃJ�����̋���
    private float destroyDistance;

    //�A�C�e��������������
    [SerializeField] private GameObject createWall;

    //�����ǂƃ��j�e�B�����̋���
    private float createDistance;


    void Start()
    {
        //Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");
        //Unity�����ƃJ�����̈ʒu�iz���W�j�̍������߂�
        this.difference = unitychan.transform.position.z - this.transform.position.z;

        //�ǂƃJ�����̈ʒu(Z���W)�̍������߂�
        destroyDistance = destroyWall.transform.position.z - this.transform.position.z;

        //�����ǂƃJ�����̈ʒu(Z���W)�̍������߂�
        createDistance = unitychan.transform.position.z - createWall.transform.position.z;
    }

    void Update()
    {
        //Unity�����̈ʒu�ɍ��킹�ăJ�����̈ʒu���ړ�
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
        
        //�J�����̈ʒu�ɍ��킹�ĕǂ��ړ�
        destroyWall.transform.position = new Vector3(0, destroyWall.transform.position.y, this.transform.position.z - destroyDistance);

        //���j�e�B�����̈ʒu�ɍ��킹�Đ����ǂ��ړ�
        createWall.transform.position = new Vector3(0, createWall.transform.position.y, unitychan.transform.position.z - createDistance);

    }
}
