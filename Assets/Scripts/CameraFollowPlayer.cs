using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {

	private GameObject player;
	private bool followPlayer = true;

	private void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	private void Update () {
		if (followPlayer) {
			CamFollowPlayer ();
		}
	}

	public void SetFollowPlayer (bool value) {
		followPlayer = value;
	}

	private void CamFollowPlayer () {
		Vector3 newPos = new Vector3 (player.transform.position.x, player.transform.position.y, this.transform.position.z);
		this.transform.position = newPos;
	}

}
