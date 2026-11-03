using UnityEngine;

namespace EndOfCycle
{
    [DisallowMultipleComponent]
    public class ApplicationQuitter : MonoBehaviour
    {
        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}

