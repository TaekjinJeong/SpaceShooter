using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour {
    public GameObject sparkEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.tag == "BULLET")
        {
            ShowEffect(coll);
            Destroy(coll.gameObject);
        }
    }

    void ShowEffect(Collision coll)
    {
        ContactPoint contact = coll.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, contact.normal);

        GameObject spark = Instantiate(sparkEffect, contact.point, rot);
        spark.transform.SetParent(this.transform);
    }
}
