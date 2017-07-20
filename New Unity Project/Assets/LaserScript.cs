using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public float range = 20.0f;

    LineRenderer line;

	// Use this for initialization
	void Start ()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
        StopCoroutine("FireLaser");
        StartCoroutine("FireLaser");
	}

    void FixedUpdate()
    {
        line.transform.Rotate(0.0f, rotationSpeed, 0.0f);
    }

    IEnumerator FireLaser()
    {
        line.enabled = true;

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        line.SetPosition(0, ray.origin);

        if (Physics.Raycast(ray, out hit, range))
        {
            line.SetPosition(1, hit.point);

            if (hit.rigidbody)
            {
                if (hit.rigidbody.tag[0].Equals('P') && hit.rigidbody.tag.Length == 2)
                {
                    // TODO
                    Debug.Log("Hit");
                }
            }
        }
        else
            line.SetPosition(1, ray.GetPoint(range));

        yield return null;

        line.enabled = false;
    }
}
