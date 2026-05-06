using UnityEngine;

public interface IDamageable
{
    public abstract void TakeDamage();

}
public interface IInteractable
{
    public virtual void Interact()
    {
        Debug.Log("Interact!");
    }
}
public interface ICollectable
{
    public void Collect();
}