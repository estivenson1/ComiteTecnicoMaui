using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using ComiteTecnicoMaui.App.Customs;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Platform;
using AppCompatAlertDialog = AndroidX.AppCompat.App.AlertDialog;
using AResource = Android.Resource;
using Paint = Android.Graphics.Paint;
using ShapeDrawable = Android.Graphics.Drawables.ShapeDrawable;

namespace Microsoft.Maui.Handlers;

public partial class CustomPickerHandler
{
    AppCompatAlertDialog? _dialog;

    protected override MauiPicker CreatePlatformView() =>
        new MauiPicker(Context);

    protected override void ConnectHandler(MauiPicker platformView)
    {
        platformView.FocusChange += OnFocusChange;
        platformView.Click += OnClick;

        base.ConnectHandler(platformView);
    }

    protected override void DisconnectHandler(MauiPicker platformView)
    {
        try
        {
            platformView.FocusChange -= OnFocusChange;
            platformView.Click -= OnClick;

            base.DisconnectHandler(platformView);
        }
        catch (Exception)
        {
        }

    }

    // This is a Android-specific mapping
    public static void MapBackground(IPickerHandler handler, IPicker picker)
    {
        //Se comenta por que sobre escribe el comportamiento del Picker de Android Xamarin 
        //handler.PlatformView?.UpdateBackground(picker);
        handler.PlatformView.Background = AddPickerStyles(handler);
    }

    // TODO Uncomment me on NET8 [Obsolete]
    public static void MapReload(IPickerHandler handler, IPicker picker, object? args) => Reload(handler);

    internal static void MapItems(IPickerHandler handler, IPicker picker) => Reload(handler);

    public static void MapTitle(IPickerHandler handler, IPicker picker)
    {
        handler.PlatformView?.UpdateTitle(picker);
    }

    public static void MapTitleColor(IPickerHandler handler, IPicker picker)
    {
        if (picker.TitleColor != null && picker.Items != null && picker.Items.Any())
        {
            handler.PlatformView?.SetHintTextColor(picker.TitleColor.ToAndroid());
        }
    }

    public static void MapSelectedIndex(IPickerHandler handler, IPicker picker)
    {
        handler.PlatformView?.UpdateSelectedIndex(picker);
    }

    public static void MapCharacterSpacing(IPickerHandler handler, IPicker picker)
    {
        handler.PlatformView?.UpdateCharacterSpacing(picker);
    }

    public static void MapFont(IPickerHandler handler, IPicker picker)
    {
        var fontManager = handler.MauiContext.Services.GetRequiredService<IFontManager>();
        handler.PlatformView?.UpdateFont(picker, fontManager);
    }

    public static void MapHorizontalTextAlignment(IPickerHandler handler, IPicker picker)
    {
        handler.PlatformView.UpdateHorizontalTextAlignment(picker);
    }

    public static void MapTextColor(IPickerHandler handler, IPicker picker)
    {
        //handler.PlatformView.UpdateTextColor(picker);
        if (picker.TextColor != null)
        {
            handler.PlatformView.SetTextColor(picker.TextColor.ToAndroid());
        }
    }

    public static void MapVerticalTextAlignment(IPickerHandler handler, IPicker picker)
    {
        handler.PlatformView?.UpdateVerticalAlignment(picker.VerticalTextAlignment);
    }

    void OnFocusChange(object? sender, global::Android.Views.View.FocusChangeEventArgs e)
    {
        if (PlatformView == null)
            return;

        if (e.HasFocus)
        {
            if (PlatformView.Clickable)
                PlatformView.CallOnClick();
            else
                OnClick(PlatformView, EventArgs.Empty);
        }
        else if (_dialog != null)
        {
            _dialog.Hide();
            _dialog = null;
        }
    }

    public static void MapCornerRadius(IPickerHandler handler, IPicker picker)
    {
        handler.PlatformView.Background = AddPickerStyles(handler);
    }

    public static void MapImage(IPickerHandler handler, IPicker picker)
    {
        handler.PlatformView.Background = AddPickerStyles(handler);
    }

    public static void MapButtonNegativeColor(IPickerHandler handler, IPicker picker)
    {
    }

    public static void MapButtonPositiveColor(IPickerHandler handler, IPicker picker)
    {

    }

