using UnityEngine;
using System.Collections;

public class RingController : MonoBehaviour
{
	
		public Transform cap, floor;
//		Vector3 lastPosition;

		void Update ()
		{
				//GetComponentInChildren<MeshCollider> ().convex = false;

				if (transform.position.y > cap.position.y)
						transform.position = new Vector3 (transform.position.x, cap.position.y, transform.position.z);

				if (transform.position.y < floor.position.y)
						transform.position = new Vector3 (transform.position.x, floor.position.y, transform.position.z);
		}

//		void FixedUpdate ()
//		{
//				//rigidbody.isKinematic=false;
//				
//
//				Vector3 direction = transform.position - lastPosition;
//				Ray ray = new Ray (lastPosition, direction);
//				RaycastHit hit;
//				if (Physics.Raycast (ray, out hit, direction.magnitude)) {
//						// Do something if hit
//						if ((hit.transform.tag.Contains ("Player") || hit.transform.tag.Contains ("Rock")) && hit.transform != this.transform) {
//								hit.transform.rigidbody.AddForce (-direction);
//								//rigidbody.isKinematic = true;
//								GetComponentInChildren<MeshCollider> ().convex = true;
//						} else if (hit.transform.tag.Contains ("Cone")) {
//								GetComponentInChildren<MeshCollider> ().convex = false;
//						}
//
//				}
//		
//				this.lastPosition = transform.position;
//		}
//
//		void OnTriggerEnter (Collider other)
//		{  
//				if (other.tag.Contains ("Cone")) {
//						GetComponentInChildren<MeshCollider> ().convex = false;
//				}
//				
//				if (other.tag.Contains ("Rock") || other.tag.Contains ("Player")) {
//						//rigidbody.isKinematic=true;
//						//GetComponentInChildren<MeshCollider>().convex=false;
//						//other.GetComponentInChildren<MeshCollider>().enabled=false;
//						//other.GetComponentInChildren<MeshCollider>().isTrigger=true;
//						//rigidbody.AddForce(-rigidbody.velocity);
//						//other.transform.parent.rigidbody.AddForce(-other.transform.parent.rigidbody.velocity);
//						//rigidbody.velocity=Vector3.zero;
//						//rigidbody.isKinematic=true;
//						//rigidbody.velocity*=-1;
//				}
//				
//		}
//
//		void OnTriggerExit (Collider other)
//		{  
//		
//				if (other.tag.Contains ("Rock") || other.tag.Contains ("Player")) {
//						//rigidbody.isKinematic=false;
//						//other.GetComponentInChildren<MeshCollider>().isTrigger=false;
//				}
//		}


}