using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private bool _isFacingRight;
	private CharacterController2D _controller;
	private float _normalizedHotizontalSpeed;
	public float MaxSpeed = 8;
	public float SpeedAccelerationOnGround = 10f;
	public float SpeedAccelerationOnAir = 5f;

	public void Start(){
		_controller = GetComponent<CharacterController2D>();
		_isFacingRight = transform.localScale.x > 0;
	}

	public void Update(){
		HandleInput ();

		var movementFactor = _controller.State.isGrounded ? SpeedAccelerationOnGround : SpeedAccelerationOnAir;
		_controller.SetHorizontalForce (Mathf.Lerp (_controller.Velocity.x, _normalizedHotizontalSpeed * MaxSpeed, Time.deltaTime * movementFactor));
	}

	private void HandleInput(){

		if (Input.GetKey (KeyCode.D)) {
			_normalizedHotizontalSpeed = 1;
			if (!_isFacingRight) {
				Flip ();
			}
		} else if (Input.GetKey (KeyCode.A)) {
			_normalizedHotizontalSpeed = -1;
			if (_isFacingRight) {
				Flip ();
			}

		} else {
			_normalizedHotizontalSpeed = 0;
		}

		if (_controller.CanJump && Input.GetKeyDown (KeyCode.Space)) {
			_controller.Jump ();
		}
	}

	private void Flip(){
		transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		_isFacingRight = transform.localScale.x > 0;
	}
}