    void OnClick(object? sender, EventArgs e)
    {
        if (_dialog != null) return;
        CustomPicker model = VirtualView as CustomPicker;
        var picker = new NumberPicker(Context);
        if (model.Items != null && model.Items.Any())
        {
            picker.MaxValue = model.Items.Count - 1;
            picker.MinValue = 0;
            picker.SetDisplayedValues(model.Items.ToArray());
            picker.WrapSelectorWheel = false;
            picker.DescendantFocusability = DescendantFocusability.BlockDescendants;
            picker.Value = model.SelectedIndex;
        }

        var layout = new LinearLayout(Context) { Orientation = Orientation.Vertical };
        layout.AddView(picker);

        var builder = new AppCompatAlertDialog.Builder(Context);
        builder.SetView(layout);

        var title = new SpannableString(model.Title ?? "");
        title.SetSpan(new StyleSpan(TypefaceStyle.Bold), 0, title.Length(), SpanTypes.ExclusiveExclusive);
        if (model.TitleColor != null)
        {
            title.SetSpan(new ForegroundColorSpan(model.TitleColor.ToAndroid()), 0, title.Length(), SpanTypes.ExclusiveExclusive);
        }
        builder.SetTitle(title);

        builder.SetNegativeButton(AResource.String.Cancel, (o, args) => { });

        builder.SetPositiveButton(AResource.String.Ok, (s, a) =>
        {
            if (picker != null)
            {
                if (model.Items.Count > 0 && picker.Value >= 0)
                    model.SelectedIndex = picker.Value;
                Reload(this);
            }
        });

        _dialog = builder.Create();
        _dialog.DismissEvent += (sender, args) =>
        {
            _dialog?.Dispose();
            _dialog = null;
        };
        _dialog.Show();

        var positiveButton = _dialog.GetButton((int)DialogButtonType.Positive);
        positiveButton.SetTextColor(model.ButtonPositiveColor.ToAndroid(Colors.Black));

        var negativeButton = _dialog.GetButton((int)DialogButtonType.Negative);
        negativeButton.SetTextColor(model.ButtonNegativeColor.ToAndroid(Colors.Black));
    }

    static void Reload(IPickerHandler handler)
    {
        handler.PlatformView.UpdateSelectedIndex(handler.VirtualView);
    }


    /// <summary>
    /// The left.
    /// </summary>
    private const int Left = 10;

    /// <summary>
    /// The top.
    /// </summary>
    private const int Top = 5;

    /// <summary>
    /// The right.
    /// </summary>
    private const int Right = 5;

    /// <summary>
    /// The bottom.
    /// </summary>
    private const int Bottom = 5;

    /// <summary>
    /// Adds the picker styles.
    /// </summary>
    /// <param name="imagePath">The image path.</param>
    /// <returns></returns>
    static public LayerDrawable AddPickerStyles(IPickerHandler handler)
    {
        CustomPicker customPicker = handler.VirtualView as CustomPicker;
        var cr = customPicker.CornerRadius;

        var outerRadii = new float[] { cr, cr, cr, cr, cr, cr, cr, cr };
        var innerRadii = new float[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        var rect = new Android.Graphics.RectF(0, 0, 0, 0);

        ShapeDrawable border = new ShapeDrawable();
        border.Paint.Color = customPicker.BackgroundColor.ToAndroid(Colors.LightGray);
        border.SetPadding(Left, Top, Right, Bottom);
        border.Paint.SetStyle(Paint.Style.Fill);
        border.Shape = new RoundRectShape(outerRadii, rect, innerRadii);

        Drawable[] layers = { border, GetDrawable(handler) };
        LayerDrawable layerDrawable = new LayerDrawable(layers);

        return layerDrawable;
    }

    /// <summary>
    /// Gets the drawable.
    /// </summary>
    /// <param name="imagePath">The image path.</param>
    /// <returns></returns>
    static private BitmapDrawable GetDrawable(IPickerHandler handler)
    {
        CustomPicker customPicker = handler.VirtualView as CustomPicker;
        if (string.IsNullOrEmpty(customPicker?.Image)) { return null; }
        int resID = handler.PlatformView.Context.Resources.GetIdentifier(customPicker.Image, "drawable", handler.PlatformView.Context.PackageName);
        if (resID == 0) { return null; }
        var drawable = ContextCompat.GetDrawable(handler?.PlatformView?.Context, resID);

        Bitmap bitmap = ((BitmapDrawable)drawable).Bitmap;

        BitmapDrawable result = Device.Idiom == TargetIdiom.Tablet
            ? new BitmapDrawable(handler.PlatformView.Context.Resources, Bitmap.CreateScaledBitmap(bitmap, 35, 35, true))
            : new BitmapDrawable(handler.PlatformView.Context.Resources, Bitmap.CreateScaledBitmap(bitmap, 20, 24, true));

        result.Gravity = global::Android.Views.GravityFlags.Right;
        //result.Gravity = global::Android.Views.GravityFlags.AxisPullAfter;
        return result;
    }

}