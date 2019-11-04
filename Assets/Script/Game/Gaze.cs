using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Gaze : MonoBehaviour {

    public float max_view = 40f;
    public float view_speed = 2f;
    float view = 60;
    [SerializeField]
    Camera cam;
    [SerializeField]
    GameObject gazeImage;
    [SerializeField]
    AudioMixer mixer;

    // Use this for initialization
    void Start(){
    }

    //凝視
    public void gaze(){
        if( view > 40 ) {
            view -= view_speed;
        }		
        cam.fieldOfView = view; 
		//輝度を上げる
        RenderSettings.ambientIntensity = 1.5f;
        //音量をさげる
        mixer.SetFloat("MasterVol", -80.0f);
        //画像表示
        gazeImageDisplay();
        Data.setPlayerGaze( true );
    }

    //輝度、音量をデフォルトに戻す
    public void defaultStatus(){
        if( view < 60 ) {
            view += view_speed;
        } else {
            //輝度をもとに戻す
            RenderSettings.ambientIntensity = 1.0f;
            //画像非表示
            gazeImageHide();
            Data.setPlayerGaze( false );
        }
		cam.fieldOfView = view;
    }

    //凝視画像表示
    void gazeImageDisplay(){
        gazeImage.SetActive(true);
    }

    //凝視画像非表示
    void gazeImageHide(){
        gazeImage.SetActive(false);
    }

    
}

