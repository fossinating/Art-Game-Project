using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] GameObject interactionDescription;
    double visiblity = 0;

    // Update is called once per frame
    void Update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        //layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 4, layerMask) && hit.collider.GetComponent<InteractableObject>() != null && hit.distance < hit.collider.GetComponent<InteractableObject>().GetMaxDistance())
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            visiblity = Math.Min(visiblity + .1, 1.0);
            interactionDescription.GetComponent<TextMeshProUGUI>().text = hit.collider.GetComponent<InteractableObject>().GetInteractionDescription();
            if (Input.GetMouseButtonDown(0))
            {
                hit.collider.GetComponent<InteractableObject>().Interact(this);
            }
        }
        else
        {
            visiblity = Math.Max(visiblity - .1, 0.0);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
        interactionDescription.GetComponent<TextMeshProUGUI>().alpha = (float)visiblity;
    }
}
