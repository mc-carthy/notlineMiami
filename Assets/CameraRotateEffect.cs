using UnityEngine;
using System.Collections;

public class CameraRotateEffect : MonoBehaviour {

	private PlayerMovement pm;
	//private float timer = 0.1f;
	private float mod = 0.1f;
	private float zVal = 0.0f;

	private void Start () {
		pm = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ();
	}

	private void Update () {
		if (pm.moving) {
			Vector3 rot = new Vector3 (0, 0, zVal);
			this.transform.eulerAngles = rot;

			zVal += mod;

			if (transform.eulerAngles.z >= 5.0f && transform.eulerAngles.z < 10.0f) {
				mod = -0.1f;
			} else if (transform.eulerAngles.z <= 355.0f && transform.eulerAngles.z > 350.0f) {
				mod = 0.1f;
			}
		}
	}
}
