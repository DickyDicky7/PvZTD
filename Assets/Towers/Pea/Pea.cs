using UnityEngine;

public class Pea : Tower
{

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	protected override void Start()
    {
		base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
		base.Update();
	}
	protected override void Shoot(Vector3 direction)
	{
		GameObject ammo = Instantiate(AmmoPrefab, transform.position, transform.rotation);
		ammo.GetComponent<PeaAmmo>().SetDirection(direction);
	}
}
