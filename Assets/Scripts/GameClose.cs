using UnityEditor;
using UnityEngine;

public class GameClose : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    Application.Quit();
#endif
        }
    }
}
