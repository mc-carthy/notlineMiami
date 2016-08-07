using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {

	private GameObject player;
	private PlayerMovement pm;
	private Camera cam;
	private bool followPlayer = true;
	private float camDepth = -10f;

	private void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		pm = player.GetComponent<PlayerMovement> ();
		cam = Camera.main;
	}

	private void Update () {
		if (Input.GetKey (KeyCode.LeftShift)) {
			followPlayer = false;
			pm.SetMoving (false);
		} else {
			followPlayer = true;
		}

		if (followPlayer) {
			CamFollowPlayer ();
		} else {
			LookAhead ();
		}
	}

	public void SetFollowPlayer (bool value) {
		followPlayer = value;
	}

	private void CamFollowPlayer () {
		Vector3 newPos = new Vector3 (player.transform.position.x, player.transform.position.y, camDepth);
		this.transform.position = newPos;
	}

	private void LookAhead () {
		Vector3 camPos = cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, camDepth));
		Vector3 dir = camPos - this.transform.position;
		if (player.GetComponent<SpriteRenderer> ().isVisible) {
			transform.Translate (dir * 2 * Time.deltaTime);
		}
		camPos.z = camDepth;
	}

}
