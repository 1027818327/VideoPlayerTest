using UnityEngine;
using Framework.Runtime;
using Framework.Unity.Tools;

namespace Framework.Unity
{
    // 主程序启动类
    public class AppMain : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod]
        static void Initialize()
        {
            GameObject tempSingleObj = new GameObject(typeof(AppMain).Name);
            //tempSingleObj.hideFlags = HideFlags.HideInHierarchy;
            AppMain tempScript = tempSingleObj.AddComponent<AppMain>();
            GameObject.DontDestroyOnLoad(tempSingleObj);

#if DEVELOPMENT_BUILD || UNITY_EDITOR
            tempScript.OpenLog();
#else
            tempScript.OpenLog();
#endif
            {
                var tempInstance = MonoHelper.Instance;
            }
        }

        private void OpenLog()
        {
            Debuger.EnableLog = true;
            Debug.unityLogger.logEnabled = true;
            gameObject.AddComponent<DebuggerComponent>();
        }

        private void CloseLog()
        {
            Debuger.EnableLog = false;
            Debug.unityLogger.logEnabled = false;
        }
    }
}