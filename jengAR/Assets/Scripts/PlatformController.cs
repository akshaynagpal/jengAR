using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

	public GameObject block;
	private float blockHeight;

	public GameObject ground;

	private int floor;

	private GameObject[] indicators;

	public GameObject camera;

	// Use this for initialization
	void Start () {
		blockHeight = block.GetComponent<Renderer> ().bounds.size.y;
		indicators = GameObject.FindGameObjectsWithTag ("LvlIndicator");
		floor = 0;
	}
	
	// Update is called once per frame
	void Update () {
		floor = (int)((transform.localPosition.y - ground.transform.localPosition.y) / blockHeight);
		foreach (GameObject indicator in indicators) {
			indicator.GetComponent<TextMesh> ().text = floor.ToString ();
		}
	}
}
