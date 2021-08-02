using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.EventSystems;

public class CauldronController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ParticleSystem successParticles;
    [SerializeField] private ParticleSystem failParticles;
    [SerializeField] private MMFeedbacks createPotionFeedbacks;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicking the cauldron");
        var particleFeedback = createPotionFeedbacks.GetComponent<MMFeedbackParticles>();
        if (particleFeedback != null)
        {
            particleFeedback.BoundParticleSystem = failParticles;
        }
        
        createPotionFeedbacks.PlayFeedbacks();
    }
}
