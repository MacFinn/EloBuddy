using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = WKUdyr.Config.Modes.Combo;

namespace WKUdyr.Modes
{
    public sealed class Combo : ModeBase
    {
        internal int count = 0;
        internal bool firstStun = false;

        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on combo mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            var target = TargetSelector.GetTarget(1300, DamageType.Mixed);

            if (target != null)
            {

                if (E.IsLearned)
                {

                    //check our stance
                    string stance = "";
                    var x = Player.Instance.Buffs;

                    for (int i = 0; i < x.Count; i++)
                    {
                        if (x[i].Name.Contains("Stance"))
                        {
                            stance = x[i].Name;
                        }
                    }

                    //check if mauled
                    var y = target.Buffs;
                    bool mauled = false;
                    bool bleeding = false;

                    for (int i = 0; i < y.Count; i++)
                    {

                        if (y[i].Name.Contains("udyrbearstuncheck"))
                        {
                            mauled = true;
                        }

                        if (y[i].Name.Contains("UdyrTigerPunchBleed"))
                        {
                            bleeding = true;
                        }
                    }

                    //if pheonix mode
                    if (Settings.PheonixMode)
                    {
                        if (E.IsReady() && stance != "UdyrBearStance" && !mauled)
                        {
                            E.Cast();
                        }

                        if (Q.IsReady() && stance != "UdyrTigerStance" && mauled)
                        {
                            Q.Cast();
                        }

                        if (R.IsReady() && stance != "UdyrTurtleStance" && bleeding)
                        {
                            R.Cast();
                        }

                        if (!Q.IsReady() && !E.IsReady() && !R.IsReady() && mauled)
                        {
                            W.Cast();
                        }
                    }

                    //if tiger mode | E | Q | W | Q/E
                    if (Settings.TigerMode)
                    {
                        if (E.IsReady() && stance != "UdyrBearStance" && !mauled)
                        {
                            E.Cast();
                        }

                        if (Q.IsReady() && stance != "UdyrTigerStance" && mauled)
                        {
                            Q.Cast();
                        }

                        if (W.IsReady() && stance != "UdyrTurtleStance" && bleeding)
                        {
                            W.Cast();
                        }

                        if (!Q.IsReady() && !E.IsReady() && !R.IsReady() && mauled)
                        {
                            W.Cast();
                        }
                    }
                } else
                {
                    if (Q.IsReady())
                    {
                        Q.Cast();
                    }

                    if (R.IsReady())
                    {
                        R.Cast();
                    }

                    if (W.IsReady())
                    {
                        W.Cast();
                    }
                }

            }
        }

    }
}

