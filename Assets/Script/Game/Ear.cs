using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Ear : MonoBehaviour {

    public float fadeSpeed;
    public bool isFadeOut = false;
    public bool isFadeIn = false;
    float red, green, blue, alfa;
    [SerializeField]
    int MAXVOLUME;
    [SerializeField]
    int MINVOLUME;
    [SerializeField]
    GameObject clarifyImage;
    [SerializeField]
    Image fadeImage;
    [SerializeField]
    AudioMixer audioMixer;

    // Use this for initialization
    void Start () {
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;

    }

    //カメラを黒くする
    public void startFadeIn(){
        //イメージの非表示
        clarifyImageHide();
        //不透明度を徐々に下げる
        alfa -= fadeSpeed;
        //変更した不透明パネルに反映する
        setAlpha();
        if (alfa <= 0){
            Data.setPlayerEar( false );
            isFadeIn = false;
            fadeImage.enabled = false;
            alfa = 0;
            //耳を澄ます処理
            audioMixer.SetFloat( "MasterVol", MAXVOLUME );
        }
    }

    //カメラを透明にする
    public void startFadeOut(){
        //イメージの表示
        clarifyImageDisplay();
        //パネルの表示をオンにする
        fadeImage.enabled = true;
        //不透明度を徐々にあげる
        alfa += fadeSpeed;
        //変更した透明度をパネルに反映する
        setAlpha();
        //完全に不透明になったら処理を抜ける
        Data.setPlayerEar( true );
        if (alfa >= 1){
            isFadeOut = false;
            alfa = 1;
            //耳を澄ます処理
            audioMixer.SetFloat("MasterVol", MAXVOLUME);
        }
    }

    void setAlpha(){
        fadeImage.color = new Color(red, green, blue, alfa);
    }

    //耳を澄ます画像表示
    public void clarifyImageDisplay(){
        clarifyImage.SetActive(true);
    }

    //耳を澄ます画像非表示
    public void clarifyImageHide(){
        clarifyImage.SetActive(false);
    }

    private void Update(){
        Debug.Log(alfa);
    }
}
