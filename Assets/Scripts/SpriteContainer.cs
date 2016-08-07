using UnityEngine;
using System.Collections;

public class SpriteContainer : MonoBehaviour {

	public Sprite[] pLegs, pUnarmedWalk;

	public Sprite[] GetPlayerLegs () {
		return pLegs;
	}

	public Sprite[] GetPlayerUnarmedWalk () {
		return pUnarmedWalk;
	}
}
