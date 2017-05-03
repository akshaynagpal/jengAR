using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReleaseButtonScript : MonoBehaviour {
    public GameObject releaseButton;
    public GameObject helpButton;
    public Text helpButtonText;
    public GameObject helpPanel;
    public static  GameObject forkedBlock;
    public GameObject fork;
    public GameObject selectButton;
    public static bool selectionMode;
	public GameObject upButton;
	public GameObject downButton;

    // Use this for initialization
    void Start () {
        forkedBlock = null;
        releaseButton.SetActive(false);
        selectionMode = false;
        selectButton.SetActive(true);
        helpButton.SetActive(true);
        helpPanel.SetActive(false);
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
        forkedBlock.GetComponent<forkBlockCollission>().unHighlightObject();          // call unhighlight function in other file
        forkedBlock = null;
    }

    public void toggleSelectionMode(bool t)
    {
        selectionMode = t;
        selectButton.SetActive(!t);
    }

	public void switchButtonsUp(bool enable)
	{
		if (!enable) {
			downButton.GetComponent<Button> ().interactable = false;
			selectButton.GetComponent<Button> ().interactable = false;
			helpButton.GetComponent<Button> ().interactable = false;
		} else {
			downButton.GetComponent<Button> ().interactable = true;
			selectButton.GetComponent<Button> ().interactable = true;
			helpButton.GetComponent<Button> ().interactable = true;
		}
	}

	public void switchButtonsDown(bool enable)
	{
		if (!enable) {
			upButton.GetComponent<Button> ().interactable = false;
			selectButton.GetComponent<Button> ().interactable = false;
			helpButton.GetComponent<Button> ().interactable = false;
		} else {
			upButton.GetComponent<Button> ().interactable = true;
			selectButton.GetComponent<Button> ().interactable = true;
			helpButton.GetComponent<Button> ().interactable = true;
		}
	}
		
    public void showHelp()
    {
        if (helpPanel.activeSelf)
        {
            helpButtonText.text = "HELP";
            helpPanel.SetActive(false);
        }
        else
        {
            helpButtonText.text = "CLOSE";
            helpPanel.SetActive(true);
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}