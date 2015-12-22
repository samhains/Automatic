using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour {
	private const float SkinWidth = 0.02f;
	private const int TotalHorizontalRays = 8;
	private const int TotalVerticalRays = 4;
	private static readonly float SlopeLimitTangent = Mathf.Tan(75f * Mathf.Deg2Rad);

	public LayerMask PlatformMask;
	public ControllerParameters2D DefaultParameters;

	public ControllerState2D State { get; private set; }

	public Vector2 Velocity { get { return _velocity; } }

	private Vector2 _velocity;
	private Transform _transform;
	private Vector3 _localScale;
	private BoxCollider2D _boxCollider;
	private ControllerParameters2D _overrideParameters;

	private float _verticalDistanceBetweenRays;
	private float _horizontalDistanceBetweenRays;

	public bool CanJump { get{ return false; } }
	public bool HandleCollisions { get; set; }
	public ControllerParameters2D Parameters { get { return _overrideParameters ?? DefaultParameters; } }

	public void Awake(){
		State = new ControllerState2D ();
		_transform = transform;
		_localScale = transform.localScale;
		_boxCollider = GetComponent<BoxCollider2D>();

		// width of the collider times the scaling of the object less the width of the skin on both sides
		var colliderWidth = _boxCollider.size.x * Mathf.Abs (transform.localScale.x) - (2 * SkinWidth);
		var colliderHeight = _boxCollider.size.y * Mathf.Abs (transform.localScale.y) - (2 * SkinWidth);

		_verticalDistanceBetweenRays = colliderHeight / (TotalHorizontalRays - 1) ;
		_horizontalDistanceBetweenRays = colliderWidth / (TotalVerticalRays - 1) ;
	}

	public void AddForce(Vector2 force){
		_velocity += force;
	}

	public void SetForce(Vector2 force){
		_velocity = force;
	}

	public void SetHorizontalForce(float x){
		_velocity.x = x;

	}

	public void SetVerticalForce(float y){
		_velocity.y = y;
	}

	public void Jump(){
	}

	public void LateUpdate(){
		Move (Velocity * Time.deltaTime);
	}

	private void Move(Vector2 deltaMovement){
		var wasGrounded = State.isCollidingBelow;
		State.Reset ();
		if (HandleCollisions) {
			HandlePlatforms ();
			CalculateRayOrigins ();

			if (deltaMovement.y < 0 && wasGrounded) {
				HandleVerticalSlope (ref deltaMovement);
			}
			if (Mathf.Abs (deltaMovement.x) > .001f) {
				MoveHorizontally (ref  deltaMovement);
			}

			MoveVertically (ref deltaMovement);
		}
		_transform.Translate (deltaMovement, Space.World);

		// TODO: Additional moving platform code

		_velocity.x = Mathf.Min (_velocity.x, Parameters.MaxVelocity.x);
		_velocity.y = Mathf.Min (_velocity.y, Parameters.MaxVelocity.y);

		if (State.isMovingUpSlope) {
			_velocity.y = 0;
		}
	}

	private void HandlePlatforms(){
	}

	// precompute where rays are going to be shot out from
	private void CalculateRayOrigins(){
	}

	// deltaMovement refers to the current velocity of the player on that frame
	// this is responsible for making raycasts, needs to constrain or clame ray movement
	// so MoveHorizontally needs to modify the movement based on collisions
	private void MoveHorizontally(ref Vector2 deltaMovement){
	}

	private void MoveVertically(ref Vector2 deltaMovement){
	}

	private void  HandleVerticalSlope(ref Vector2 deltaMovement){
	}

	private void HandleHorizontalSlope(ref Vector2 deltaMovement, float angle, bool isGoingRight){
	}

	public void onTriggerEnter2D(Collider2D other){
	}

	public void onTriggerExit2D(Collider2D other){
	}

}
