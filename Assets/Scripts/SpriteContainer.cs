using UnityEngine;
using System.Collections;

public class SpriteContainer : MonoBehaviour {

	public Sprite[] pLegs, pUnarmedWalk, pPunch, pMac10Walk, pMac10Attack, pBowieWalk, pBowieAttack;

	public Sprite[] GetPlayerLegs () {
		return pLegs;
	}

	public Sprite[] GetPlayerUnarmedWalk () {
		return pUnarmedWalk;
	}

	public Sprite[] GetPlayerPunch () {
		return pPunch;
	}

	public Sprite[] GetWeapon (string weapon) {
		switch (weapon) {
		case "Mac10":
			return pMac10Attack;
		case "Bowie":
			return pBowieAttack;
		default:
			return GetPlayerPunch ();
		}
	}

	public Sprite[] GetWeaponWalk (string weapon) {
		switch (weapon) {
		case "Mac10":
			return pMac10Walk;
		case "Bowie":
			return pBowieWalk;
		default:
			return GetPlayerUnarmedWalk ();
		}
	}
}
