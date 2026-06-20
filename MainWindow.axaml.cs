using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ApartmentBooking.Models;
using ApartmentBooking.Services;

namespace ApartmentBooking.Views
{
    // ============================================================
    //  Okno pro spravu hostu.
    //  Vlevo seznam vsech hostu, vpravo formular pro pridani.
    //  Lze take smazat vybraneho hosta.
    // ============================================================
    public partial class GuestsWindow : Window
    {
        public GuestsWindow()
        {
            InitializeComponent();
            RefreshList();
        }

        // === Naplneni seznamu hostu ===
        private void RefreshList()
        {
            List<Guest> guests = App.Booking.GetAllGuests();

            GuestsList.ItemsSource = null;
            GuestsList.ItemsSource = guests;

            InfoLabel.Text = "Pocet hostu: " + guests.Count;
        }

        // === Pridani noveho hosta ===
        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            ValidationResult result = App.Booking.AddGuest(
                FirstNameBox.Text,
                LastNameBox.Text,
                EmailBox.Text,
                PhoneBox.Text);

            if (!result.IsValid)
            {
                InfoLabel.Text = result.ErrorMessage;
                return;
            }

            // Vycisteni formulare po uspesnem pridani.
            FirstNameBox.Text = "";
            LastNameBox.Text = "";
            EmailBox.Text = "";
            PhoneBox.Text = "";
            RefreshList();
        }

        // === Smazani vybraneho hosta ===
        private void OnDeleteClick(object sender, RoutedEventArgs e)
        {
            Guest selected = GuestsList.SelectedItem as Guest;
            if (selected == null)
            {
                InfoLabel.Text = "Nejdrive vyberte hosta v seznamu.";
                return;
            }

            ValidationResult result = App.Booking.DeleteGuest(selected.Id);
            if (!result.IsValid)
                InfoLabel.Text = result.ErrorMessage;
            else
                RefreshList();
        }

        // === Zavreni okna ===
        private void OnCloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
