using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
namespace WKUdyr
{
    // I can't really help you with my layout of a good config class
    // since everyone does it the way they like it most, go checkout my
    // config classes I make on my GitHub if you wanna take over the
    // complex way that I use
    public static class Config
    {
        private const string MenuName = "WK Udyr";

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("WK Udyr, The best udyr addon.");
            Menu.AddLabel("Addon created by whatskarma / Mac");

            // Initialize the modes
            Modes.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            private static readonly Menu Menu;

            static Modes()
            {
                // Initialize the menu
                Menu = Config.Menu.AddSubMenu("Combo");

                // Initialize all modes
                // Combo
                Combo.Initialize();
                Menu.AddSeparator();

            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _PheonixMode;
                private static readonly CheckBox _TigerMode;


                public static bool PheonixMode
                {
                    get { return _PheonixMode.CurrentValue; }
                }
                public static bool TigerMode
                {
                    get { return _TigerMode.CurrentValue; }
                }


                static Combo()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Combo");
                    Menu.AddLabel("Note: Only tick one of the following.");
                    _TigerMode = Menu.Add("tigerMode", new CheckBox("Tiger Mode"));
                    _PheonixMode = Menu.Add("pheonixMode", new CheckBox("Pheonix Mode", false));
                }

                public static void Initialize()
                {
                }
            }
            }
        }
    }

