namespace FireChat.Views;

public partial class WelcomePage : ContentPage {

    public WelcomePageViewModel WelcomePageViewModel;

    public WelcomePage(WelcomePageViewModel welcomePageViewModel) {

        BindingContext = welcomePageViewModel;
        InitializeComponent();
        WelcomePageViewModel = welcomePageViewModel;
    }

    private void SKLottieView_AnimationCompleted(object sender, EventArgs e) {

        if(Shell.Current != null) {

            WelcomePageViewModel.CheckAuthCommand.Execute(null);

        }
    }

}