using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forkBlockCollission : MonoBehaviour {

    Vector3 tempForkPosition, currentForkPosition, diffForkPosition;
    public bool forked;
    public GameObject fork;
    public GameObject releaseButton;

	// Use this for initialization
	void Start () {
        forked = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (forked)
        {
            currentForkPosition = fork.transform.position;
            diffForkPosition = currentForkPosition - tempForkPosition;
            this.transform.position += diffForkPosition;
            tempForkPosition = currentForkPosition;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (ReleaseButtonScript.selectionMode && other.gameObject.name == "Fork" && forked == false && ReleaseButtonScript.forkedBlock==null)
        {
            Debug.Log("BLOCK Touched");
            ReleaseButtonScript.selectionMode = false;
            other.isTrigger = false;
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            fork = other.gameObject;
            releaseButton.SetActive(true);
            ReleaseButtonScript.forkedBlock = this.gameObject;
            tempForkPosition = fork.transform.position;
            forked = true;
        }

        if (other.gameObject.CompareTag("gameOverZone") && forked == false)
        {
            Debug.Log("GAME OVER");
        }
    }

    public void forkDisable()
    {
        fork.GetComponent<Collider>().isTrigger = true;
        forked = false;
    }
}