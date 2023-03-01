using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidAssCameraRotationTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.transform.rotation);
        Debug.Log(this.transform.localRotation);
        Debug.Log(this.transform.eulerAngles);

    }
}
