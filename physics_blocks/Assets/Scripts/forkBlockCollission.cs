using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forkBlockCollission : MonoBehaviour {

    Vector3 tempForkPosition, currentForkPosition, diffForkPosition;
    bool forked;
    GameObject fork;
    

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
        if (other.gameObject.name == "Fork" && forked == false)
        {
            Debug.Log("BLOCK Touched");
            other.isTrigger = false;
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            fork = other.gameObject;
            tempForkPosition = fork.transform.position;
            forked = true;
        }
    }

}
