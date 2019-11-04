using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ami_controller : MonoBehaviour {

    Rigidbody _Ami_rb;
    public float speed;
    public GameObject start_pos;
    public Transform cameraHorRot;
    private Vector3 _ami_pos;


    float start_axis_x;
    float start_axis_y;

    void axis_controller()
    {

        if ( Input.GetAxis("Mouse X") != start_axis_x ) {
            float playerX_Rotation = Input.GetAxis("Mouse X");
            transform.Rotate(0, playerX_Rotation * 10, 0);
        }
        if (Input.GetAxis("Mouse Y") != start_axis_y ) {
            float cameraY_Rotation = Input.GetAxis("Mouse Y");
            cameraHorRot.transform.Rotate( cameraY_Rotation * 10, 0, 0);
        }

    }

    void connect_controller( ){

        axis_controller( );
        _ami_pos.x = ( Input.GetAxis( "Horizontal" ) ) * speed ;
        _ami_pos.z = ( Input.GetAxis( "Vertical" ) ) * speed;
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!ItemCanvas.getItemCanvas())
            {
                ItemCanvas.itemCanvasPlay();
            }
            else
            {
                ItemCanvas.itemCanvasExit();
            }
        }
        _Ami_rb.velocity = ( _ami_pos.z ) * transform.forward + ( _ami_pos.x ) * transform.right;

    }

	// Use this for initialization
	void Start () {
        start_axis_x = Input.GetAxis("Mouse X");
        start_axis_y = Input.GetAxis("Mouse Y");

        _ami_pos = start_pos.transform.position;
        transform.position = _ami_pos;
        _Ami_rb = GetComponent< Rigidbody >( );
	}
	
	// Update is called once per frame
	void Update () {
        connect_controller( );

	}

    


}
