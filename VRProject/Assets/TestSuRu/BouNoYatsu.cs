using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;

public class BouNoYatsu : VRObjectBase {
    private bool Picked { get; set; }
    public override void Awake()
    {
        base.Awake();
        Picked = false;
        GetComponent<Throwable>().attachEaseIn = true;
    }

    private Vector3 swordPos;

    void Start()
    {
        swordPos = transform.position;
    }

    private Vector3 Pos0, Pos1;
    private Vector3 Velocity;
    public void Update()
    {
        if (Picked)
        {
            Pos1 = transform.parent.transform.position;
            Velocity = (Pos1 - Pos0) / Time.deltaTime;
        }
        Pos0 = transform.position;
    }
    void OnCollisionStay(Collision other)
    {
        Debug.Log(other.gameObject.name);
        if (other.transform.tag == "VRItem" && Picked)
        {
            Debug.Log("aaaaaaaaaaaaaaaaaaa");

            transform.position = swordPos;
            Picked = false;
            Device.TriggerHapticPulse(2000);
            Hand.DetachObject(this.gameObject);
        }
    }
    public void PickUp()
    {
        Debug.Log("Pick");
        Picked = true;
    }
    public void ThrowAway()
    {
        Picked = false;
    }
}
