using Firebase.Auth.Repository;

namespace FireChat;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureSyncfusionCore()
            .ConfigureFonts(fonts => {
                fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialSymbol");
                fonts.AddFont("FontAwesome6FreeBrands.otf", "FontAwesomeBrands");
                fonts.AddFont("FontAwesome6FreeRegular.otf", "FontAwesomeRegular");
                fonts.AddFont("FontAwesome6FreeSolid.otf", "FontAwesomeSolid");
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton(new FirebaseAuthClient
            (new FirebaseAuthConfig {

                ApiKey = Keys.FirebaseAuthApiKey,
                AuthDomain = "firechat-5db0b.firebaseapp.com",
                Providers = [
                     new EmailProvider(),
                ],
                UserRepository = new FileUserRepository(
                    Path.Combine(FileSystem.AppDataDirectory, "users.json"))
            }));



        builder.Services.AddSingleton<RegisterPopUp>();
        builder.Services.AddSingleton<AppShell>();

        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginPageViewModel>();

        return builder.Build();
    }
}
