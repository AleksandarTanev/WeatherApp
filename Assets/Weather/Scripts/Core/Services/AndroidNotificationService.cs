using UnityEngine;

namespace Weather
{
    public class AndroidNotificationService : INotificationService
    {
        public void NotifyUser(string msg)
        {
            ShowAndroidToastMessage(msg);
        }

        private void ShowAndroidToastMessage(string msg)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            if (unityActivity != null)
            {
                AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
                unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity, msg, 0);
                    toastObject.Call("show");
                }));
            }
        }
    }
}