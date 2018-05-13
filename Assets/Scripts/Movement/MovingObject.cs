﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : Material {

  //Initialize important variables
  public float speed;
  public float maxVel;
	public Vector2 calcMovement;
	protected bool frozen = false;

	//Every update, the players' movement will be calculated using the ComputeVelo method of the inheriting objects
	void Update() {
		calcMovement = Vector2.zero;
		//Get movement direction and set animator vars
		ComputeVelo();
		UpdateAnimator(calcMovement);
	}

	//Every fixed update, the player will move. This will keep the players' movements uniform regardless of computer lag
    void FixedUpdate () {
		//We don't want our objects to go too fast, so first we must check that the objects' velocity hasn't grown too high
		if (calcMovement.magnitude < maxVel && calcMovement.magnitude > 0.1 && frozen == false) {
			//Move the rigidbody by applying force, and the object will move too
			rb2d.AddForce (calcMovement * speed);//, ForceMode.VelocityChange);
			//Check object's method to see if a vibration should be made - this has been replaced with animator events
			//MakeVibration();
		} else if (calcMovement.magnitude >= maxVel && frozen == false) {
			//If speed is too high, just decrease it to fit the maxvel
			rb2d.AddForce (calcMovement * maxVel / calcMovement.magnitude);//, ForceMode.VelocityChange);
			//Check object's method to see if a vibration should be made - this has been replaced with animator events
			//MakeVibration();
		}
		//Add force to move our character. VelocityChange ignores mass to remove stopping latency
    }

	//The "virtual" is important to show this method will be overriden
	//This is the method that will be overriden in any method that inherits this class. This is how all moving objects decide their move patterns
	protected virtual void ComputeVelo () {}

	//The "virtual" is important to show this method will be overriden
	//This is how all moving objects decide their move animations
	protected virtual void UpdateAnimator (Vector2 direction) {}

	//The "virtual" is important to show this method will be overriden
	//This is how all moving objects decide when vibrations are made
	protected virtual void MakeVibration () {}

  // When a script is called or time is stopped, the player will have to freeze
  public void SetMobility(bool mobility)
  {
    frozen = !mobility;
  }

  //Picks up this object and returns null, telling the program the Use()
  //function cannot be done on this item while in the players' hand
  public override Item pickUp(GameObject holder) {
    //Turn on functionality to attach this object to the player and move where the player does

    //Freeze the object's movements
    SetMobility(false);
    //Return null so this object cannot be "Used" like an item
    return null;
  }

}
