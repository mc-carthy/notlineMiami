using UnityEngine;
using System.Collections;

public class GenericAnimation : MonoBehaviour {

	public Sprite[] sprites;
	public bool loop, destroyOnFinish, whileNear, needsActivating;
	public float animateDistance = 5.0f, activateDistance = 2.0f, timerReset = 0.5f;


	private bool active = false;
	private SpriteRenderer sprRen;
	private float timer = 0.5f;
	private int counter = 0;
	private GameObject player;

	private void Start () {
		sprRen = this.GetComponent<SpriteRenderer> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		sprRen.sprite = sprites [0];
	}

	private void Update () {
		if (whileNear) {
			AnimateWhileNear ();
		} else if (needsActivating) {
			if (Input.GetKeyDown (KeyCode.E) && Vector3.Distance (player.transform.position, this.transform.position) < activateDistance) {
				active = !active;
			}
			if (active) {
				AnimateNormally ();
			}
		} else {
			AnimateNormally ();
		}
	}

	private void AnimateWhileNear () {
		sprRen.sprite = sprites [counter];
		if (Vector3.Distance (player.transform.position, this.transform.position) < animateDistance) {
			timer -= Time.deltaTime;
			if (timer <= 0) {
				if (counter < sprites.Length - 1) {
					counter++;
				} else {
					if (loop) {
						counter = 0;
					} else if (destroyOnFinish) {
						Destroy (this.gameObject);
					}
				}
				timer = timerReset;
			}
		}
	}

	private void AnimateNormally () {
		sprRen.sprite = sprites [counter];
		timer -= Time.deltaTime;
		if (timer <= 0) {
			if (counter < sprites.Length - 1) {
				counter++;
			} else {
				if (loop) {
					counter = 0;
				} else if (destroyOnFinish) {
					Destroy (this.gameObject);
				}
			}
			timer = timerReset;
		}
	}
}
