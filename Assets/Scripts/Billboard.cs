using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera m_Camera;

    //very simple y-axis-only billboard script.
    void Update()
      {
          transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
              m_Camera.transform.rotation * Vector3.up);
              Vector3 eulerAngles = transform.eulerAngles;
              eulerAngles.z = 0;
              transform.eulerAngles = eulerAngles;
      }
}
