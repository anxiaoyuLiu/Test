using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {
    public Transform playerweizhi;
    private Vector3 juli;
	// Use this for initialization
	void Start () {
        juli= transform.position - playerweizhi.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = playerweizhi.position + juli;
	}
}
