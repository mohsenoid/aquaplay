using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{

//	void OnMouseDown ()
//	{
//		print ("Click!");
//		
//		SendMessageUpwards ("startPresure", SendMessageOptions.DontRequireReceiver);
//	}
	
	Vector3 point;
	float duration;
	GameObject gObject;
	float startTime = 0;

	int pressedState;
	private Animator anim;

	public AudioClip bubbleSound;
	public float delay=2;

	void Awake(){
		pressedState=Animator.StringToHash("Pressed");
		anim=GetComponent<Animator>();
	}

	void FixedUpdate ()
	{
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit = new RaycastHit ();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				startTime = Time.time;
				point = hit.point;
				gObject = hit.transform.gameObject;
				print (gObject);
				if (gObject.tag == "GameController"){
					StartCoroutine(buttonPressed());
				}

			}
		} else if (Input.GetMouseButtonUp (0)) {
			duration = Time.time - startTime;
		}
		
		if(Input.GetButtonDown("Fire")){
			StartCoroutine(buttonPressed());
		}
	}

	IEnumerator  buttonPressed(){
		SendMessageUpwards ("startPresure", SendMessageOptions.DontRequireReceiver);
		anim.SetBool(pressedState,true);
		if(GetComponent<AudioSource>().isPlaying)
			GetComponent<AudioSource>().Stop();
		GetComponent<AudioSource>().PlayOneShot(bubbleSound);
		yield return new WaitForSeconds(delay);
	}
}
