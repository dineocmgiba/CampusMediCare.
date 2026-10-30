using CampusMediCare.Pages;
using Microsoft.Maui.Controls;

namespace CampusMediCare.Mobile.Pages
{
    public class LoginPage : ContentPage
    {
        Entry emailEntry, passEntry;

        public LoginPage()
        {
            Title = "Login";

            emailEntry = new Entry { Placeholder = "Enter Email id", Keyboard = Keyboard.Email };
            passEntry = new Entry { Placeholder = "Enter Password", IsPassword = true };

            var loginBtn = new Button
            {
                Text = "Login",
                BackgroundColor = Color.FromArgb("#00A9A5"),
                TextColor = Colors.White,
                CornerRadius = 25,
                HeightRequest = 50
            };
            loginBtn.Clicked += OnLoginClicked;

            var forgotLabel = new Label { Text = "Forget Password?", TextColor = Color.FromArgb("#00A9A5"), HorizontalOptions = LayoutOptions.End };
            forgotLabel.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await Shell.Current.GoToAsync(nameof(ForgotPasswordPage)))
            });

            var registerLabel = new Label { Text = "Don't have account? Register Now", TextColor = Color.FromArgb("#00A9A5"), HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
            registerLabel.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await Shell.Current.GoToAsync(nameof(RegisterPage)))
            });

            Content = new ScrollView
            {
                Content = new VerticalStackLayout
                {
                    Padding = 30,
                    Spacing = 15,
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Label { Text = "Welcome !", FontSize = 28, FontAttributes = FontAttributes.Bold },
                        new Label { Text = "Enter your email and password.", TextColor = Colors.Gray },
                        emailEntry,
                        passEntry,
                        forgotLabel,
                        loginBtn,
                        new Label { Text = "OR", HorizontalOptions = LayoutOptions.Center, TextColor = Colors.Gray, Margin = new Thickness(0,10) },
                        registerLabel
                    }
                }
            };
        }

        async void OnLoginClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailEntry.Text) || string.IsNullOrWhiteSpace(passEntry.Text))
            {
                await DisplayAlert("Error", "Enter Email ID and Password", "OK");
                return;
            }
            // For now, just test - later we connect API
            await DisplayAlert("Login Clicked", $"Email: {emailEntry.Text}", "OK");
        }
    }
}