using System.Collections;
using UnityEngine;

public class PeaAmmo : TowerAmmo
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
    private IEnumerator Explode(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.IsExploded = true;
        this.Animator.Play("PeaAmmo_Ani_Explode");
    }
    public void AfterExplode()
    {
        Destroy(this.gameObject);
    }
}
