namespace FireChat;

public partial class App : Application {

    public static MainWindow? WindowInstance { get; private set; }

    public App(MainWindow mainWindow) {

        InitializeComponent();
        WindowInstance = mainWindow;
    }

    protected override Window CreateWindow(IActivationState? activationState) => WindowInstance!;
}
