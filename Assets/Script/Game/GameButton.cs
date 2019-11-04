using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameButton : MonoBehaviour {

    [SerializeField]
    Player_Move player_Move;
    [SerializeField]
    Ear ear;
    [SerializeField]
    Gaze gaze;
    [SerializeField]
    MiniMapCamera miniCamera;


    // Use this for initialization
    void Start()
    {
    }

    void gameButton()
    {
        //前後
        if (Input.GetAxis("Vertical") != 0)
        {
            if ( !Data.getPlayerEar( ) && !Data.getPlayerGaze( ) && !Data.getPlayerItem( ) ) {
                player_Move.flontBack();
                player_Move.speed = player_Move.walk;
                player_Move.flontBackRotation();
            }
        }

        //左右
        if (Input.GetAxis("Horizontal") != 0)
        {
            if ( !Data.getPlayerEar( ) && !Data.getPlayerGaze( ) && !Data.getPlayerItem( ) ) {
                player_Move.leftRight();
                player_Move.leftRightRotation();
            }
        }

        //ラン
        if (Input.GetButton("Run"))
        {
            player_Move.Run();
        }

        //押していないとき歩く
        else
        {
            player_Move.Walk();
        }

        //凝視

        if (Input.GetButton( "Return" )){
            gaze.gaze();
        }
        else{
            gaze.defaultStatus();
        }

        //耳を澄ます

        if (Input.GetButton( "Sound" )){
            ear.startFadeOut();
        }
        else{
            ear.startFadeIn();
        }

        //ミニマップ表示
        if (Input.GetButton( "Map" )){
            miniCamera.MiniMap();
        } else{
            miniCamera.MainCamera();
        }

        if(Input.GetButtonDown( "Item" ))
        {
            if (!ItemCanvas.getItemCanvas())
            {
                ItemCanvas.itemCanvasPlay();
                Data.setPlayerItem( true );
            }
            else
            {
                ItemCanvas.itemCanvasExit();
                Data.setPlayerItem( false );
            }
        }


    }

    // Update is called once per frame
    void Update(){
        gameButton();
    }
}

