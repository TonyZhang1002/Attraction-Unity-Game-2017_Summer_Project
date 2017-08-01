using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBall : MonoBehaviour {

    public int rotateSpeed = 40;
    public int grav = 5;

	private GameObject smallBall;
	private float gravitationalForce;
	private Vector3 directionBetween;
	private Rigidbody rb;

    // Use this for initialization
    void Start () {
		directionBetween = Vector3.zero;
		smallBall = GameObject.FindGameObjectWithTag ("Player");
		rb = smallBall.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        if (smallBall != null) {
            gravitationalForce = grav / Mathf.Sqrt(Vector3.Distance(transform.position, smallBall.transform.position));
            directionBetween = (transform.position - smallBall.transform.position).normalized;
			rb.AddForce (directionBetween * gravitationalForce);
		}
	}
}
