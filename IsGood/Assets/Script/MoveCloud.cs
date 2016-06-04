using UnityEngine;
using System.Collections;

public class MoveCloud : MonoBehaviour {
	
	public Transform cloud;
	public Transform origin;
	public Transform destine;

	public float loopTime;

	private bool enable;
	private float frameTime;


	// Use this for initialization
	void Start () {
		frameTime = 0.2f;
		StartCoroutine( "Run" );	
	}

	IEnumerator Run() {
		while (true) {
			yield return new WaitForSeconds(frameTime);
			Move ();
		}
	}

	void Move () {
		cloud.position = Vector3.Lerp (origin.position, destine.position, 1f);
		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
