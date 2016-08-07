using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public bool moving = false;
	public float moveSpeed = 5.0f;

	private void Update() {
		Movement ();
	}

	private void Movement () {
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.up * moveSpeed * Time.deltaTime, Space.World);
			moving = true;
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.down * moveSpeed * Time.deltaTime, Space.World);
			moving = true;
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.left * moveSpeed * Time.deltaTime, Space.World);
			moving = true;
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * moveSpeed * Time.deltaTime, Space.World);
			moving = true;
		}

		if ((!Input.GetKey (KeyCode.W)) && (!Input.GetKey (KeyCode.S)) && (!Input.GetKey (KeyCode.A)) && (!Input.GetKey (KeyCode.D))) {
			moving = false;
		}
	}
}
