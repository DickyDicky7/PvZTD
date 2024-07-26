using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerSlot : MonoBehaviour
{
	//---Export---
	public List<GameObject> PeaPrefabs;
	public List<GameObject> ShroomPrefabs;
	public GameObject BuildBoard;
	public GameObject UpgradeBoard;
	//public GameObject SkillBoard;
	//------------
	public UnityEvent<TowerSlot> ChosenEvent;
	public enum TowerType
	{
		None = 0,
		Pea = 1,
		Shroom = 2,
	}
	private TowerType CurrentTowerType { get; set; } = TowerType.None;
    private GameObject CurrentTower { get; set; }
    private Vector3 TowerPosition { get; set; }
    private int CurrentTowerLevel { get; set; } = -1;
	private Dictionary<TowerType, List<GameObject>> TowerDictionary { get; set; } = new();
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        TowerPosition = new Vector3(transform.position.x, transform.position.y + 0.15f, 0);
		TowerDictionary.Add(TowerType.Pea, PeaPrefabs);
		TowerDictionary.Add(TowerType.Shroom, ShroomPrefabs);
		ToggleControlBoard(false);
	}

	// Update is called once per frame
	//void Update()
	//{

	//}
	void OnMouseDown()
	{
		ToggleControlBoard(true);
		ChosenEvent.Invoke(this);
	}
	public void Build(int towerType)
	{
		this.CurrentTowerLevel = 0;
		this.CurrentTower = Instantiate(
			TowerDictionary[(TowerType)towerType][CurrentTowerLevel],
			TowerPosition,
			transform.rotation);
		this.CurrentTowerType = (TowerType)towerType;
		ToggleControlBoard(false);
	}
	public void Upgrade()
	{
		Destroy(CurrentTower);
		this.CurrentTowerLevel++;
		this.CurrentTower = Instantiate(
			TowerDictionary[CurrentTowerType][CurrentTowerLevel],
			TowerPosition,
			transform.rotation);
		ToggleControlBoard(false);
	}
	public void Sell()
	{
		Destroy(CurrentTower);
		this.CurrentTowerLevel = -1;
		this.CurrentTowerType = TowerType.None;
		ToggleControlBoard(false);
	}
	public void ToggleControlBoard(bool state)
	{
		if (state is false)
		{
			this.BuildBoard.SetActive(false);
			this.UpgradeBoard.SetActive(false);
		}
		else
		{
			if (CurrentTowerType == TowerType.None)
			{
				this.BuildBoard.SetActive(true);
			}
			else
			{
				if (CurrentTowerLevel < 2)
				{
					this.UpgradeBoard
						.transform
						.GetChild(0)
						.gameObject
						.SetActive(true);
				}
				else
				{
					this.UpgradeBoard
						.transform
						.GetChild(0)
						.gameObject
						.SetActive(false);
				}
				this.UpgradeBoard.SetActive(true);
			}
		}
	}
}
