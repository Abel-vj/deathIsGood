using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	int totalPlayers;
	int maxPlayers = 2;

	public InputController inputControllerP1;
	public InputController inputControllerP2;

	public GameObject countDownSprite3;
	public GameObject countDownSprite2;
	public GameObject countDownSprite1;
	public GameObject countDownSprite0;

	public bool countDownEnabled = true;

	private GameObject[] countDownSprites = new GameObject[4];

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

		countDownSprites [0] = countDownSprite0;
		countDownSprites [1] = countDownSprite1;
		countDownSprites [2] = countDownSprite2;
		countDownSprites [3] = countDownSprite3;

		StartCoroutine( "CountDown" );
	}

	IEnumerator CountDown() {

		if (countDownEnabled) {
			for (int i = 3; i >= -1 ; i--) {
				yield return new WaitForSeconds(1f);

				if (i != -1) {
					countDownSprites [i].SetActive (true);
				}
				if (i != 3) {
					countDownSprites [i + 1].SetActive (false);
				}
			}

		}
		inputControllerP1.StartGame ();
		inputControllerP2.StartGame ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
