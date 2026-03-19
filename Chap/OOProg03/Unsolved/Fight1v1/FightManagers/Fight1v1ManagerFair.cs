
/// <summary>
/// This class implements a "fair" fighting management strategy.
/// </summary>
public class Fight1v1ManagerFair : Fight1v1Manager
{
    #region Instance fields
    // You might need this :-)
    private static Random _generator = new Random(Guid.NewGuid().GetHashCode());
    #endregion

    #region Constructor
    public Fight1v1ManagerFair(Player playerA, Player playerB, int noOfFights)
        : base(playerA, playerB, noOfFights)
    {
    }
    #endregion

    #region Methods
    /// <summary>
    /// Each player has a 50 % chance of being the first to strike.
    /// </summary>
    protected override void ExchangeBlows(Player playerA, Player playerB)
    {
        int percent = _generator.Next(100) + 1;
        if (percent<=50)
        {

            playerA.Attack(playerB);
            playerB.Attack(playerA);
        }
        else
        {
            playerB.Attack(playerA);
            playerA.Attack(playerB);
        }
       
    }
   /* private void Attack (Player Attacker, Player defender)
    {
        if (Attacker.Dead) return;
        defender.ReceiveDamage(Attacker.DealDamage());
    } */
    #endregion
}
