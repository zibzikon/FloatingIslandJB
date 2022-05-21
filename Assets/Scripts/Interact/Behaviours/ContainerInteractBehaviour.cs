
public class ContainerInteractBehaviour:IInteractionBehaviour,IOpenable
{
    public void OnInteract(IPlayer sender)
    {
        Open(sender);
    }

    public void Open(IPlayer sender)
    {
    }
}
