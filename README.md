# nreal-multi-platform
Sample Unity project showing how a single app can either open an Nreal Air/Light scene or an ARCore scene, depending on whether the glasses are plugged in at launch. 

This sample uses Unity 2021.3.17f1 & NReal SDK 1.10.0.

The glasses are detected by checking the USB devices attached to the device:

```
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
```

The sample also contains the player settings that allow a single APK to be created that supports both ARCore and the Nreal SDK.


