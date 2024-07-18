using UnityEngine;

public class PeaAmmo : MonoBehaviour
{
    private float speed { get; set; } = 10f;
    private Vector3 Direction { get; set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Direction * speed * Time.deltaTime;
    }
    public void SetDirection(Vector3 direction)
    {
        this.Direction = direction;
    }
}
