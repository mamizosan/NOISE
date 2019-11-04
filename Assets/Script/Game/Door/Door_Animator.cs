using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Animator : MonoBehaviour {

	Animator _animator;

	// Use this for initialization
	void Start () {

		_animator = GetComponent<Animator> ();
		DoorAnim ();

	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.O)){
			
			DoorAnim ();
		}
	}

	private void DoorAnim() {
	
		_animator.Play("Door",0 ,0.0f);
		//this.gameObject.transform.Translate (0.01f, 0, 0);

		//this.gameObject.transform.Translate (-0.01f, 0, 0);
	
	}
}
