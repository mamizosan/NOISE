using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitelFog : MonoBehaviour {

    [SerializeField]
    float speed = 0.1f;
    [SerializeField]
    float minTime = 3.0f;
    [SerializeField]
    float maxTime = 10.0f;
    bool fogStay;
    private float timeElapsed;
    private float timeOut;



	// Use this for initialization
	void Start ()
    {
        
	}

    //カメラの範囲に入ったら
    void OnBecameVisible()
    {
        fogStay = true;
    }

    //カメラ範囲を出たら
    void OnBecameInvisible()
    {
        fogStay = true;
    }


    public void Fog()
    {

        //デルタタイム
        timeElapsed += Time.deltaTime;

        //カメラ範囲内の時
        if (fogStay == true)
        { 
           
            //右に動く
            transform.Translate(speed, 0, 0);

            //待機時間をランダムで取得
            timeOut = Random.Range(minTime, maxTime);

        }
        //それ以外の時
        else
        {
            if (timeElapsed >= timeOut)
            {
                //画面端まで行ったら座標を戻す
                transform.position = new Vector3(-120, 0, 60);
                timeElapsed = 0.0f;
            }
        }
    }
	
	
}
