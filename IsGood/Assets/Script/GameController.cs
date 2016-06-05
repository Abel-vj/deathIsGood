using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	int totalPlayers;
	int maxPlayers = 2;

	// Use this for initialization
	void Start () {
		totalPlayers = Input.GetJoystickNames().Length;

		GameObject[] players = new GameObject[ maxPlayers ];

		players[0] = player1;
		players[1] = player2;

		for (int i = 0; i < maxPlayers; ++i) {
			players[i].gameObject.SetActive(false);
		}

		for (int i = 0; i < totalPlayers; ++i) {
			players[i].gameObject.SetActive(true);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
