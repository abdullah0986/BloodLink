using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Reflection;

namespace BloodLink.Helpers
{   
    public static class EnumHelper
    {
        // Gets the description text from enum value
        // BloodGroup.APositive → "A+"
        public static string GetDescription(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = field
                .GetCustomAttribute<DescriptionAttribute>();
            return attribute != null ? attribute.Description : value.ToString();
        }

        // Gets all descriptions for an enum type
        // Use this to populate a ComboBox
        public static List<string> GetAllDescriptions<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                       .Cast<T>()
                       .Select(e => GetDescription(e))
                       .ToList();
        }

        // Converts description back to enum value
        // "A+" → BloodGroup.APositive
        public static T GetValueFromDescription<T>(string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                var attribute = field.GetCustomAttribute<DescriptionAttribute>();
                if (attribute?.Description == description)
                    return (T)field.GetValue(null);
            }
            return default;
        }
    }
}
