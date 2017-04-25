﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class groundPlaneDetect : MonoBehaviour, ITrackableEventHandler
{
    public GameObject tower;
    bool firstTrack;
    private TrackableBehaviour mTrackableBehaviour;
    // Use this for initialization
    void Start () {
        tower.SetActive(false);
        firstTrack = true;
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus,TrackableBehaviour.Status newStatus)
    {
        if (firstTrack && newStatus == TrackableBehaviour.Status.DETECTED ||
        newStatus == TrackableBehaviour.Status.TRACKED ||
        newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // View cube when imagetarget is found
            tower.SetActive(true);
            firstTrack = false;
        }
        else
        {
            // Todo
            
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
