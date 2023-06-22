using UnityEngine;

public class TreeInteraction : Interactable
{
    public override void OnPlayerInteraction()
    {
        Debug.Log("Tree was interacted with");
    }
}
