using UnityEngine;
using System.Collections;

public class ControllerState2D{
	public bool isCollidingLeft { get; set; }
	public bool isCollidingRight { get; set; }
	public bool isCollidingAbove { get; set; }
	public bool isCollidingBelow { get; set; }
	public bool isMovingDownSlope { get; set; }
	public bool isMovingUpSlope { get; set; }
	public bool isGrounded { get{ return isCollidingBelow; } }
	public float SlopeAngle { get; set; }
	public bool HasCollision{ get { return isCollidingLeft || isCollidingRight || isCollidingAbove || isCollidingBelow;  } }
	
	public void Reset() {
		isMovingUpSlope =
			isMovingDownSlope =
			isCollidingLeft =
			isCollidingRight =
			isCollidingAbove =
			isCollidingBelow = false;
	}
	public override string ToString(){
		return string.Format(
			"controller: r:{0}, l: {1}, a: {2}, b: {3}, down-slope:{4}, up-slope: {5}, angle: {6}",
			isCollidingRight,
			isCollidingLeft,
			isCollidingAbove,
			isCollidingBelow,
			isMovingDownSlope,
			isMovingUpSlope,
			SlopeAngle
		);

	}

}
