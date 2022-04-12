using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.Versioning;

namespace CodeSys2.PlcTarget
{
    [SupportedOSPlatform("windows")]
    public static class PlcTargetProvider
    {
        public static IEnumerable<Models.PlcTarget> GetRegistedPlcTargets()
        {
            const string automationAlliance = @"SOFTWARE\WOW6432Node\AutomationAlliance\Targets";
            using var targetsSubKey = Registry.LocalMachine.OpenSubKey(automationAlliance, false);
            if (targetsSubKey is null)
                return Enumerable.Empty<Models.PlcTarget>();

            return targetsSubKey.GetSubKeyNames()
                .Select(subname => CreatePlcTarget(automationAlliance + '\\' + subname));
        }

        private static Models.PlcTarget CreatePlcTarget(string subkey)
        {
            using var targetSubKey = Registry.LocalMachine.OpenSubKey(subkey, false);
            if (targetSubKey is null)
                throw new InvalidOperationException();

            var id = GetValue<int>(targetSubKey, "Id");
            var location = GetValue<string>(targetSubKey, "Location");
            var name = GetValue<string>(targetSubKey, "Name");
            var vendor = GetValue<string>(targetSubKey, "Vendor");
            var version = GetValue<string>(targetSubKey, "Version");

            return new Models.PlcTarget(id, location, name, vendor, version);
        }

        private static T GetValue<T>(RegistryKey regKey, string name)
        {
            var value = regKey.GetValue(name);
            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter is not null)
            {
                var convertedValue =  converter.ConvertTo(value, typeof(T));
                if (convertedValue is not null)
                {
                    return (T)convertedValue;
                }
            }

            throw new InvalidOperationException();
        }
    }
}
