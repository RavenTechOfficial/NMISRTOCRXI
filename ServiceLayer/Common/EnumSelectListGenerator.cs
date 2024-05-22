using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

public static class EnumSelectListGenerator<TEnum> where TEnum : Enum
{
    public static IEnumerable<SelectListItem> GenerateSelectList()
    {
        return Enum.GetValues(typeof(TEnum))
            .Cast<TEnum>()
            .Select((e, index) => new SelectListItem
            {
                Value = index.ToString(),
                Text = GetEnumDisplayName(e)
            });
    }

    private static string GetEnumDisplayName(TEnum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var displayAttribute = (DisplayAttribute)Attribute.GetCustomAttribute(field, typeof(DisplayAttribute));
        return displayAttribute?.Name ?? value.ToString();
    }
}
