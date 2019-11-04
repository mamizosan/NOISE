using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeneManager : MonoBehaviour {

    [SerializeField]
    TitelFog titelFog;
    [SerializeField]
    TitelLight titelLight;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        titelFog.Fog();
        titelLight.LightFlashing();
    }
}
