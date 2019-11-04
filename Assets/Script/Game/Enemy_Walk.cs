using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Walk : MonoBehaviour {

    AudioSource _audioSource;

    public AudioClip _enemy;

	// Use this for initialization
	void Start () {

        _audioSource = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void EnemyMove() {

        _audioSource.PlayOneShot(_enemy);

    }
}
