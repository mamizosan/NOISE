using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

    public GameObject camera;
    public GameObject player;
    public float cameraSpeed = 10f;
    public float speed;
    public float backSpeed = 0.1f;
    public float walk = 3f;
    public float run = 4f;
    Vector3 playerPos;
    Transform cameraHorRot;
    Transform playerVerRot;
    [SerializeField]
    Transform startPos;
    Rigidbody rb;




    // Use this for initialization
    void Start() {
        playerPos = startPos.transform.position;
        player.transform.position = playerPos;
        rb = player.GetComponent<Rigidbody>();
        playerVerRot = player.GetComponent<Transform>();
        cameraHorRot = camera.GetComponent<Transform>();
        speed = walk;
    }

    public void flontBack() {
        playerPos.z = (Input.GetAxis("Vertical")) * speed;
    }

    public void leftRight() {
        playerPos.x = (Input.GetAxis("Horizontal")) * speed;
    }

    public void flontBackRotation()
    {
        rb.velocity = (playerPos.z) * player.transform.forward + (playerPos.x) * player.transform.right;
    }

    public void leftRightRotation()
    {
        rb.velocity = (playerPos.z) * player.transform.forward + (playerPos.x) * player.transform.right;
    }

    public void Run(){
        speed = run;
    }

    public void Walk(){
        speed = walk;
    }

    public void back(){
        speed = backSpeed;
    }

    void cameraView(){
        //マウス回転
        if ( Data.getPlayerEar( ) || Data.getPlayerItem( ) ) {
            return;
        }
        float playerX_Rotation = ( float )( Math.Truncate( Input.GetAxis("Mouse X") * 100 ) * 0.01 );
        float cameraY_Rotation = ( float )( Math.Truncate( Input.GetAxis("Mouse Y") * 100 ) * 0.01 );
        playerVerRot.transform.Rotate(0, playerX_Rotation * cameraSpeed, 0);
        if (cameraHorRot.localEulerAngles.x + cameraY_Rotation * cameraSpeed >= 20f && cameraHorRot.localEulerAngles.x + cameraY_Rotation * cameraSpeed <= 270f)
        {
            return;
        }
        cameraHorRot.transform.Rotate(cameraY_Rotation * cameraSpeed, 0, 0);
    }

    void Update(){
        cameraView();
    }


}
