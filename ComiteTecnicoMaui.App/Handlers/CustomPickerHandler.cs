using ComiteTecnicoMaui.App.Customs;
using Microsoft.Maui.Platform;

# if __ANDROID__

namespace Microsoft.Maui.Handlers;

public partial class CustomPickerHandler : ViewHandler<IPicker, MauiPicker>, IPickerHandler
{
    public static IPropertyMapper<CustomPicker, CustomPickerHandler> Mapper = new PropertyMapper<CustomPicker, CustomPickerHandler>(ViewMapper)
    {
        [nameof(IPicker.Background)] = MapBackground,
        [nameof(IPicker.CharacterSpacing)] = MapCharacterSpacing,
        [nameof(IPicker.Font)] = MapFont,
        [nameof(IPicker.SelectedIndex)] = MapSelectedIndex,
        [nameof(IPicker.TextColor)] = MapTextColor,
        [nameof(IPicker.Title)] = MapTitle,
        [nameof(IPicker.TitleColor)] = MapTitleColor,
        [nameof(ITextAlignment.HorizontalTextAlignment)] = MapHorizontalTextAlignment,
        [nameof(ITextAlignment.VerticalTextAlignment)] = MapVerticalTextAlignment,
        [nameof(IPicker.Items)] = MapItems,
        [nameof(CustomPicker.CornerRadius)] = MapCornerRadius,
        [nameof(CustomPicker.Image)] = MapImage,
        [nameof(CustomPicker.ButtonNegativeColor)] = MapButtonNegativeColor,
        [nameof(CustomPicker.ButtonPositiveColor)] = MapButtonPositiveColor,
    };

    public static CommandMapper<IPicker, IPickerHandler> CommandMapper = new(ViewCommandMapper)
    {
    };

    public CustomPickerHandler() : base(Mapper, CommandMapper)
    {
    }
}

#else
public partial class CustomPickerHandler
{
}

#endif
