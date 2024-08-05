namespace ComiteTecnicoMaui.App.Customs;

/// <summary>
/// Class Custom Picker. CustomPickerHandler
/// </summary>
///// <seealso cref="Xamarin.Forms.Picker" />
public class CustomPicker : Picker
{
    /// <summary>
    /// The image property.
    /// </summary>
    public static readonly BindableProperty ImageProperty =
        BindableProperty.Create(nameof(Image), typeof(string), typeof(CustomPicker), string.Empty);

    /// <summary>
    /// Gets or sets the image.
    /// </summary>
    /// <value>
    /// The image.
    /// </value>
    public string Image
    {
        get { return (string)GetValue(ImageProperty); }
        set { SetValue(ImageProperty, value); }
    }

    /// <summary>Bindable property for <see cref="CornerRadius"/>.</summary>
    public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(CustomPicker), -1.0f,
        validateValue: (bindable, value) => ((float)value) == -1.0f || ((float)value) >= 0f);
    public float CornerRadius
    {
        get { return (float)GetValue(CornerRadiusProperty); }
        set { SetValue(CornerRadiusProperty, value); }
    }

    /// <summary>Bindable property for <see cref="ButtonNegativeColor"/>.</summary>
    public static readonly BindableProperty ButtonNegativeColorProperty =
        BindableProperty.Create(nameof(ButtonNegativeColor), typeof(Color), typeof(CustomPicker), default(Color));
    public Color ButtonNegativeColor
    {
        get { return (Color)GetValue(ButtonNegativeColorProperty); }
        set { SetValue(ButtonNegativeColorProperty, value); }
    }

    /// <summary>Bindable property for <see cref="ButtonPositiveColor"/>.</summary>
    public static readonly BindableProperty ButtonPositiveColorProperty =
        BindableProperty.Create(nameof(ButtonPositiveColor), typeof(Color), typeof(CustomPicker), default(Color));
    public Color ButtonPositiveColor
    {
        get { return (Color)GetValue(ButtonPositiveColorProperty); }
        set { SetValue(ButtonPositiveColorProperty, value); }
    }

}
