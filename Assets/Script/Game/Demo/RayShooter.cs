using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Space")) {

            RaycastHit hit =  ShootHit(transform.forward);
            if (hit.collider) {

                Debug.Log(hit.collider.gameObject.name);

            }

        }



	}

    //レイをとばす
    public RaycastHit ShootHit(Vector3 direction) {
        RaycastHit hit;

        Physics.Raycast(transform.position, direction, out hit);

        Ray ray = new Ray(transform.position, direction);

        Debug.DrawRay(ray.origin, ray.direction, Color.blue, 20f);

        return hit;

    }

}
