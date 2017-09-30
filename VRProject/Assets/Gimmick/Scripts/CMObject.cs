using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMObject : MonoBehaviour {

    Vector3 startPos;

	void Start () {
        startPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= 0)
        {
            Vector3 tmpPos = transform.position;
            transform.position = new Vector3(tmpPos.x, startPos.y, tmpPos.z);
        }
    }
}
