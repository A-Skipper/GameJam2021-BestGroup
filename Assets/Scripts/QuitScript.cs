using UnityEngine;
using UnityEditor;

public class QuitScript : MonoBehaviour
{
    public void Quit()
    {
        if (EditorApplication.isPlaying == true)
        {
            EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
        
    }
}
