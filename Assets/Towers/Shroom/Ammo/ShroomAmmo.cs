using System;
using System.Collections;
using UnityEngine;

public class ShroomAmmo : TowerAmmo
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
		this.Animator = this.GetComponent<Animator>();
		StartCoroutine(Explode(3f));
	}

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public override void SetDirection(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        if (this.transform.localScale.x < 0)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));
        }
        else
        {
			this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		}
        base.SetDirection(direction);
    }
    private IEnumerator Explode(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.IsExploded = true;
        this.Animator.Play("ShroomAmmo_Ani_Explode");
    }
	public void AfterExplode()
    {
        Destroy(this.gameObject);
    }
}
