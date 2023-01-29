using UnityEngine;

public class Normal : Form
{
    [SerializeField] private GameObject tongue;

    public override void Attack() {
        if(Input.GetKeyDown("E") && (!IsAttacking))
        Instantiate(tongue);
    }

    public override void TakeDamage() {
        throw new System.NotImplementedException();
    }

    public override void Die() {
        throw new System.NotImplementedException();
    }

    public override void Transform() {
        throw new System.NotImplementedException();
    }

    public override void ThrowPower()
    {
        throw new System.NotImplementedException();
    }

    public Normal(PlayerManager playerManager) : base(playerManager)
    {
    }
}