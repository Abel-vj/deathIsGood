using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	public Transform tPlayer;
	public int speed;
	public int idPlayer;

	// Use this for initialization
	void Start () {
		Debug.Log(" Hola mundo ");
	}

	// Update is called once per frame
	void Update () {
		int moveX = (int) Input.GetAxis ("MoveX_P" + idPlayer); 
		int moveY = (int) Input.GetAxis ("MoveY_P" + idPlayer); 
		Debug.Log( moveX + " - " + moveY );

		Vector3 position = tPlayer.position;
		position.x += speed * Time.deltaTime * moveX;
		position.y += speed * Time.deltaTime * moveY;

		tPlayer.position = position;
	}
}
