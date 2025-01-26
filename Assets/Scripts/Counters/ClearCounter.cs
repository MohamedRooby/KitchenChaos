using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
  
    [SerializeField] private KitchenObjectSO kitchenObjectSO;



    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //there is no kitchen object here 
            if (player.HasKitchenObject())
            {
                //player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // player not carrying anything
            }
        }
        else
        {
            // there is a kitchen object here 
            if (player.HasKitchenObject()) 
            {
                //player is carryig something 
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                { //Player is holding a Plate
                  if(plateKitchenObject.TryAddIngredients(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();

                    }
                }
                else
                {
                    //Player is not carrying a Plate but carrying something else 
                    if(GetKitchenObject().TryGetPlate(out  plateKitchenObject))
                    {
                        //Counter is holding a Plate
                       if(plateKitchenObject.TryAddIngredients(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();

                        }
                    }
                }
            }
            else
            {
                //player is not carrying anthing 
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

}
