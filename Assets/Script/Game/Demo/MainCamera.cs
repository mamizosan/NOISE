using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCamera : MonoBehaviour {

    public GameObject player_eye;
    private Camera cam;

    [SerializeField]
    private float zoom;
    private float view;
    Vector3 setPos = new Vector3( 0, 1.55f, 0 );
    [SerializeField]
    private Text text;
    [SerializeField]
    GameObject gazeImage;

    public static bool zoom_up = false;

	// Use this for initialization
	void Start () {

        transform.position = player_eye.transform.position + setPos;

        GetComponent<Camera>().nearClipPlane = 0.1f; //壁を貫通させないため
        cam = GetComponent<Camera>();
        view = cam.fieldOfView;

        text.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player_eye.transform.position + setPos;

        cam.fieldOfView = view + zoom;
        if ( cam.fieldOfView < 10.0f ) { //最小(ズーム後)の指定
            cam.fieldOfView = 10.0f;
        }

        if (Input.GetButton( "Return" ) && zoom > -10) {
            if ( zoom <= -9.5f ) {
                zoom_up = true;
                text.enabled = true;
                gazeImageDisplay( );
            }
            zoom -= 0.5f; //ズームするスピード
        } else if ( !Input.GetButton("Return") && zoom < 0 ) {
            zoom_up = false;
            text.text = "";
            text.enabled = false;
            zoom += 0.5f; //戻るスピード
            gazeImageHide( );
        }

    }

    //凝視画像表示
    void gazeImageDisplay()
    {
        gazeImage.SetActive(true);
    }

    //凝視画像非表示
    void gazeImageHide()
    {
        gazeImage.SetActive(false);
    }



}
