using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private int countDeath;

	public Transform pointToSpawn;
	public int idPlayer;

	public float speed;
	public float clamSpeed;
	public float forceJump;

	private bool isDead;
	private Transform playerPosition;

	void Start () {
		isDead = false;
		playerPosition = gameObject.transform;

		Spawn();
	}

	public void Kill() {
		if (isDead)
			return;

		isDead = true;
		++countDeath;
		ApplayPowerUps();

		Spawn ();
	}

	public void ApplayPowerUps() {
		//INCREMENTO POWER UPS
	}

	public void Spawn() {
		playerPosition.position = pointToSpawn.position;
		isDead = false;
	}

	public void FinishedRun( int scoreRun ) {
		print ( scoreRun + " posicion del jugador " + idPlayer );
		gameObject.SetActive( false );
	}

}
