using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

	Vector3 nextPos;
	public Vector3 moveDelta;

	private int moveType;

	// Use this for initialization
	void Start () {
		nextPos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition += moveType * moveDelta;
	}

	public void BeginUp() {
		moveType = 1;
	}

	public void BeginDown() {
		moveType = -1;
	}

	public void EndMove() {
		moveType = 0;
	}
}
