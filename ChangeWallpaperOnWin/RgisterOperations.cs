using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ChangeWallpaperOnWin
{
    internal class RgisterOperations
    {
        public bool DeleteValues(string[] path, string[] valuesToDelete)
        {
            RegistryKey key = null;

            path.ToList().ForEach(x =>
            {
                key = CurrentUserFinder(x, key);
            });

            if (key == null) return false;

            var values = key.GetValueNames();

            values.ToList().ForEach(x =>
            {
                if (valuesToDelete.Contains(x))
                {
                    key.DeleteValue(x);
                }
            });

            return true;
        }

        private static RegistryKey CurrentUserFinder(string name, RegistryKey key = null)
        {
            return key == null ? Registry.CurrentUser.OpenSubKey(name, RegistryKeyPermissionCheck.ReadWriteSubTree) : key.OpenSubKey(name, true);
        }
    }
}
