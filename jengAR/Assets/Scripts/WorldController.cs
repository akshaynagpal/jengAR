using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

	Vector3 nextPos;
	private Vector3 moveDelta;
	public Vector3 initMoveDelta;
	public Vector3 moveDeltaDelta;

	private int moveType;

	public GameObject tower;

	// Use this for initialization
	void Start () {
		nextPos = transform.localPosition;
		moveDelta = initMoveDelta;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition += moveType * moveDelta;
		moveDelta += moveDeltaDelta;
	}

	public void BeginUp() {
		moveType = 1;
		foreach (Transform block in tower.transform) {
			block.GetComponent<forkBlockCollission> ().gravityDisable(true);
		}
	}

	public void BeginDown() {
		moveType = -1;
		foreach (Transform block in tower.transform) {
			block.GetComponent<forkBlockCollission> ().gravityDisable(true);
		}
	}

	public void EndMove() {
		moveType = 0;
		foreach (Transform block in tower.transform) {
			block.GetComponent<forkBlockCollission> ().gravityDisable(false);
		}
		moveDelta = initMoveDelta;
	}
}
