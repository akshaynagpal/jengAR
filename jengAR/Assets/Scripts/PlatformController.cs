using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

	public GameObject block;
	private float blockHeight;

	public GameObject ground;

	private int floor;

	private GameObject[] indicators;
	private Quaternion indicatorRotate;

	public GameObject arCam;

	public GameObject hereDot;
	private Vector3 hereVec;
	private Vector3 lastHereVec;
	private Quaternion hereRotate;

	public GameObject refPoint;
	private Vector3 refVec;

	// Use this for initialization
	void Start () {
		blockHeight = block.GetComponent<Renderer> ().bounds.size.y;
		indicators = GameObject.FindGameObjectsWithTag ("LvlIndicator");
		floor = (int)((transform.position.y - ground.transform.position.y) / blockHeight);
		refVec = refPoint.transform.localPosition - transform.localPosition;

		lastHereVec = arCam.transform.position - transform.position;
		lastHereVec.y = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		hereVec = arCam.transform.position - transform.position;
		hereVec.y = 0.0f;
		hereRotate = Quaternion.AngleAxis (CalculateAngle(refVec, hereVec), Vector3.up);
		Vector3 herePos = hereRotate * refVec;
		herePos.y = 0.2f;
		hereDot.transform.localPosition = herePos;

		floor = (int)((transform.position.y - ground.transform.position.y) / blockHeight);
		indicatorRotate = Quaternion.AngleAxis (CalculateAngle(lastHereVec, hereVec), Vector3.up);
		foreach (GameObject indicator in indicators) {
			indicator.GetComponent<TextMesh> ().text = floor.ToString ();
			indicator.transform.localPosition = indicatorRotate * indicator.transform.localPosition;
		}

		lastHereVec = hereVec;
	}

	// Get the actual [-180, 180] angle between vectors
	float CalculateAngle(Vector3 from, Vector3 to)
	{
		float angle = Vector3.Angle(from, to);

		float sign = Mathf.Sign(Vector3.Dot(Vector3.up, Vector3.Cross(from, to)));
		float signed_angle = angle * sign;

		return signed_angle;
	}
}
