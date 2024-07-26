using UnityEngine;

public class Shroom : Tower
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
        Vector3 scale = ammo.transform.localScale;
        scale.x = Mathf.Abs(scale.x);
        if (this.transform.localScale.x < 0)
        {
            scale.x *= -1;
        }
        ammo.transform.localScale = scale;
		ammo.GetComponent<ShroomAmmo>().SetDirection(direction);
	}
}
