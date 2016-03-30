using EloBuddy;
using EloBuddy.SDK;

namespace WKUdyr
{
    public static class SpellManager
    {
        // You will need to edit the types of spells you have for each champ as they
        // don't have the same type for each champ, for example Xerath Q is chargeable,
        // right now it's  set to Active.
        public static Spell.Active Q { get; private set; }
        public static Spell.Active W { get; private set; }
        public static Spell.Active E { get; private set; }
        public static Spell.Active R { get; private set; }

        public static string Form { get; set; }

        static SpellManager()
        {
            // Initialize spells
            Q = new Spell.Active(SpellSlot.Q, 125);
            W = new Spell.Active(SpellSlot.W, 125);
            E = new Spell.Active(SpellSlot.E, 125);
            R = new Spell.Active(SpellSlot.R, 125);
        }

        

        public static void Initialize()
        {
            // Let the static initializer do the job, this way we avoid multiple init calls aswell
        }
    }
}
