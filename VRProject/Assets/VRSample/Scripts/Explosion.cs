using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;
public class Explosion : MonoBehaviour {
    public float coefficient;   // 空気抵抗係数
    public float speed;         // 爆風の速さ
    private new Rigidbody rigidbody { get; set; }
    private bool Bombing;
    private float time;
    public SteamVR_Controller.Device Device;
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
        if (Bombing)
        {
            SteamVR_Controller.Device device1, device2;
            device1 = SteamVR_Controller.Input(4);
            device2 = SteamVR_Controller.Input(5);
            device1.TriggerHapticPulse((ushort)(500 + (2 - time) * 2000));
            device2.TriggerHapticPulse((ushort)(500 + (2 - time) * 2000));
        }
    }
}
