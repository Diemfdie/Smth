using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public bool up = true;
    public float transitionSpeed = 1.0f;
    public float transitionOffset = 0.5f;

    Vector3 upPoint;
    Vector3 downPoint;

	// Use this for initialization
	void Start ()
    {
        downPoint = transform.position;
        downPoint.y -= transitionOffset;

        upPoint = transform.position;

        transform.position = downPoint;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if (up)
        {
            transform.position = Vector3.MoveTowards(transform.position, downPoint, Time.deltaTime * transitionSpeed);

            if (Mathf.Approximately(downPoint.y, transform.position.y))
                up = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, upPoint, Time.deltaTime * transitionSpeed);

            if (Mathf.Approximately(upPoint.y, transform.position.y))
                up = true;
        }
	}

    void OnTriggerStay(Collider other)
    {
        // TODO
        Debug.Log("Hit");
    }
}
