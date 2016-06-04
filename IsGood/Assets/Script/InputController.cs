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

	public int idPlayer;
	public float speed;
	public float clamSpeed;
	public float forceJump;

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
		float moveX = Input.GetAxis( "MoveX_P" + idPlayer ); 
		float moveZ = Input.GetAxis( "MoveZ_P" + idPlayer );

		if ( ICanJump() ) {
			Jump();
		}

		ApplayForce( moveX, moveZ );
		Direction direction = GetDirection( (int) moveX, (int) moveZ );
		SetAnimation( direction );


		playerRigidbody.velocity = Vector3.ClampMagnitude( playerRigidbody.velocity, clamSpeed );

	}

	bool ICanJump() {
		return true;
	}

	void Jump() {
		Vector3 force = new Vector3(0.0f, forceJump, 0.0f);

		//playerRigidbody.AddForce( force );
	}

	void SetAnimation( Direction direction ) {
		if (lastDirection == direction)
			return;

		switch(direction) {
			case Direction.TOP: {
				animatorController.SetTrigger( "TOP" );
				Debug.Log ("TOP");
			}
			break;
			case Direction.BOTTON: {
				animatorController.SetTrigger( "BOTTON" );
				Debug.Log ("BOTTON");

			}
			break;
			case Direction.LEFT: {
				animatorController.SetTrigger( "LEFT" );
				Debug.Log ("LEFT");

			}
			break;
			case Direction.RIGHT: {
				animatorController.SetTrigger( "RIGTH" );
				Debug.Log ("RIGTH");

			}
			break;
			case Direction.NONE: {
				animatorController.SetTrigger( "IDLE" );
				Debug.Log ("IDLE");

			}
			break;
		}

		lastDirection = direction;

	}

	void ApplayForce( float moveX, float moveZ ) {
		if (Mathf.Abs (moveX) == 1 && Mathf.Abs (moveZ) == 1) {
			moveX = moveX * 0.707f;
			moveZ = moveZ * 0.707f;
		}	

		float x = speed * moveX;
		float z = speed * moveZ;

		Vector3 velocity = new Vector3(x, 0.0f, z);

		playerRigidbody.AddForce( velocity );

	}
		
}
