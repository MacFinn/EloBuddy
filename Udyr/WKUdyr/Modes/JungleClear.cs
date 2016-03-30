using EloBuddy;
using EloBuddy.SDK;

using Settings = WKUdyr.Config.Modes.Combo;

namespace WKUdyr.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on jungleclear mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            if (E.IsLearned)
            {


                foreach (
                    var minion in EntityManager.MinionsAndMonsters.Get(EntityManager.MinionsAndMonsters.EntityType.Monster))
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
                    var y = minion.Buffs;
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

