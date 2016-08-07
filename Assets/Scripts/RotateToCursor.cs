using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class RotateToCursor : MonoBehaviour {

	private Vector3 mousePos;
	private Vector3 direction;
	private Camera cam;
	private Rigidbody2D rb;

	private void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
		cam = Camera.main;
	}
	
	private void Update () {
		rotateToCamera ();
	}

	private void rotateToCamera () {
		mousePos = cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cam.transform.position.z));
		rb.transform.eulerAngles = new Vector3 (0, 0, Mathf.Atan2 ((mousePos.y - transform.position.y), (mousePos.x - transform.position.x)) * Mathf.Rad2Deg);
	}
}
