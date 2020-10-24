using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbilFoto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakePicture()
    {
        ScreenCapture.CaptureScreenshot("Test Room");
         }

    // Update is called once per frame
    void Update()
    {
        
    }
}
