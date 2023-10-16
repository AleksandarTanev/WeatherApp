using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Weather
{
    public class UnityNotificationService : INotificationService
    {
        private UnityToast _unityToast;

        public void NotifyUser(string msg)
        {
            if (_unityToast == null || _unityToast.IsDestroyed())
            {
                var guid = AssetDatabase.FindAssets("UnityToast").FirstOrDefault();
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var prefab = (GameObject)AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject));

                _unityToast = UnityEngine.Object.Instantiate(prefab).GetComponent<UnityToast>();
            }

            _unityToast.Show(msg);
        }
    }
}
