using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool moveFlag = false;
    private Camera mainCam;
    private GameObject moveOb;

	void Start () {
        mainCam = Camera.main;
	}
	
	void Update () {
        Rotate((int)Input.GetAxisRaw("Horizontal"));
        if (Input.GetKeyDown(KeyCode.Mouse0)) CheckOb();
        if (moveFlag) MoveOb(moveOb);

        
	}

    void Rotate(int rot)
    {
        if (rot == 0) return;

        Vector3 rotation = this.transform.rotation.eulerAngles;
        rotation.y += rot;
        this.transform.rotation = Quaternion.Euler(rotation);
    }
    void CheckOb()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            GameObject hitOb = hit.collider.gameObject;

            if (!hitOb.CompareTag("CanMove")) return;

            moveFlag = true;
            moveOb = hitOb;
            moveOb.GetComponent<Rigidbody>().isKinematic = true;

            //Debug.Log(hit.collider.gameObject.name);
        }
    }
    void MoveOb(GameObject moveOb)
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) || moveOb == null)
        {
            moveFlag = false;
            moveOb.GetComponent<Rigidbody>().isKinematic = false;
            moveOb = null;
            return;
        }

        Vector3 tmpPos = Input.mousePosition;
        tmpPos.z = 5.0f;
        Vector3 obPos = mainCam.ScreenToWorldPoint(tmpPos);
        moveOb.transform.position = obPos + mainCam.transform.forward;
        
        //Debug.Log(obPos.x + " " + obPos.y + " " + obPos.z);
    }
}
