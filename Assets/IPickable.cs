using UnityEngine;
public interface IPickable
{
    public bool IsAlreadyCollected {get;} 
    public void HandlePickItem();
}
