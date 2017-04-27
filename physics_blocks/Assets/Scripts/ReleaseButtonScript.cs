using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseButtonScript : MonoBehaviour {
    public GameObject releaseButton;
    public static  GameObject forkedBlock;
    public GameObject fork;

    // Use this for initialization
    void Start () {
        forkedBlock = null;
        releaseButton.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void releaseButtonDisappear()
    {
        releaseButton.SetActive(false);
    }

    public void releaseBlock()
    {
        forkedBlock.GetComponent<Rigidbody>().useGravity = true;
        forkedBlock.GetComponent<Rigidbody>().isKinematic = false;
        forkedBlock.GetComponent<forkBlockCollission>().forkDisable();
        forkedBlock = null;
    }
}