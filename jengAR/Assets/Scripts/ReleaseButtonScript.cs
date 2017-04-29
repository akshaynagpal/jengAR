using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseButtonScript : MonoBehaviour {
    public GameObject releaseButton;
    public static  GameObject forkedBlock;
    public GameObject fork;
    public GameObject selectButton;
    public static bool selectionMode;

    // Use this for initialization
    void Start () {
        forkedBlock = null;
        releaseButton.SetActive(false);
        selectionMode = false;
        selectButton.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void releaseButtonDisappear()
    {
        releaseButton.SetActive(false);
        selectButton.SetActive(true);
    }

    public void releaseBlock()
    {
        forkedBlock.GetComponent<Rigidbody>().useGravity = true;                // activate gravity
        forkedBlock.GetComponent<Rigidbody>().isKinematic = false;              // deactivate kinematics
        forkedBlock.GetComponent<forkBlockCollission>().forkDisable();          // call function in other file
        forkedBlock = null;
    }

    public void toggleSelectionMode(bool t)
    {
        selectionMode = t;
        selectButton.SetActive(!t);
    }
}