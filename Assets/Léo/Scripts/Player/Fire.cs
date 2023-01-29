public class Fire : Form
{
    public override void Attack()
    {
    }

    public override void TakeDamage()
    {
        throw new System.NotImplementedException();
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void Transform()
    {
        throw new System.NotImplementedException();
    }

    public override void ThrowPower()
    {
        throw new System.NotImplementedException();
    }

    public Fire(PlayerManager playerManager) : base(playerManager)
    {
    }
}