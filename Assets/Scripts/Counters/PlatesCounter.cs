using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;


    [SerializeField] KitchenObjectSO plateKitchenObjectSO;
    private float spawnPlateTimer;
    private float spawnPlateTimerMax = 4f;
    private int platesSpawnAmount;
    private int platesSpawnAmountMax = 4;

    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlateTimerMax)
        {
            spawnPlateTimer = 0f;
            if (KitchenGameManager.Instance.IsGamePlaying() && platesSpawnAmount < platesSpawnAmountMax)
            {
                platesSpawnAmount++;
                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }
        public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        { //Player is empty Handed
            if(platesSpawnAmount> 0)
            {// There's at least one plate here 
                platesSpawnAmount--;
                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);

                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}

