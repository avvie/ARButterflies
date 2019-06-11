using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MyComponent : MonoBehaviour
{
    [SerializeField] ARSession m_Session;

    IEnumerator Start()
    {
        if ((ARSession.state == ARSessionState.None ) ||
            (ARSession.state == ARSessionState.CheckingAvailability))
        {
            Debug.Log("Waiting");
            yield return ARSession.CheckAvailability();
            Debug.Log("Done wait");
        }

        if (ARSession.state == ARSessionState.Unsupported)
        {
            Debug.Log("NOT ALL RIGHT!!!");
            // Start some fallback experience for unsupported devices
        }
        else
        {
            // Start the AR session
            Debug.Log("ALL RIGHT!!!");
            m_Session.enabled = true;
        }
    }

    private void Update()
    {
        Debug.DrawLine(transform.position, Camera.main.transform.position - transform.position, Color.magenta);
    }

}
