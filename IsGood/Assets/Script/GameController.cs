using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	GameObject player1;
	GameObject player2;
	GameObject player3;
	GameObject player4;

	public int totalPlayers = 2;

	// Use this for initialization
	void Start () {
		GameController[] players = new GameController[ totalPlayers ];
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
