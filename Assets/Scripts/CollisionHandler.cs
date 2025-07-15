using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Esta todo tranquilo");
                break;
            case "Finish":
                Debug.Log("Llegaste a la meta");
                break;
            case "Fuel":
                Debug.Log("Es combustible");
                break;
            default:
                Debug.Log("Estas chocando amigo");
                break;
        }
    }
}
