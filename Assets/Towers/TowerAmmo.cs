using UnityEngine;

public class TowerAmmo : MonoBehaviour
{
	protected float Speed { get; set; } = 1.0f;
	protected Vector3 Direction { get; set; }
	protected Animator Animator { get; set; }
	protected bool IsExploded { get; set; } = false;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	protected virtual void Start()
    {
        
    }
    // Update is called once per frame
    protected virtual void Update()
    {
		if (this.IsExploded is false)
		{
			transform.position += Direction * Speed * Time.deltaTime;
		}
		
	}
	public virtual void SetDirection(Vector3 direction)
	{
		Vector3 temp = new Vector3(direction.x, direction.y, 0);
		this.Direction = temp.normalized;
	}
}
