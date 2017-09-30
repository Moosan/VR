using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakController : MonoBehaviour {

    Rigidbody rigid;
    float velocity;
    public float speed;

    public GameObject frag;
    public GameObject Obj;

	void Start () {
        rigid = this.GetComponent<Rigidbody>();
	}
	
	void Update () {
        velocity = rigid.velocity.magnitude;
	}

    void OnCollisionEnter(Collision collision)
    {
        if(velocity > speed)
        {
            GameObject tmpFrag = (GameObject)Instantiate(frag, transform.position, Quaternion.identity);
            if (Obj != null) Instantiate(Obj, transform.position, transform.rotation);
            Destroy(tmpFrag, 1.5f);
            Destroy(gameObject);
        }
    }
}
