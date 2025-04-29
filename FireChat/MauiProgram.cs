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
                fonts.AddFont("MauiMaterialAssets.ttf", "MauiMaterial");
            });
#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton(new FirebaseAuthClient
            (new FirebaseAuthConfig {

                ApiKey = Credentials.FirebaseAuthApiKey,
                AuthDomain = "firechat-5db0b.firebaseapp.com",
                Providers = [
                     new EmailProvider(),
                ],
                UserRepository = new FileUserRepository(
                    Path.Combine(FileSystem.AppDataDirectory, "users.json"))
            }));



        builder.Services.AddTransient<RegisterPopUp>();
        builder.Services.AddSingleton<AppShell>();

        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddTransient<LoginPageViewModel>();

        return builder.Build();
    }
}
