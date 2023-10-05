using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanBagChair : InteractableObject
{
    Transform oldParent = null;
    [SerializeField] GameObject seat;
    public override string GetInteractionDescription(InteractionController source)
    {
        return "Sit in bean bag chair";
    }

    public override void Interact(InteractionController source)
    {
        source.sitOnObject(seat);
    }
}
