using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anim : MonoBehaviour {


    public float animSpeed = 1.5f;
    private Animator anim;
    private AnimatorStateInfo currentBaseState;
    
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

	}

    void playerAnim(){
        float v = 0;
        if ( !Data.getPlayerEar( ) && !Data.getPlayerGaze( ) && !Data.getPlayerItem( ) ) {
            v = Input.GetAxis("Vertical");
        }
            anim.SetFloat("Speed", v);
            anim.speed = animSpeed;
            currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
    }
    

    // Update is called once per frame
    void Update () {
        playerAnim();
	}
}
