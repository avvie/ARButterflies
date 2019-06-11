using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class RaycastComponent : MonoBehaviour
{

    public GameObject Indicator;
    public Camera main;
    public DirectionVectorCreatorHalfSphere sdadsa;
    ARRaycastManager raycastMan;
    List<ARRaycastHit> results = new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Start()
    {
        raycastMan = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if(raycastMan.Raycast(new Vector2(Screen.width/2,Screen.height/2), results) || Input.anyKey)
        {
            Indicator.SetActive(true);
#if !UNITY_EDITOR
            Indicator.transform.SetPositionAndRotation(results[0].pose.position, results[0].pose.rotation);
#endif
            if (Input.touches.Length > 0 || Input.anyKey)
            {
                sdadsa.start = true;
                GetComponent<RaycastComponent>().enabled = false;
            }
        }
        else
        {
            Indicator.SetActive(false);
        }
        
    }
}
