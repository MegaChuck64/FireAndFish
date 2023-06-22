using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Interactable interactable;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Interactable>() is Interactable inter)
        {
            interactable = inter;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == interactable.gameObject)
        {
            interactable = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interactable != null)
            {
                interactable.OnPlayerInteraction();
            }
        }
    }
}
