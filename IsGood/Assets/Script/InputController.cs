using UnityEngine;
using System.Collections;

public enum Direction {
	TOP,
	BOTTON,
	LEFT,
	RIGHT,
	NONE
}

public class InputController : MonoBehaviour {
	
	public Rigidbody playerRigidbody;
	public Animator animatorController;
	public DetectElementByTag ground;
	public PlayerController player;

	private Direction lastDirection;

	// Use this for initialization
	void Start () {
		Debug.Log(" Hola mundo ");

		lastDirection = Direction.NONE;
	}

	Direction GetDirection( int x, int z ) {
	
		if (z == 1) {
			return Direction.TOP;

		} else if (z == -1) {
			return Direction.BOTTON;

		} else if (x == -1) {
			return Direction.LEFT;

		} else if (x == 1) {
			return Direction.RIGHT;
		
		} else {
			return Direction.NONE;
		}
			
	}

	// Update is called once per frame
	void Update() {
		float moveX = Input.GetAxis( "MoveX_P" + player.idPlayer ); 
		float moveZ = Input.GetAxis( "MoveZ_P" + player.idPlayer );

		if ( ICanJump () ) {
			Jump( moveX, moveZ );
			print ("CAN D ()"  + ground.IsDetected());
		} else {
			Run( moveX, moveZ );
		}
			
		Direction direction = GetDirection( (int) moveX, (int) moveZ );
		SetAnimation( direction );


		playerRigidbody.velocity = Vector3.ClampMagnitude( playerRigidbody.velocity, player.clamSpeed );

	}

	bool ICanJump() {
		return Input.GetButtonDown( "Jump_P" + player.idPlayer );
	}

	void Jump( float x, float z ) {
		if ( !ground.IsDetected() )
			return;

		Vector3 force = new Vector3(x, player.forceJump, z);

		playerRigidbody.AddForce( force, ForceMode.Impulse );
	}

	void SetAnimation( Direction direction ) {
		if (lastDirection == direction)
			return;

		switch(direction) {
			case Direction.TOP: {
				animatorController.SetTrigger( "TOP" );
				//Debug.Log ("TOP");
			}
			break;
			case Direction.BOTTON: {
				animatorController.SetTrigger( "BOTTON" );
				//Debug.Log ("BOTTON");

			}
			break;
			case Direction.LEFT: {
				animatorController.SetTrigger( "LEFT" );
				//Debug.Log ("LEFT");

			}
			break;
			case Direction.RIGHT: {
				animatorController.SetTrigger( "RIGTH" );
				//Debug.Log ("RIGTH");

			}
			break;
			case Direction.NONE: {
				animatorController.SetTrigger( "IDLE" );
				//Debug.Log ("IDLE");

			}
			break;
		}

		lastDirection = direction;

	}

	void Run( float moveX, float moveZ ) {
		if (Mathf.Abs (moveX) == 1 && Mathf.Abs (moveZ) == 1) {
			moveX = moveX * 0.685f;
			moveZ = moveZ * 0.685f;
		}	

		float x = player.speed * moveX;
		float z = player.speed * moveZ;

		Vector3 velocity = new Vector3(x, 0.0f, z);

		playerRigidbody.AddForce( velocity );

	}
		
}
