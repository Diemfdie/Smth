using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public float transitionSpeed = 1.0f;


    bool centerTransition = true;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag[0].Equals('P') && other.tag.Length == 2)
        {
            centerTransition = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag[0].Equals('P') && other.tag.Length == 2)
        {
            // Stop Player Movement
            // TODO
            other.GetComponent<Player>().DisableMoving();


            // Player Transition
            BoxCollider player = other.GetComponent<BoxCollider>();
            BoxCollider arrow = gameObject.GetComponent<BoxCollider>();

            if (centerTransition)
                other.transform.position = Vector3.MoveTowards(other.transform.position, new Vector3(arrow.bounds.center.x, other.transform.position.y, arrow.bounds.center.z), Time.deltaTime * transitionSpeed);


            if (Mathf.Abs(other.transform.position.z - new Vector3(arrow.bounds.center.x, other.transform.position.y, arrow.bounds.center.z).z) <= 0.01f &&
                Mathf.Abs(other.transform.position.x - new Vector3(arrow.bounds.center.x, other.transform.position.y, arrow.bounds.center.z).x) <= 0.01f && centerTransition == true)
            {
                centerTransition = false;
            }

            if (!centerTransition)
                Move(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag[0].Equals('P') && other.tag.Length == 2)
        {
            other.GetComponent<Player>().EnableMoving();
            centerTransition = true;
        }
    }

    void Move(Collider other)
    {
        
        foreach (Transform t in transform)
        {
            if (t.name.Equals("Collider"))
            {
                BoxCollider arrow = t.GetComponent<BoxCollider>();


                if (transform.rotation.eulerAngles.y == 0)
                {
                    other.transform.position = Vector3.MoveTowards(other.transform.position, new Vector3((arrow.bounds.max - arrow.bounds.min).x, 0.0f, 0.0f) + other.transform.position, Time.deltaTime * transitionSpeed);
                }
                else if ((transform.rotation.eulerAngles.y < 91 && transform.rotation.eulerAngles.y > 89) || (transform.rotation.eulerAngles.y < -269 && transform.rotation.eulerAngles.y > -271))
                {
                    other.transform.position = Vector3.MoveTowards(other.transform.position, -new Vector3(0.0f, 0.0f, (arrow.bounds.max - arrow.bounds.min).z) + other.transform.position, Time.deltaTime * transitionSpeed);
                }
                else if ((transform.rotation.eulerAngles.y < 181 && transform.rotation.eulerAngles.y > 179) || (transform.rotation.eulerAngles.y < -179 && transform.rotation.eulerAngles.y > -181))
                {
                    other.transform.position = Vector3.MoveTowards(other.transform.position, -new Vector3((arrow.bounds.max - arrow.bounds.min).x, 0.0f, 0.0f) + other.transform.position, Time.deltaTime * transitionSpeed);
                }
                else if ((transform.rotation.eulerAngles.y < 271 && transform.rotation.eulerAngles.y > 269) || (transform.rotation.eulerAngles.y < -89 && transform.rotation.eulerAngles.y > -91))
                {
                    other.transform.position = Vector3.MoveTowards(other.transform.position, new Vector3(0.0f, 0.0f, (arrow.bounds.max - arrow.bounds.min).z) + other.transform.position, Time.deltaTime * transitionSpeed);
                }
            }
        }
        
    }
}
