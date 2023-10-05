using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Fan_Rotation : MonoBehaviour {

	//variable for speed
	private float speed = 0;
	private float accel = 75;
	private float maxSpeed = 500;
	[SerializeField] bool on = false;
	[SerializeField] GameObject audioSource;

	void Start ()
	{
		if (on)
		{
			audioSource.GetComponent<AudioSource>().Play();
		}
	}

	
	void Update () {
		speed = Mathf.Clamp(speed + accel * Time.deltaTime * (on ? 1 : -1), 0, maxSpeed);
		//rotation around z

		transform.Rotate((new Vector3(0,0,1)) * Time.deltaTime*speed); 
	}

	public void setOn(bool on) {
		this.on = on;
		if (on)
		{
			audioSource.GetComponent<AudioSource>().Play();
		} else
		{
			audioSource.GetComponent<AudioSource>().Stop();
		}
	}
}
