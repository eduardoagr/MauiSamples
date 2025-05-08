using FireChat.Handlers;

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

        // Apply the global borderless handler
        BorderlessEntryHandler.ApplyCustomHandler();

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


        builder.Services.AddSingleton<AppShellViewModel>();

        builder.Services.AddTransient<RegisterPopUp>();
        builder.Services.AddSingleton<AppShell>();

        builder.Services.AddTransient<ChatPageViewModel>();
        builder.Services.AddSingleton<ChatPage>();

        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddTransient<LoginPageViewModel>();

        builder.Services.AddSingleton<MainWindow>();

        builder.Services.AddSingleton(WeakReferenceMessenger.Default);

        builder.Services.AddSingleton(MediaPicker.Default);

        builder.Services.AddSingleton<FirestoreService>();

        return builder.Build();
    }
}
