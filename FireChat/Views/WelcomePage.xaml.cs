namespace FireChat.Views;

public partial class WelcomePage : ContentPage {

    public WelcomePage(WelcomePageViewModel welcomePageViewModel) {
        BindingContext = welcomePageViewModel;
        InitializeComponent();
    }

    private void SKLottieView_AnimationCompleted(object sender, EventArgs e) {

        if(Shell.Current != null) {

        }
    }

}