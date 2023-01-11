using UnityEngine;
using DG.Tweening;

public class ItemPickup : MonoBehaviour,IPickable,IToggleStatus
{
    PlayerStackMechanic playerStackMechanic;
    Rigidbody rb;
    Transform itemTransform;
    public bool isAlreadyCollected = false;
    public bool IsAlreadyCollected => isAlreadyCollected;
    public bool isCollided = false;

    private void Awake() 
    {
        playerStackMechanic = FindObjectOfType<PlayerStackMechanic>().gameObject.GetComponent<PlayerStackMechanic>();
        rb = gameObject.GetComponent<Rigidbody>();
        itemTransform = transform;
    }

    public void ToggleStatus()
    {
        isAlreadyCollected = !isAlreadyCollected;
    }

    public void HandlePickItem()
    {
        itemTransform.gameObject.SetActive(false);
        ToggleStatus();
    }

    // private void JumpToObject(Transform itemHolderTransform, float jumpYPosition)
    // {
    //     Vector3 endVal = Vector3.zero;
    //     itemTransform.DOScale(endVal,0.5f);
    //     itemTransform.DOJump(itemHolderTransform.position + new Vector3(0, jumpYPosition, -3 ),2f,1,0.7f).OnComplete(()=>{
    //         itemTransform.gameObject.SetActive(false);
    //     });
    // }
}
