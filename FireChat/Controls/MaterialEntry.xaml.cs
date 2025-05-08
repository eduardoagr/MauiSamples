namespace FireChat.Controls;

public partial class MaterialEntry : ContentView {

    public static readonly BindableProperty HintProperty = BindableProperty.Create(
        nameof(Hint), typeof(string), typeof(MaterialEntry));

    public string Hint {
        get => (string)GetValue(HintProperty);
        set => SetValue(HintProperty, value);
    }

    public static readonly BindableProperty IconProperty = BindableProperty.Create(
        nameof(Icon), typeof(string), typeof(MaterialEntry));


    public string Icon {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text), typeof(string), typeof(MaterialEntry),
        string.Empty, BindingMode.TwoWay);


    public string Text {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty IconColorProperty = BindableProperty.Create(
        nameof(IconColor), typeof(Color), typeof(MaterialEntry));

    public Color IconColor {
        get => (Color)GetValue(IconColorProperty);
        set => SetValue(IconColorProperty, value);
    }

    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
        nameof(IsPassword), typeof(bool), typeof(MaterialEntry));


    public bool IsPassword {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }

    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
        nameof(TextColor), typeof(Color), typeof(MaterialEntry));


    public Color TextColor {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }


    public static readonly BindableProperty ShowIconProperty = BindableProperty.Create(
        nameof(ShowIcon), typeof(bool), typeof(MaterialEntry));


    public bool ShowIcon {
        get => (bool)GetValue(ShowIconProperty);
        set => SetValue(ShowIconProperty, value);
    }

    public static readonly BindableProperty HintColorProperty = BindableProperty.Create(
    nameof(HintColor), typeof(Color), typeof(MaterialEntry),
    Colors.White,
    BindingMode.TwoWay);

    public Color HintColor {
        get => (Color)GetValue(HintColorProperty);
        set => SetValue(HintColorProperty, value);
    }


    public MaterialEntry() {
        InitializeComponent();
    }
}