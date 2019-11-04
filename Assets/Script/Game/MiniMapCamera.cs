using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour {
    [SerializeField]
    GameObject mainCamera;
    [SerializeField]
    GameObject miniMapCamera;

	// Use this for initialization
	void Start () {
	}
    
    public void MiniMap()
    {
        mainCamera.SetActive(false);
        miniMapCamera.SetActive(true);
    }

    public void MainCamera()
    {
        mainCamera.SetActive(true);
        miniMapCamera.SetActive(false);
    }


	
	// Update is called once per frame
	void Update () {
		
	}
}
