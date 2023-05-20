using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateController : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //生成可能地点
    private int createOKPos;
    //生成判断地点
    private int createCheckPos;
    //アイテム生成間隔
    private int createDistance = 15;


    void Start()
    {
        startPos = (int)this.gameObject.transform.position.z;

        createOKPos = startPos;
    }


    void Update()
    {
        createCheckPos = (int)this.gameObject.transform.position.z;

        //生成場所のｚ座標が（生成間隔の倍数でない）または（生成可能地点じゃない）または(次の生成可能地点がゴール付近になる)＝何もしない
        //→ｚ座標が(生成間隔の倍数)かつ(生成可能地点)かつ(次の生成可能地点がゴール付近にならない)＝処理継続
        if (((createCheckPos % createDistance) != 0 ) || createCheckPos != createOKPos || (goalPos <= createOKPos + createDistance)) return;

        createOKPos += createDistance;

        ItemCreate(createCheckPos);
    }

    private void ItemCreate(int createPos)
    {
        //どのアイテムを出すのかをランダムに設定
        int num = Random.Range(1, 11);
        if (num <= 2)
        {
            //コーンをx軸方向に一直線に生成
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab);
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, createPos);
            }
        }
        else
        {
            //レーンごとにアイテムを生成
            for (int j = -1; j <= 1; j++)
            {
                //アイテムの種類を決める
                int item = Random.Range(1, 11);
                //アイテムを置くZ座標のオフセットをランダムに設定
                int offsetZ = Random.Range(-5, 6);
                //60%コイン配置:30%車配置:10%何もなし
                if (1 <= item && item <= 6)
                {
                    //コインを生成
                    GameObject coin = Instantiate(coinPrefab);
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, createPos + offsetZ);
                }
                else if (7 <= item && item <= 9)
                {
                    //車を生成
                    GameObject car = Instantiate(carPrefab);
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, createPos + offsetZ);
                }
            }
        }
    }
}
