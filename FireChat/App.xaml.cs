namespace FireChat;

public partial class App : Application {

    private readonly AppShell _appShell;

    public App(AppShell appShell) {

        SyncfusionLicenseProvider.RegisterLicense(Keys.SyncfusionKey);

        InitializeComponent();
        _appShell = appShell;
    }

    protected override Window CreateWindow(IActivationState? activationState) {
        return new Window(_appShell);
    }
}
