using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class keyscript : MonoBehaviour {

    public Ray ray;
    public Ray rayItem;
    public RaycastHit hit;
    public GameObject selectedGameObject;
    public GameObject item_key;

    void Start()
    {
        item_key = GameObject.Find("key");
        item_key.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
                searchRoom();
        }
    }

    public void searchRoom()
    {
        selectedGameObject = null;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 10000000, 1 << 8))
        {
            selectedGameObject = hit.collider.gameObject;
            switch (selectedGameObject.name)
            {
                case "redSwitch":
                    item_key.SetActive(true);
                    break;
            }
        }
    }
}

