using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //Unityちゃんとカメラの距離
    private float difference;

    //画面外に出たときに当たる壁
    [SerializeField] private GameObject destroyWall;
    //壁とカメラの距離
    private float destroyDistance;

    //アイテムが生成される壁
    [SerializeField] private GameObject createWall;

    //生成壁とユニティちゃんの距離
    private float createDistance;


    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //Unityちゃんとカメラの位置（z座標）の差を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;

        //壁とカメラの位置(Z座標)の差を求める
        destroyDistance = destroyWall.transform.position.z - this.transform.position.z;

        //生成壁とカメラの位置(Z座標)の差を求める
        createDistance = unitychan.transform.position.z - createWall.transform.position.z;
    }

    void Update()
    {
        //Unityちゃんの位置に合わせてカメラの位置を移動
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
        
        //カメラの位置に合わせて壁を移動
        destroyWall.transform.position = new Vector3(0, destroyWall.transform.position.y, this.transform.position.z - destroyDistance);

        //ユニティちゃんの位置に合わせて生成壁を移動
        createWall.transform.position = new Vector3(0, createWall.transform.position.y, unitychan.transform.position.z - createDistance);

    }
}
