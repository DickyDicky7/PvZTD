using UnityEngine;

public class Pea : MonoBehaviour
{
	public GameObject PeaAmmoPrefab;

	protected float TimeElapsed = 0f;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
		Vector3 objectPosition = transform.position;
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 scale = this.transform.localScale;
		scale.x = Mathf.Abs(scale.x);
		if (mousePosition.x < objectPosition.x)
		{
			scale.x *= -1;
		}
		this.transform.localScale = scale;

		TimeElapsed += Time.deltaTime;
		if (TimeElapsed >= 0.5f)
		{
			Shoot((mousePosition - objectPosition).normalized);
			TimeElapsed = 0f;
		}
	}
	protected void Shoot(Vector3 direction)
	{
		GameObject ammo = Instantiate(PeaAmmoPrefab, transform.position, transform.rotation);
		ammo.GetComponent<PeaAmmo>().SetDirection(direction);
	}
}
