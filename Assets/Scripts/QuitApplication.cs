using UnityEngine;
using UnityEngine.InputSystem;

public class QuitApplication : MonoBehaviour
{
    private void Update()
    {
        ProcessQuit();
    }
    void ProcessQuit(){
    
        if(Keyboard.current.escapeKey.isPressed)
        {
            Debug.Log("Se presiono escape");
            Application.Quit();
        }
    }
}
