using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    Animator anim;

    public bool clicked;

	void Start () {
        anim = GetComponent<Animator>();
	}
	
	void Update () {
        if (clicked) Click();
        if (anim.GetBool("isPush")) Move();
	}

    void Click()
    {
        clicked = false;
        anim.SetTrigger("Pushing");
        Move();
    }
    void SwitchOn()
    {
        anim.SetBool("isPush", true);
        anim.SetTrigger("Pushing");
    }
    void SwitchOff()
    {
        anim.SetBool("isPush", false);
        anim.SetTrigger("Releasing");
    }

    void Move()
    {
        //ボタンが押された時の操作
        Debug.Log("スイッチ起動！");

        if (!anim.GetBool("isPush")) return;
    }

    void OnCollisionEnter(Collision collision)
    {
        SwitchOn();
    }
    void OnCollisionExit(Collision collision)
    {
        SwitchOff();
        Debug.Log("はなれた");
    }
}
