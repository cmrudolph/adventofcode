namespace AOC.CSharp;

public static class AOC2015_22
{
    private const int MagicMissileCost = 53;
    private const int MagicMissileDamage = 4;

    private const int DrainCost = 73;
    private const int DrainDamage = 2;

    private const int ShieldCost = 113;
    private const int ShieldArmor = 7;
    private const int ShieldTurns = 6;

    private const int PoisonCost = 173;
    private const int PoisonDamage = 3;
    private const int PoisonTurns = 6;

    private const int RechargeCost = 229;
    private const int RechargeMana = 101;
    private const int RechargeTurns = 5;

    public static long Solve1(string[] lines, string extra)
    {
        int bossHp = int.Parse(lines[0].Split(':')[1]);
        int bossDamage = int.Parse(lines[1].Split(':')[1]);
        string[] splits = extra.Split(',');
        int playerHp = int.Parse(splits[0]);
        int playerMana = int.Parse(splits[1]);

        State state = new State
        {
            BossHp = bossHp,
            BossDamage = bossDamage,
            PlayerHp = playerHp,
            PlayerMana = playerMana,
        };

        int bestWinCost = int.MaxValue;
        RecursePlayerTurn(state, ref bestWinCost, 0);

        return bestWinCost;
    }

    public static long Solve2(string[] lines, string extra)
    {
        int bossHp = int.Parse(lines[0].Split(':')[1]);
        int bossDamage = int.Parse(lines[1].Split(':')[1]);
        string[] splits = extra.Split(',');
        int playerHp = int.Parse(splits[0]);
        int playerMana = int.Parse(splits[1]);

        State state = new State
        {
            BossHp = bossHp,
            BossDamage = bossDamage,
            PlayerHp = playerHp,
            PlayerMana = playerMana,
            PlayerTurnSelfDamage = 1,
        };

        int bestWinCost = int.MaxValue;
        RecursePlayerTurn(state, ref bestWinCost, 0);

        return bestWinCost;
    }

    private static void RecursePlayerTurn(State initialState, ref int bestWinCost, int depth)
    {
        State afterSelfDamageState = initialState with
        {
            PlayerHp = initialState.PlayerHp - initialState.PlayerTurnSelfDamage
        };

        if (afterSelfDamageState.PlayerHp <= 0)
        {
            // LOSE: Ran out of health due to the self damage effect
            return;
        }

        if (afterSelfDamageState.ManaSpent >= bestWinCost)
        {
            // SUBOPTIMAL: Already spent more mana than the current best solution
            return;
        }

        State afterTimerState = HandleTimerActions(afterSelfDamageState);

        if (afterTimerState.BossHp <= 0)
        {
            // WIN: New optimal solution. Boss was taken out by the poison timer
            bestWinCost = afterTimerState.ManaSpent;
            return;
        }

        // Recursively branch and explore each available spell path
        if (afterTimerState.PlayerMana >= MagicMissileCost)
        {
            State spellState = afterTimerState with
            {
                BossHp = afterTimerState.BossHp - MagicMissileDamage,
                ManaSpent = afterTimerState.ManaSpent + MagicMissileCost,
                PlayerMana = afterTimerState.PlayerMana - MagicMissileCost,
            };

            RecurseBossTurn(spellState, ref bestWinCost, depth + 1);
        }

        if (afterTimerState.PlayerMana >= DrainCost)
        {
            State spellState = afterTimerState with
            {
                BossHp = afterTimerState.BossHp - DrainDamage,
                PlayerHp = afterTimerState.PlayerHp + DrainDamage,
                ManaSpent = afterTimerState.ManaSpent + DrainCost,
                PlayerMana = afterTimerState.PlayerMana - DrainCost,
            };

            RecurseBossTurn(spellState, ref bestWinCost, depth + 1);
        }

        if (afterTimerState.PlayerMana >= ShieldCost && afterTimerState.ShieldTurns == 0)
        {
            State spellState = afterTimerState with
            {
                ManaSpent = afterTimerState.ManaSpent + ShieldCost,
                PlayerMana = afterTimerState.PlayerMana - ShieldCost,
                ShieldTurns = ShieldTurns,
            };

            RecurseBossTurn(spellState, ref bestWinCost, depth + 1);
        }

        if (afterTimerState.PlayerMana >= PoisonCost && afterTimerState.PoisonTurns == 0)
        {
            State spellState = afterTimerState with
            {
                ManaSpent = afterTimerState.ManaSpent + PoisonCost,
                PlayerMana = afterTimerState.PlayerMana - PoisonCost,
                PoisonTurns = PoisonTurns,
            };

            RecurseBossTurn(spellState, ref bestWinCost, depth + 1);
        }

        if (afterTimerState.PlayerMana >= RechargeCost && afterTimerState.RechargeTurns == 0)
        {
            State spellState = afterTimerState with
            {
                ManaSpent = afterTimerState.ManaSpent + RechargeCost,
                PlayerMana = afterTimerState.PlayerMana - RechargeCost,
                RechargeTurns = RechargeTurns,
            };

            RecurseBossTurn(spellState, ref bestWinCost, depth + 1);
        }
    }

    private static void RecurseBossTurn(State initialState, ref int bestWinCost, int depth)
    {
        if (initialState.ManaSpent >= bestWinCost)
        {
            // SUBOPTIMAL: Already spent more mana than the current best solution
            return;
        }

        if (initialState.BossHp <= 0)
        {
            // WIN: New optimal solution. Boss was taken out by the last player spell
            bestWinCost = initialState.ManaSpent;
            return;
        }

        State afterTimerState = HandleTimerActions(initialState);

        if (afterTimerState.BossHp <= 0)
        {
            if (afterTimerState.ManaSpent < bestWinCost)
            {
                // WIN: New optimal solution. Boss was taken out by the poison timer
                bestWinCost = afterTimerState.ManaSpent;
            }

            return;
        }

        int damageToPlayer = afterTimerState.BossDamage - afterTimerState.PlayerArmor;

        State afterBossAttackState = afterTimerState with
        {
            PlayerHp = afterTimerState.PlayerHp - damageToPlayer,
        };

        if (afterBossAttackState.PlayerHp > 0)
        {
            // Continue playing as long as we are still alive
            RecursePlayerTurn(afterBossAttackState, ref bestWinCost, depth + 1);
        }
    }

    private static State HandleTimerActions(State state)
    {
        State newState = state;

        int poisonDamage = state.PoisonTurns >= 1 ? PoisonDamage : 0;
        int rechargeMana = state.RechargeTurns >= 1 ? RechargeMana : 0;

        newState = newState with
        {
            PlayerArmor = state.ShieldTurns >= 1 ? ShieldArmor : 0,
            ShieldTurns = Math.Max(state.ShieldTurns - 1, 0),
            PoisonTurns = Math.Max(state.PoisonTurns - 1, 0),
            RechargeTurns = Math.Max(state.RechargeTurns - 1, 0),
            PlayerMana = state.PlayerMana + rechargeMana,
            BossHp = state.BossHp - poisonDamage
        };

        return newState;
    }
}

record State
{
    public int BossHp { get; init; }
    public int BossDamage { get; init; }
    public int PlayerHp { get; init; }
    public int PlayerMana { get; init; }
    public int PlayerArmor { get; init; }
    public int ManaSpent { get; init; }
    public int PoisonTurns { get; init; }
    public int ShieldTurns { get; init; }
    public int RechargeTurns { get; init; }
    public int PlayerTurnSelfDamage { get; init; }
}
