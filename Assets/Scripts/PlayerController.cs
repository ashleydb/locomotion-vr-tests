using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // Only move after a player clicks/taps, not each frame
    enum MoveState { SET_VIEW_MARKER = 0, SET_MOVE_POSITION, START_MOVE, MOVING, ERROR };
	private MoveState moveState = MoveState.SET_VIEW_MARKER;

	public Rigidbody rb;	// Reference to the physics component of this object
	public float speed;		// Public so we can set this in the inspector in the Unity Editor. 10 is good.
	private Vector3 moveTowardsPosition; // Position that could be passed in from Gaze, Touch, Mouse to move the player towards
    
	public GameObject viewMarker; // Object representing the view marker to show in the world
	public float maxRange = 0.5f; // What we consider close enough to be considered at "moveTowardsPosition" when moving

    // Called on first frame this script is active, (i.e. first frame of game)
    void Start() {
		rb = GetComponent<Rigidbody>();
		//viewMarker.SetActive (false);
	}

	// Happens just before Physics calculations
	void FixedUpdate() {
		// If we got input from clicks, taps or cardboard, move towards it. Otherwise, see if there is keyboard/gamepad input.
		switch (moveState) {
		case MoveState.SET_VIEW_MARKER:
			break;
		case MoveState.SET_MOVE_POSITION:
			break;

		case MoveState.START_MOVE:
			// Get a vector from the player position to the point passed in
			Vector3 movement = moveTowardsPosition - gameObject.transform.position;
			// Ignore the y movement
			movement.y = 0;

			// Stop any current movement
			rb.velocity = Vector3.zero;

			// Multiply the input vector by the object's speed, then apply that result as a force to the object to move it
			rb.AddForce (movement * speed);

			// Don't do this every frame, only when we've been sent a new position, (e.g. OnClick)
			moveState = MoveState.MOVING;
			break;

		case MoveState.MOVING:
			// If the player is at the marker, stop them moving
			Vector3 heading = moveTowardsPosition - gameObject.transform.position;
			heading.y = 0;
			if (heading.sqrMagnitude < maxRange * maxRange) {
				// Player is pretty much at the view marker. Stop them moving.
				rb.velocity = Vector3.zero;

                    // Rotate to look at the view marker, (potentially lerp this in START_MOVE)
                    Vector3 lookAtPosition = viewMarker.transform.position;
                    lookAtPosition.y = gameObject.transform.position.y;

                gameObject.transform.LookAt (lookAtPosition);

				moveState = MoveState.SET_VIEW_MARKER;

                    // TOOD: Instead of immediately hiding this, make it fade out after a few seconds to help reorient the player?
				//viewMarker.SetActive (false);
			}
			break;
		}
	}

	public void SetPoint(Vector3 worldPosition) {

		switch (moveState) {
		case MoveState.SET_VIEW_MARKER:
			//viewMarker.SetActive (true);
			viewMarker.transform.position = worldPosition;
			moveState = MoveState.SET_MOVE_POSITION;
			break;

		case MoveState.SET_MOVE_POSITION:
			moveTowardsPosition = worldPosition;
			moveState = MoveState.START_MOVE;
			break;
		}

	}
}
