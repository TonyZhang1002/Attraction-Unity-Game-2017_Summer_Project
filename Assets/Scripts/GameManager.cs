using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject bigBall;
    public GameObject smallBall;
    public List<GameObject> endList;
	public LayerMask blockingLayer;
    ParticleSystem hitParticles;
    AudioSource deadAudio;
    public static GameManager instance = null;

    private float camRayLength = 1000f;
    private Vector3 currentSmallPosition;
    private Vector3 hitBigBallPosition;
    private bool stopPar;
    private bool canCreate;
    private GameObject endText;
    private GameObject button;

    void Start () {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        endList.Clear ();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        stopPar = false;
        canCreate = true;
        deadAudio = GetComponent<AudioSource>();
        endText = GameObject.Find("EndText");
        endText.SetActive(false);
        button = GameObject.Find("Button");
        button.SetActive(false);
    }

	void Update () {
		if(Input.GetButtonDown ("Fire1")){
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                OnHit();
            }
		}

        if (smallBall != null)
        {
            currentSmallPosition = smallBall.transform.position;
        }
        else if (smallBall == null && stopPar == false)
        {
            hitBigBallPosition = SmallBall.hitBigBallPosition;
            hitParticles.transform.position = currentSmallPosition;
            Vector3 relativePos = currentSmallPosition - hitBigBallPosition;
            hitParticles.transform.rotation = Quaternion.LookRotation(relativePos);
            hitParticles.Play();
            deadAudio.Play();
            stopPar = true;
        }
        else {
            return;
        }
	}

	void OnHit() {

		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		if (Physics.Raycast (camRay, out floorHit, camRayLength, blockingLayer) && canCreate) {
			//Debug.Log ("Hit");
			if (floorHit.collider.gameObject.tag == "End")
            {
                Destroy(floorHit.collider.gameObject);
            }
            else
            {
                Instantiate(bigBall, floorHit.point, Quaternion.identity);
            }
		}else{
			//Debug.Log ("Not Hit");
		}
	}

    public void Restart() {
        endText.SetActive(true);
        button.SetActive(true);
        canCreate = false;
    }

    public void clickRestart() {
        SceneManager.LoadScene(0);
    }
}

