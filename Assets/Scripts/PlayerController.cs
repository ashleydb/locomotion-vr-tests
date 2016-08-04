using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;	// Reference to the physics component of this object
	public float speed;		// Public so we can set this in the inspector in the Unity Editor. 10 is good.
	private Vector3 moveTowardsPosition; // Position that could be passed in from Gaze, Touch, Mouse to move the player towards
	private bool shouldMove; // Only move after a player clicks/taps, not each frame

	public GameObject viewMarker; // Object representing the view marker to show in the world
	public float maxRange = 0.5f; // What we consider close enough to be considered at the view marker when moving

	// Called on first frame this script is active, (i.e. first frame of game)
	void Start() {
		rb = GetComponent<Rigidbody>();
		shouldMove = false;
	}

	// Happens just before Physics calculations
	void FixedUpdate() {
		// If we got input from clicks, taps or cardboard, move towards it. Otherwise, see if there is keyboard/gamepad input.
		if (shouldMove) {
			// Get a vector from the player position to the point passed in
			Vector3 movement = moveTowardsPosition - gameObject.transform.position;
			// Ignore the y movement
			movement.y = 0; //gameObject.transform.position.y;

			// Stop any current movement
			rb.velocity = Vector3.zero;

			// Multiply the input vector by the object's speed, then apply that result as a force to the object to move it
			rb.AddForce (movement * speed);

			// Don't do this every frame, only when we've been sent a new position, (e.g. OnClick)
			shouldMove = false;
		} else {
			// If the player is at the marker, stop them moving
			Vector3 heading = moveTowardsPosition - gameObject.transform.position;
			heading.y = 0;
			if (heading.sqrMagnitude < maxRange * maxRange) {
				// Player is pretty much at the view marker. Stop them moving.
				rb.velocity = Vector3.zero;
			}
		}
	}

	public void SetMoveTowardsPoint(Vector3 worldPosition) {
		moveTowardsPosition = worldPosition;
		shouldMove = true;
	}
}
