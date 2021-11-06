using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    public GameObject m_Camera;
    public GameObject ImpObj;
    private Vector3 v3;
    public float v3yf;
    public int v3yi;
    void Start()
    {
        //creating a new vector3 and finding the camera rotation (real pain in the ass)

        v3 = new Vector3(m_Camera.transform.rotation.x, m_Camera.transform.rotation.y, m_Camera.transform.rotation.z);
        m_Camera.transform.rotation = Quaternion.Euler(v3);
    }
    void Update()
    {   
        //v3.y finds camera angles, v3yf is the float that stores the value of v3.y and v3yi is the int version of v3yf
        //(this was a real pain in the ass aswell). and the rest of if / else if statments are picking the sprites based on rotation.
        
        v3.y = m_Camera.transform.localRotation.eulerAngles.y;
        v3yf = v3.y;
        int v3yi = (int)v3yf;

        if(v3yi == 0)
        {
            ImpObj.GetComponent<Target>().R1();
        }
        else if(v3yi == 45)
        {
            ImpObj.GetComponent<Target>().R2();
        }
        else if(v3yi == 90)
        {
            ImpObj.GetComponent<Target>().R3();
        }
        else if(v3yi == 135)
        {
            ImpObj.GetComponent<Target>().R4();
        }
        else if(v3yi == 180)
        {
            ImpObj.GetComponent<Target>().R5();
        }
        else if(v3yi == 225)
        {
            ImpObj.GetComponent<Target>().R6();
        }
        else if(v3yi == 270)
        {
            ImpObj.GetComponent<Target>().R7();
        }
        else if(v3yi == 315)
        {
            ImpObj.GetComponent<Target>().R8();
        }
    }
}
