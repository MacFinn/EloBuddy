using EloBuddy.SDK;

namespace WKUdyr.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on flee mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
            if (E.IsReady())
            {
                E.Cast();
            }

            if (W.IsReady() && !E.IsReady())
            {
                W.Cast();
            }

            if (Q.IsReady() && !E.IsReady())
            {
                Q.Cast();
            }

            if (R.IsReady() && !E.IsReady())
            {
                R.Cast();
            }
        }
    }
}
