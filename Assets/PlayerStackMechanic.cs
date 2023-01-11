using UnityEngine;
using DG.Tweening;
using System.Collections;
public class PlayerStackMechanic : MonoBehaviour
{
    [SerializeField] Transform itemHolderTransform;
    [SerializeField] float jumpPosY;
    [SerializeField] GameObject[] bones;
    [SerializeField] float unstackTime = 0.1f;
    [SerializeField] float stackTime = 0.1f;
    public bool isItemCollided = false;
    private bool isLoadingAnimation = false;
    private int numberOfItemHolding = 0;
    private int checkKey;
    private int rebuildCheckey;
    Transform objectHolding;
    
    void Awake()
    {
        objectHolding = bones[numberOfItemHolding].transform;
        checkKey = numberOfItemHolding;
    }

    void Update()
    {
        objectHolding = bones[numberOfItemHolding].transform;
    }

    public int NumberOfItemHolding => numberOfItemHolding;
    
    public bool IsLoadingAnimation => isLoadingAnimation;
    
    private void OnTriggerEnter(Collider other)
    {
        if(isLoadingAnimation == false)
        {
            if (other.CompareTag("Item"))
            {
                ItemPickup item;
                item = other.GetComponent<ItemPickup>();
                if(item.IsAlreadyCollected == false)
                {
                    item.HandlePickItem();
                    StartCoroutine(ReScaleBehavior());
                }   
            }
        }     
    }

    IEnumerator ReScaleBehavior()
    {
        Vector3 scaleBigSize = new Vector3(2f, 1.5f, 2f);
        Vector3 scaleSmallSize = new Vector3(1.5f, 1f, 1.5f);
        for(int i = 0; i <=numberOfItemHolding; i++)
        {
            bones[i].transform.GetChild(0).transform.DOScale(scaleBigSize,0.1f).OnComplete(()=>{
                bones[i].transform.GetChild(0).transform.DOScale(scaleSmallSize,0.1f);
            });
            yield return new WaitForSeconds(0.1f);
        }
        IncreaseNumberOfItemHolding();
        yield return new WaitForSeconds(0.1f);
        objectHolding.GetChild(0).gameObject.SetActive(true);
    }

     public void ToogleIsCollideItem()
     {
        if(isItemCollided == true)
        {
            isItemCollided = false;
        }
        else if(isItemCollided == false) 
        {
            isItemCollided = true;
        }
     }

     public void IncreaseNumberOfItemHolding()
     {
        numberOfItemHolding++;
     }

     public void DecreaseNumberOfItemHolding()
     {
        numberOfItemHolding--;
     }
}
