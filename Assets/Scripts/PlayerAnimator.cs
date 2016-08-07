using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour {

	public SpriteRenderer torsoRen, legsRen;

	private Sprite[] walkingSpr, attackingSpr, legsSpr;
	private int torsoCount = 0, legCount = 0;
	private PlayerMovement pm;
	private float torsoTimer = 0.05f, legTimer = 0.05f;
	private SpriteContainer sc;
	private bool attacking;

	private void Start () {
		pm = this.GetComponent<PlayerMovement> ();
		sc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<SpriteContainer> ();
		walkingSpr = sc.GetPlayerUnarmedWalk ();
		attackingSpr = sc.GetPlayerPunch ();
		legsSpr = sc.GetPlayerLegs ();
	}

	private void Update () {
		if (attacking) {
			AnimateAttack ();
		} else {
			AnimateTorso ();
		}
		AnimateLegs ();
	}

	public void Attack () {
		attacking = true;
	}

	public void ResetCounter () {
		torsoCount = 0;
	}

	public bool GetAttack () {
		return attacking;
	}

	public void SetNewTorso(Sprite[] walk, Sprite[] attack) {
		torsoCount = 0;
		walkingSpr = walk;
		attackingSpr = attack;
	}

	private void AnimateAttack () {
		torsoRen.sprite = attackingSpr [torsoCount];

		torsoTimer -= Time.deltaTime;
		if (torsoTimer <= 0) {
			if (torsoCount < attackingSpr.Length - 1) {
				torsoCount++;
			} else {
				attacking = false;
				torsoCount = 0;
				torsoRen.sprite = attackingSpr [0];
			}
			torsoTimer = 0.1f;
		}
	}

	private void AnimateTorso () {
		if (pm.moving) {
			torsoRen.sprite = walkingSpr [torsoCount];
			torsoTimer -= Time.deltaTime;
			if (torsoTimer <= 0) {
				if (torsoCount < walkingSpr.Length - 1) {
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
			legsRen.sprite = legsSpr [legCount];
			legTimer -= Time.deltaTime;
			if (legTimer <= 0) {
				if (legCount < legsSpr.Length - 1) {
					legCount++;
				} else {
					legCount = 0;
				}
				legTimer = 0.05f;
			}
		}
	}
}
