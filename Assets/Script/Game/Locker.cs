using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Locker : MonoBehaviour
{

    [SerializeField]
    private Text text;

    GameObject _player;
    bool _inLocker = false;
    bool _first = false;
   // private bool _camera = false;

    public GameObject MainCam;
    public GameObject SubCam;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {

        if (!_inLocker)
        {
            return;
        }

        if (Input.GetButtonDown("Space") && !_first )
        {
            MainCam.SetActive(true);
            SubCam.SetActive(false);
            _player.SetActive(true);
            _inLocker = false;

            _player.transform.Rotate(new Vector3(0, 180, 0));

        }



        _first = false;

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag != _player.tag)
        {
            return;
        }

        if ( Data.getEnamyVisit( ) ) {
            return;
        }

		RaycastHit hit = _player.GetComponent<RayShooter> ().ShootHit(_player.transform.forward);

		if (hit.collider.gameObject.name == this.gameObject.name) {
           
			text.text = "Spaceキーでロッカーに隠れる";


		} else {
		
			text.text = "";

		}
            if (Input.GetButtonDown("Space"))
            {			
			

			if (hit.collider.gameObject.name == this.gameObject.name) {

				MainCam.SetActive(false);
				SubCam.SetActive(true);
				_first = true;
				_inLocker = true;
				_player.SetActive(false);
				text.text = "";

			}

            }
        }


}
