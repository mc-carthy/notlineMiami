using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour {

	public string weaponName;
	public float fireRate;
	public bool projectiles;
	//public AudioClip sfx;

	private WeaponAttack weapAtt;

	private void Start () {
		weapAtt = GameObject.FindGameObjectWithTag ("Player").GetComponent<WeaponAttack> ();
	}

	private void OnTriggerStay2D (Collider2D col) {
		if (col.gameObject.tag == "Player" && Input.GetMouseButtonDown (1)) {
			// Add weapon to player
			Debug.Log("Player picked up " + weaponName);
			if (weapAtt.GetCurrentWeapon () != null) {
				weapAtt.DropWeapon ();
			}
			weapAtt.SetWeapon (this.gameObject, weaponName, fireRate, projectiles);
			//Destroy (this.gameObject);
			this.gameObject.SetActive(false);
		}
	}
}
