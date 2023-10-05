using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class InteractionController : MonoBehaviour
{
    [SerializeField] GameObject interactionDescription;
    double interactionDescriptionVisibility = 0;
    [SerializeField] GameObject subtitles;
    [SerializeField] GameObject hand;
    float subtitlesTimeout = 0;

    // Update is called once per frame
    void Update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 0;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 4, layerMask) && hit.collider.GetComponent<InteractableObject>() != null && hit.distance < hit.collider.GetComponent<InteractableObject>().GetMaxDistance())
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            interactionDescriptionVisibility = Math.Min(interactionDescriptionVisibility + .1, 1.0);
            interactionDescription.GetComponent<TextMeshProUGUI>().text = hit.collider.GetComponent<InteractableObject>().GetInteractionDescription(this);
            if (Input.GetMouseButtonDown(0))
            {
                hit.collider.GetComponent<InteractableObject>().Interact(this);
            }
        }
        else
        {
            interactionDescriptionVisibility = Math.Max(interactionDescriptionVisibility - .1, 0.0);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
        interactionDescription.GetComponent<TextMeshProUGUI>().alpha = (float)interactionDescriptionVisibility;

        if (Time.time < subtitlesTimeout)
        {
            
        }
        subtitles.GetComponent<TextMeshProUGUI>().alpha = Mathf.Clamp(4*(subtitlesTimeout - Time.time), 0, 1);
    }

    public void setSubtitle(string subtitle, float time = 30)
    {
        subtitles.GetComponent<TextMeshProUGUI>().text = subtitle;
        subtitlesTimeout = Time.time + time;
    }

    private GameObject heldItem = null;

    public void setHand(InteractableObject interactableObject)
    {
        if (interactableObject == null)
        {
            heldItem = null;
            return;
        }
        if (heldItem == null)
        {
            interactableObject.transform.SetParent(hand.transform);
            interactableObject.transform.localPosition = Vector3.zero;
            interactableObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            interactableObject.transform.localScale = (float)0.3*Vector3.one;
            heldItem = interactableObject.gameObject;
        } else
        {
            setSubtitle("I can only hold one item at a time.");
        }
    }

    public GameObject getHeldItem()
    {
        return heldItem;
    }
}
