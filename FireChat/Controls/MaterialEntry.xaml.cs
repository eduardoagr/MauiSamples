namespace FireChat.Controls;

public partial class MaterialEntry : ContentView {

    public static readonly BindableProperty HintProperty = BindableProperty.Create(
        nameof(Hint), typeof(string), typeof(MaterialEntry), string.Empty,
        BindingMode.TwoWay, null, OnHintPropertyChanged);

    private static void OnHintPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
        if(bindable is MaterialEntry materialEntry && materialEntry.Content is SfTextInputLayout inputLayout) {
            inputLayout.Hint = (string)newValue;
        }
    }

    public string Hint {
        get => (string)GetValue(HintProperty);
        set => SetValue(HintProperty, value);
    }

    public static readonly BindableProperty IconProperty = BindableProperty.Create(
        nameof(Icon), typeof(string), typeof(MaterialEntry), string.Empty,
        BindingMode.TwoWay, null, OnIconPropertyChanged);

    private static void OnIconPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
        if(bindable is MaterialEntry materialEntry && materialEntry.Content is SfTextInputLayout inputLayout) {
            // Assuming the leading view is a Label
            if(inputLayout.LeadingView is Label iconLabel) {
                iconLabel.Text = (string)newValue;
            }
        }
    }

    public string Icon {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text), typeof(string), typeof(MaterialEntry), string.Empty,
        BindingMode.TwoWay, null, OnTextPropertyChanged);

    private static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
        if(bindable is MaterialEntry materialEntry && materialEntry.Content is SfTextInputLayout inputLayout) {
            if(inputLayout.Content is Entry entry) {
                entry.Text = (string)newValue;
            }
        }
    }

    public string Text {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty IconColorProperty = BindableProperty.Create(
        nameof(IconColor), typeof(Color), typeof(MaterialEntry), Colors.Black,
        BindingMode.TwoWay, null, OnIconColorPropertyChanged);

    private static void OnIconColorPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
        if(bindable is MaterialEntry materialEntry && materialEntry.Content is SfTextInputLayout inputLayout) {
            if(inputLayout.LeadingView is Label iconLabel) {
                iconLabel.TextColor = (Color)newValue;
            }
        }
    }

    public Color IconColor {
        get => (Color)GetValue(IconColorProperty);
        set => SetValue(IconColorProperty, value);
    }

    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
        nameof(IsPassword), typeof(bool), typeof(MaterialEntry), false,
        BindingMode.TwoWay, null, OnIsPasswordPropertyChanged);

    private static void OnIsPasswordPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
        if(bindable is MaterialEntry materialEntry && materialEntry.Content is SfTextInputLayout inputLayout) {
            if(inputLayout.Content is Entry entry) {
                entry.IsPassword = (bool)newValue;
            }
        }
    }

    public bool IsPassword {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }

    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
        nameof(TextColor), typeof(Color), typeof(MaterialEntry),
        Colors.Black,
        BindingMode.TwoWay, null, OnTextColorPropertyChanged);


    private static void OnTextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
        if(bindable is MaterialEntry materialEntry && materialEntry.Content is SfTextInputLayout inputLayout) {
            if(inputLayout.Content is Entry entry) {
                entry.TextColor = (Color)newValue;
            }
        }
    }

    public Color TextColor {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public MaterialEntry() {
        InitializeComponent();
    }
}