using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSwitch extends InteractableObject {

    public abstract void Interact(InteractionController source) 
    {
        
    }

    public abstract string GetInteractionDescription()
{
    return "Turn fan on.";
}
}
