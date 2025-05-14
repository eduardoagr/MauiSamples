namespace FireChat.Views;

public partial class ChatPage : ContentPage {

    public ChatPage(ChatPageViewModel viewModel) {

        InitializeComponent();

        BindingContext = viewModel;
    }

    private void ProfileContainerGrid_Clicked(object sender, EventArgs e) {

    }
}
