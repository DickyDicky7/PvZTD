using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public List<TowerSlot> TowerSlots;
    private TowerSlot ChoosingTowerSlot { get; set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetupTowerSlot();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            CloseTowerSlotControlBoard();
            this.ChoosingTowerSlot = null;
        }
    }
    private void SetupTowerSlot()
    {
        foreach (TowerSlot towerSlot in TowerSlots)
        {
            towerSlot.ChosenEvent.AddListener(SetChoosingTowerSlot);
        }
    }
    private void SetChoosingTowerSlot(TowerSlot towerSlot)
    {
        this.ChoosingTowerSlot = towerSlot;
        CloseTowerSlotControlBoard();
    }
	private void CloseTowerSlotControlBoard()
    {
        if (this.ChoosingTowerSlot == null)
        {
			foreach (TowerSlot towerSlot in TowerSlots)
			{
				towerSlot.ToggleControlBoard(false);
			}
		}
        else
        {
            foreach (TowerSlot towerSlot in TowerSlots)
            {
                if (this.ChoosingTowerSlot != towerSlot)
                {
                    towerSlot.ToggleControlBoard(false);
                }
            }
        }
    }
}
