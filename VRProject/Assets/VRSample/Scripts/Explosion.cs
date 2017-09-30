﻿using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    public float coefficient;   // 空気抵抗係数
    public float speed;         // 爆風の速さ
    private new Rigidbody rigidbody { get; set; }
    private bool Bombing;
    private float time;
    
    void OnTriggerStay(Collider col)
    {
        if (Bombing)
        {
            rigidbody = col.GetComponent<Rigidbody>();
            if (rigidbody == null)
            {
                return;
            }

            // 風速計算
            var velocity = (col.transform.position - transform.position).normalized * speed;

            // 風力与える
            rigidbody.AddForce(coefficient * velocity);
        }
    }
    void Start() {
        time = 0;
        Bombing = false;
    }

    void Update() {
        time += Time.deltaTime;
        if (time >= 1&&!Bombing) {
            Bombing = true;
        }
    }
}
