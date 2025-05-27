// <copyright file="MainPage.xaml.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171
{
    /// <summary>
    /// Main page for the VocalLink application.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private int count = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            this.count++;

            if (this.count == 1)
            {
                this.CounterBtn.Text = $"Clicked {this.count} time";
            }
            else
            {
                this.CounterBtn.Text = $"Clicked {this.count} times";
            }

            SemanticScreenReader.Announce(this.CounterBtn.Text);
        }
    }
}
