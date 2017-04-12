using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCamera : MonoBehaviour {

    public GameObject tower;

    private void Start()
    {
    }
    void  Update()
    {
        transform.LookAt(tower.gameObject.transform);
        transform.Translate(Vector3.right * Time.deltaTime);
    }
}
