using UnityEngine;

namespace Interact
{
    public abstract class InteractableBuilding : Building, IInteractable
    {
        protected abstract IInteractionBehaviour InteractionBehaviour { get; }
       
        public void Interact(IPlayer sender)
        {
            InteractionBehaviour.OnInteract(sender);
        }
    }
}