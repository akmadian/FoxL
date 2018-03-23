using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxBehaviorScript : MonoBehaviour {

	public float turnSpeed = 190f;
	public float walkSpeed = 7f;
	public float runSpeed = 17.5f;
	private float moveSpeed;


	public Animator animator;
	
	void Start(){
		animator = GetComponent<Animator> ();
		//animator ["Running"] = 2.0f;
		moveSpeed = walkSpeed;
	}


	void Update () {
		// Movement
		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * turnSpeed;
		var z = Input.GetAxis ("Vertical") * Time.deltaTime * moveSpeed;

		transform.Rotate (0, x, 0);
		transform.Translate(0, 0, z);


		// Animation
		if (Input.GetKey ("w") && Input.GetKey ("left shift")) {
			animator.Play ("Running", -1);
			moveSpeed = runSpeed;
		}

		if ((Input.GetKeyDown ("w")) || (Input.GetKeyUp("left shift"))) {
			animator.Play ("Walking", -1);
			moveSpeed = walkSpeed;
		}

		if (Input.GetButtonDown("s")){
			animator.Play ("Walking", -1);
		}


		if ((Input.GetKeyUp ("w")) || (Input.GetKeyUp("s"))) {
			animator.Play ("Idle", -1);
			moveSpeed = walkSpeed;
		}
	}
}
