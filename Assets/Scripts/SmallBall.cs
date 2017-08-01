using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBall : MonoBehaviour {

    public static Vector3 hitBigBallPosition;

    //private float forceAmountForRotation = 10;
    //private Vector3 directionBetween;
    private AudioClip dead; 
	private Vector3 forwardDir;
	private bool allowForce;
	private Rigidbody rb;

    

    // Use this for initialization
    void Awake () {

		//directionBetween = Vector3.zero;
		rb = GetComponent<Rigidbody> ();
		forwardDir = rb.transform.right;
		allowForce = true;
        
        //rb.AddForce (forwardDir * 1.5f);
    }
	

	void Update () {



	}

	void FixedUpdate(){
		if (allowForce)
		//rb.AddForce (transform.right * forceAmountForRotation);
			rb.AddForce (forwardDir * 200f);
		allowForce = false;
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "End") {
            hitBigBallPosition = other.transform.position;
            GameManager.instance.Restart();
            Destroy (gameObject);
		}
	}
}