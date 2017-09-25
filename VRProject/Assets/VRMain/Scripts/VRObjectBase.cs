using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;
/// <summary>
/// VR内で持つことの出来るオブジェクトの基底クラス
/// </summary>
public abstract class VRObjectBase : MonoBehaviour {
    //抽象クラス


    //重さ
    [SerializeField]private float Mass;

    //VRオブジェクト
    private GameObject VRobj { get; set; }

    //transform
    public new Transform transform {
        get {
            if (VRobj)
            {
                return VRobj.transform;
            }
            else {
                return null;
            }
        }
    }

    //gameObject
    public new GameObject gameObject {
        get {
            return VRobj;
        }
    }

    public UnityEvent onPickUp;
    public UnityEvent onDetachFromHand;

    public UnityEvent onHandHoverBegin;
    public UnityEvent onHandHoverEnd;
    public UnityEvent onAttachedToHand;
    public UnityEvent onDetachedFromHand;

    private void Awake()
    {
        if (Mass == 0) {
            Mass = 1;
        }

        var collider = GetComponent<Collider>();
        if (collider==null) {
            Debug.LogError("VRオブジェクトにColliderを付けてください。");
            return;
        }

        var rigidbody = GetComponent<Rigidbody>();
        if (rigidbody!=null) {
            Debug.LogWarning("VRオブジェクトのRigidBodyの初期の設定は再生時には受け継がれません。\nRemoveを推奨します。");
            //受け継がれるようにしようと思ったけど方法を思いつかなかった。
            DestroyImmediate(rigidbody);
        }

        Transform originTransform = GetComponent<Transform>();

        //物体の名前
        var ObjectName = originTransform.name;

        //VRオブジェクト生成
        VRobj = new GameObject(ObjectName);
        transform.position = originTransform.position;
        transform.rotation = originTransform.rotation;
        originTransform.SetParent(VRobj.transform);
        originTransform.localPosition = new Vector3();
        originTransform.localRotation = new Quaternion();

        //RigidBody追加
        Rigidbody rigid = gameObject.AddComponent<Rigidbody>();
        rigid.mass = Mass;

        //VelocityEstimat追加
        gameObject.AddComponent<VelocityEstimator>();
        
        //Interactable追加
        gameObject.AddComponent<Interactable>();


        //Throwable追加
        Throwable thro = gameObject.AddComponent<Throwable>();
        thro.onPickUp = onPickUp;
        thro.onDetachFromHand = onDetachFromHand;

        //InteractableHoverEvents
        InteractableHoverEvents ihe = gameObject.AddComponent<InteractableHoverEvents>();
        ihe.onHandHoverBegin = onHandHoverBegin;
        ihe.onHandHoverEnd = onHandHoverEnd;
        ihe.onAttachedToHand = onAttachedToHand;
        ihe.onDetachedFromHand = onDetachedFromHand;
    }


}
