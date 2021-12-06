using System;
using FOUOne.PotionCreator;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.EventSystems;

public class CauldronController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ParticleSystem successParticles;
    [SerializeField] private ParticleSystem failParticles;
    [SerializeField] private MMFeedbacks createPotionFeedbacks;
    [SerializeField] private MMFeedbacks mixingReady;

    private bool _isReady;
    private MMFeedbackParticles potionCreationParticles;


    private void Start()
    {
        potionCreationParticles = createPotionFeedbacks.GetComponent<MMFeedbackParticles>();;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isReady) return;

        _isReady = false;
        Debug.Log("Clicking the cauldron");
        mixingReady.StopFeedbacks();

        var potionCreated = GameManager.Instance.CreatePotion();


        if (potionCreated)
        {
            potionCreationParticles.BoundParticleSystem = successParticles;
        }
        else {
            potionCreationParticles.BoundParticleSystem = failParticles;
        }
        
        createPotionFeedbacks.PlayFeedbacks();
    }

    public void SetReady()
    {
        Debug.Log("Cauldron is ready");
        
        _isReady = true;
        mixingReady.PlayFeedbacks();
    }
}
