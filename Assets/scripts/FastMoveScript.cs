using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastMoveScript : MonoBehaviour {

	public float cooldown = 3f;
	public float speedFactor = 2;
	public float duration = 0.2f;

	private float showTime = 0;
	private bool pressed = false;
	private bool isCoolDown = false;
	Color initialColor;

	// Use this for initialization
	void Start () {
		initialColor = GetComponent<SpriteRenderer> ().color;
	}
	
	// Update is called once per frame
	void Update () {			
		if (Input.GetKey(KeyCode.Space) && GetComponent<MoveScript> ().speedFactor == 1 && !isCoolDown) {
			GetComponent<MoveScript> ().speedFactor = speedFactor;
			GetComponent<SpriteRenderer> ().color = Color.black;
			Invoke ("ResetSpeed", duration);
		}
	}

	void ResetSpeed() {
		GetComponent<MoveScript> ().speedFactor = 1;
		isCoolDown = true;
		Invoke ("ResetCoolDown", cooldown);
		GetComponent<SpriteRenderer> ().color = initialColor;
	}

	void ResetCoolDown() {
		isCoolDown = false;
	}
}
