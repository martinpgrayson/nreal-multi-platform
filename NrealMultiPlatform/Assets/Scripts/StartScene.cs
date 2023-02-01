using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {                
        if (IsGlassesConnected())
        {
            SceneManager.LoadScene(1); // The Nreal HelloMR demo scene.
        }
        else
        {
            SceneManager.LoadScene(2); // Simple ARCore scene.
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static bool IsGlassesConnected()
    {
        if (AndroidJNI.AttachCurrentThread() == 0)
        {
            return new AndroidJavaClass("com.unity3d.player.UnityPlayer")
                .GetStatic<AndroidJavaObject>("currentActivity")
                .Call<AndroidJavaObject>("getSystemService", new object[] { "usb" })
                .Call<AndroidJavaObject>("getDeviceList")
                .Call<AndroidJavaObject>("values")
                .Call<AndroidJavaObject[]>("toArray")
                .Any(x => x.Call<int>("getProductId") == 2313);
        }

        return false;
    }
}
