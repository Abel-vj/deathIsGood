using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {
	public Transform optionPlay;
	public Transform optionExit;
	public Transform optionCredits;
	public Transform optionHover;
	public Transform nube1;
	public Transform nube2;
	public Transform nube3;
	private int selected;
	private Transform[] options;

	// Use this for initialization
	void Start () {
		options = new Transform[3];
		options [0] = optionCredits;
		options [1] = optionPlay;
		options [2] = optionExit;
		selected = 1;
		ChangeOption (selected);
	
	}

	void ChangeOption (int position) {
		optionHover.position = options [selected].position;
		optionHover.localScale = options [selected].localScale;
	}

	// Update is called once per frame
	void Update() {
		Vector3 pos = new Vector3(nube1.position.x + 1, 0, 0);
		nube1.position = pos;


		if (Input.GetKeyDown ("space")) {
			if (selected == 0) {
				print("PRINT CREDITS");
			}
			if (selected == 1) {
				Application.LoadLevel("Nivel");
			}
			if (selected == 2) {
				Application.Quit();
			}
		}
			
		if (Input.GetKeyDown ("a")) {
			selected = (selected + 2) % 3;
			ChangeOption (selected);
		}
			
		if (Input.GetKeyDown("d")) {
			selected = (selected + 1) % 3;
			ChangeOption (selected);
		}
	}
}