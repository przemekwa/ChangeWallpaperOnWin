using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeWallpaperOnWin
{
    class Program
    {
        public static readonly string[] WallpaperRegisterKeys =
        {
            "Software", "Microsoft", "Windows", "CurrentVersion",
            "Policies", "System"
        };

        public static readonly string[] WallpaperDeleteKeys = {"Wallpaper", "WallpaperStyle", "NoDispScrSavPage"};

        public static readonly string[] CompositionRegisterKeys =
        {
            "Software", "Microsoft", "Windows", "CurrentVersion",
            "Policies", "Explorer"
        };

        public static readonly string[] CompositionDeleteKeys = {"NoThemeTab,"};

        static void Main(string[] args)
        {
            Console.WriteLine("--== Change Wallpaper On Win 7 ==--");

            var rgisterOperations = new RgisterOperations();

            var wallPaperResult =
                TryChangeRegister(()=>rgisterOperations.DeleteValues(WallpaperRegisterKeys, WallpaperDeleteKeys));

            var compositionResult =
                TryChangeRegister(() => rgisterOperations.DeleteValues(CompositionRegisterKeys, CompositionDeleteKeys));

            Console.WriteLine(wallPaperResult
                ? "Rejestr został wyszczyszony. Można zmienić tapetę."
                : "Nie udało się wyszczyści rejestru. Tapety nie będzie można zmienić.");

            Console.WriteLine(compositionResult
                ? "Rejestr został wyszczyszony. Można zmienić kompozycję."
                : "Nie udało się wyszczyści rejestru. Tapety nie będzie można zmienić.");


            Console.Read();
        }

        static bool TryChangeRegister(Func<bool> changeRegisterFunc)
        {
            try
            {
                return changeRegisterFunc.Invoke();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0}", e.Message);
                return false;
            }
        }
    }
}
