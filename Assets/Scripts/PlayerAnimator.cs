using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour {

	public SpriteRenderer torsoRen, legsRen;

	private Sprite[] walking, attacking, legs;
	private int torsoCount = 0, legCount = 0;
	private PlayerMovement pm;
	private float torsoTimer = 0.05f, legTimer = 0.05f;
	private SpriteContainer sc;

	private void Start () {
		pm = this.GetComponent<PlayerMovement> ();
		sc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<SpriteContainer> ();
		walking = sc.GetPlayerUnarmedWalk ();
		legs = sc.GetPlayerLegs ();
	}

	private void Update () {
		AnimateTorso ();
		AnimateLegs ();
	}

	private void AnimateTorso () {
		if (pm.moving) {
			torsoRen.sprite = walking [torsoCount];
			torsoTimer -= Time.deltaTime;
			if (torsoTimer <= 0) {
				if (torsoCount < walking.Length - 1) {
					torsoCount++;
				} else {
					torsoCount = 0;
				}
				torsoTimer = 0.1f;
			}
		}
	}

	private void AnimateLegs () {
		if (pm.moving) {
			legsRen.sprite = legs [legCount];
			legTimer -= Time.deltaTime;
			if (legTimer <= 0) {
				if (legCount < legs.Length - 1) {
					legCount++;
				} else {
					legCount = 0;
				}
				legTimer = 0.05f;
			}
		}
	}
}
