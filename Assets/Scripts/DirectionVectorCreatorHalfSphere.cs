using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionVectorCreatorHalfSphere : MonoBehaviour
{
    public GameObject Prefab;
    public Transform parentTransform;
    public bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        desiredAngle = Mathf.Cos(Mathf.Deg2Rad * DesiredAngle);
        Debug.Log(desiredAngle);
    }

    Vector3 dir, newDir;
    float angle = 0, desiredAngle;
    public float DesiredAngle = 45;
    
    
    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            newDir = Random.insideUnitSphere;
            angle = Vector3.Dot(transform.up, newDir);
            if (Mathf.Abs(angle) >= desiredAngle)
            {
                dir = newDir;

                if (angle < 0)
                {
                    dir *= -1;
                }
                if(ButterflyCounter.Instance.Counter <= 150)
                {
                    ButterflyCounter.Instance.Counter++;
                    GameObject go = Instantiate(Prefab);
                    Debug.Log("Spawned nb " + ButterflyCounter.Instance.Counter);
                    go.transform.parent = parentTransform;
                    go.transform.position = parentTransform.position;
                    go.GetComponentInChildren<ButterflyBeh>().direction = dir;
                    go.GetComponentInChildren<ButterflyBeh>().StartSpawn();
                }
            }
        }
        Debug.DrawLine(transform.position, dir);
    }
}
