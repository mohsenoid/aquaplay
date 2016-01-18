using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tunnel : MonoBehaviour
{
//		List<GameObject> gameObjects = new List<GameObject> ();
		public float speed = 50000;
		public ParticleSystem bubbles;
//		int objectsInTrigger = 0;
//		public Transform cap;
	
		void OnUpdate ()
		{
		}
	
		void OnTriggerEnter (Collider other)
		{          
				GameObject gObject = other.transform.parent.gameObject;
				if (gObject.tag == "Player") {
						//objectsInTrigger++;
						gObject.tag = "Rock";
						//print (gObject.tag);
						//gameObjects.Add (gObject);
//						print ("Object name : " + gObject);
				}
		}
		
		void OnTriggerExit (Collider other)
		{
				GameObject gObject = other.transform.parent.gameObject;
				if (gObject.tag == "Rock") {
						//objectsInTrigger--;
						//gameObjects.Remove (gObject);
						gObject.tag = "Player";
//						print ("Object name : " + gObject);
				}
		}
	
		void startPresure ()
		{
//				print ("startPresure!");
				//foreach (GameObject gObject in GameObject.FindGameObjectsWithTag("Player")) {

				foreach (GameObject gObject in GameObject.FindGameObjectsWithTag("Rock")) {
						//print (gObject);
						//if (gObject.rigidbody.velocity.y <= 0) {
						//float factor = //(gObject.transform.position.z - cap.position.z) *
						//1000f;
						//print (gObject.rigidbody.velocity.y);
						//if (gObject.rigidbody.velocity.y < -1)
						//float factor = cap.position.z - transform.position.z;
						gObject.GetComponent<Rigidbody>().AddForce (Vector3.up * speed * Time.deltaTime);
						//}
						gObject.GetComponent<Rigidbody>().AddTorque (Vector3.up * Time.deltaTime);
				}

				if (bubbles.isPlaying)
						bubbles.Stop ();
				bubbles.Play ();
		}
}
