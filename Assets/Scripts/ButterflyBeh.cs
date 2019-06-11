using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyBeh : MonoBehaviour
{
    public Vector3 direction;
    public Camera cam;
    public bool start = true;
    Vector3 parrallelDirection, mainDir, PlacementIndicatorPos;

    Vector3 POI;

    private void Start()
    {
        cam = CamReturn.Instance.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {
            mainDir = cam.transform.position - PlacementIndicatorPos;
            mainDir = mainDir.normalized;
            transform.position = Vector3.Lerp(transform.position, transform.position + mainDir, Time.deltaTime * 0.3f);
            transform.forward = Vector3.Lerp(transform.forward, transform.position - PlacementIndicatorPos, Time.deltaTime * 1);
            Debug.DrawLine(transform.position, (transform.position + Vector3.up).normalized * Vector3.Distance(POI, transform.position), Color.green);
            Debug.DrawLine(transform.position, (transform.position + mainDir) * Vector3.Distance(cam.transform.position, transform.position), Color.red);
            
            if (Vector3.Distance(POI, transform.position) > 5 || Vector3.Distance(cam.transform.position, transform.position) < 0.8f)
            {
                ButterflyCounter.Instance.Counter--;
                Destroy(gameObject);
            }
        }
    }

    public void StartSpawn()
    {
        StartCoroutine(MoveAlong());
    }

    IEnumerator MoveAlong()
    {
        float time = 1.5f + Random.Range(-1.2f,1f);
        float accum = 0;
        while(accum <= time)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + direction, Time.deltaTime * 0.5f);
            transform.forward = Vector3.Lerp(transform.forward, direction, Time.deltaTime * 1);
            Debug.DrawLine(transform.position, (transform.position + direction).normalized * accum, Color.blue);
            accum += Time.deltaTime;
            yield return null;
        }
        POI = transform.position;
        PlacementIndicatorPos = transform.parent.parent.position;
        start = false;

    }
}
