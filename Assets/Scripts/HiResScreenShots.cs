using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class HiResScreenShots : MonoBehaviour
{
    public int resWidth = 2550;
    public int resHeight = 3300;

    private bool takeHiResShot = false;

    public RawImage texturefoto;

    public Camera camera;

    public GameState gameState;

    public bool prepareCamera;

    Vector3 FirstPoint;
    Vector3 SecondPoint;
    float xAngle;
    float yAngle;
    float xAngleTemp;
    float yAngleTemp;


    void Update()
    {
        if (prepareCamera)
        {
            gameState.takePhoto = true;
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    FirstPoint = Input.GetTouch(0).position;
                    xAngleTemp = xAngle;
                    yAngleTemp = yAngle;
                }
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    SecondPoint = Input.GetTouch(0).position;
                    xAngle = xAngleTemp + (SecondPoint.x - FirstPoint.x) * 180 / Screen.width;
                    yAngle = yAngleTemp + (SecondPoint.y - FirstPoint.y) * 90 / Screen.height;
                    this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
                }
            }
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            gameState.takePhoto = false;
        }
    }



    private void Start()
    {
        texturefoto = texturefoto.GetComponent<RawImage>();
        xAngle = 0;
        yAngle = 0;
        this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0);
        string directoryPath = Application.persistentDataPath+"/screenshots";
        if (!Directory.Exists(directoryPath))
        {
            //if it doesn't, create it
            Directory.CreateDirectory(directoryPath);

        }
    }


    public static string ScreenShotName(int width, int height)
    {
        return string.Format("{0}/screenshots/screen_{1}x{2}_{3}.png",
                             Application.persistentDataPath,
                             width, height,
                             System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    public void PrepareFoto()
    {
        prepareCamera = true;
    }

    public void TakeHiResShot()
    {
        takeHiResShot = true;
        prepareCamera = false;
    }

    void LateUpdate()
    {
        if (takeHiResShot)
        {
            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            camera.targetTexture = rt;
            Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            camera.Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            camera.targetTexture = null;
            RenderTexture.active = null; // JC: added to avoid errors
            Destroy(rt);
            screenShot.Apply();
            texturefoto.texture = screenShot;
            byte[] bytes = screenShot.EncodeToPNG();
            string filename = ScreenShotName(resWidth, resHeight);
            System.IO.File.WriteAllBytes(filename, bytes);
            Debug.Log(string.Format("Took screenshot to: {0}", filename));
            takeHiResShot = false;
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }
}