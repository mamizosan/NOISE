using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

	Animator _animator;

	// Use this for initialization
	void Start () {

		_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider other) {

		if(Input.GetButtonDown("Space")) {

			OpenAnim ();

		}

	}

	private void OpenAnim() {

		_animator.Play ("Door", 0, 0.0f);

	}
}
