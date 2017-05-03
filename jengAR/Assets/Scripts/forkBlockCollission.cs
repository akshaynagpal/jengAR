using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forkBlockCollission : MonoBehaviour {

    Vector3 tempForkPosition, currentForkPosition, diffForkPosition;
    public bool forked;
    public GameObject fork;
    public GameObject releaseButton;

	public GameObject platform;
	public GameObject tower;
    public GameObject gameOverPanel;

	public GameObject dummy;

	public GameObject world;

	private bool disableInteractions;
    public Color highlightColor = new Color(0f, 200f, 0f);
	// Use this for initialization
	void Start () {
        forked = false;
        gameOverPanel.SetActive(false);
        disableInteractions = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (forked) {
			currentForkPosition = fork.transform.position;
			diffForkPosition = currentForkPosition - tempForkPosition;
			this.transform.parent = platform.transform;
			this.transform.position += diffForkPosition;
			tempForkPosition = currentForkPosition;
		} else {
			this.transform.parent = tower.transform;
		}
	}

    private void OnTriggerEnter(Collider other)
    {
        if (ReleaseButtonScript.selectionMode && other.gameObject.tag == "Fork" && forked == false && ReleaseButtonScript.forkedBlock==null)
        {
            Debug.Log("BLOCK Touched");
            ReleaseButtonScript.selectionMode = false;
            highlightObject();
            other.isTrigger = false;
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            fork = other.gameObject;
            releaseButton.SetActive(true);
            ReleaseButtonScript.forkedBlock = this.gameObject;
            tempForkPosition = fork.transform.position;
            forked = true;
        }

        if (other.gameObject.CompareTag("gameoverzone") && forked == false)
        {
			if (!disableInteractions) {
				Debug.Log ("GAME OVER");
				gameOverPanel.SetActive (true);
				gameOverOps (true);
			}
        }
    }

    public void forkDisable()
    {
        fork.GetComponent<Collider>().isTrigger = true;
        forked = false;
    }

	public void gravityDisable(bool toDisable)
    {
		this.gameObject.GetComponent<Rigidbody>().useGravity = !toDisable;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = toDisable;
    }

	public void interactionDisable(bool toDisable) {
		disableInteractions = !toDisable;
		gameObject.GetComponent<Collider> ().enabled = false;
	}

    // highlight the selected object
    public void highlightObject()
    {
            Renderer rend = this.gameObject.GetComponent<Renderer>();
            rend.material.color += highlightColor;
            foreach (Renderer r in this.gameObject.GetComponentsInChildren<Renderer>())
            {
                r.material.color += highlightColor;
            }
    }

    public void unHighlightObject()
    {
            Renderer rend = this.gameObject.GetComponent<Renderer>();
            rend.material.color -= highlightColor;
            foreach (Renderer r in this.gameObject.GetComponentsInChildren<Renderer>())
            {
                r.material.color -= highlightColor;
            }
    }

	void gameOverOps(bool enter)
	{
		dummy.GetComponent<ReleaseButtonScript> ().gameOverOps (enter);
		world.GetComponent<WorldSwitch> ().gameOverOps (enter);
	}
}