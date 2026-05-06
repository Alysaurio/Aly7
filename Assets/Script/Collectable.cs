using UnityEngine;

public class Collectable : MonoBehaviour, ICollectable
{
    public int value;
    void Start()
    {
        
    }

    public void Collect()
    {
        print("has coleccionado una moneda de valor: " + value);
        Destroy(gameObject);
    }
}
