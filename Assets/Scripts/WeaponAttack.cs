using UnityEngine;
using System.Collections;

public class WeaponAttack : MonoBehaviour {

	//public GameObject oneHandSpawn, twoHandSpawn;

	private GameObject bullet, currentWeapon;
	private bool projectile = false;
	private float timer = 0.1f, timerReset = 0.1f;
	private PlayerAnimator anim;
	private SpriteContainer sprCon;
	private float weaponChangeTime = 0.5f;
	private bool weaponChanging = false;

	private void Start () {
		anim = this.GetComponent<PlayerAnimator> ();
		sprCon = GameObject.FindGameObjectWithTag ("GameController").GetComponent<SpriteContainer> ();
	}

	private void Update () {
		if (Input.GetMouseButton (0)) {
			Attack ();
		}
		if (Input.GetMouseButtonDown (0)) {
			anim.ResetCounter ();
		}
		if (Input.GetMouseButtonUp (0)) {
			anim.ResetCounter ();
		}

		if (Input.GetMouseButtonDown (1) && !weaponChanging) {
			//DropWeapon ();
		}

		if (weaponChanging) {
			weaponChangeTime -= Time.deltaTime;
			if (weaponChangeTime < 0) {
				weaponChanging = false;
			}
		}
	}

	public void SetWeapon (GameObject current, string weaponName, float fireRate, bool projectile) {
		weaponChanging = true;
		currentWeapon = current;
		anim.SetNewTorso (sprCon.GetWeaponWalk (weaponName), sprCon.GetWeapon (weaponName));
		this.projectile = projectile;
		timerReset = fireRate;
		timer = timerReset;
	}

	public void Attack () {
		anim.Attack ();
	}

	public GameObject GetCurrentWeapon() {
		return currentWeapon;
	}

	public void DropWeapon () {
		currentWeapon.transform.position = this.transform.position;
		currentWeapon.SetActive (true);
		SetWeapon (null, "", 0.5f, false);
	}
}
