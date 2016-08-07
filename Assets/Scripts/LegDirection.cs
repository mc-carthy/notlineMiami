using UnityEngine;
using System.Collections;

public class LegDirection : MonoBehaviour {

	private Vector3 rot;

	private void Start () {
		rot = new Vector3 (0, 0, 0);
	}

	private void Update () {
		if (Input.GetKey (KeyCode.W)) {
			rot = new Vector3 (0, 0, 90);
		}
		if (Input.GetKey (KeyCode.S)) {
			rot = new Vector3 (0, 0, 270);
		}
		if (Input.GetKey (KeyCode.A)) {
			rot = new Vector3 (0, 0, 180);
		}
		if (Input.GetKey (KeyCode.D)) {
			rot = new Vector3 (0, 0, 0);
		}
		transform.eulerAngles = rot;
	}
}
