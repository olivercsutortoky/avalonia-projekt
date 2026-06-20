using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ApartmentBooking.Models;
using ApartmentBooking.Services;

namespace ApartmentBooking.Views
{
    // ============================================================
    //  Okno pro spravu apartmanu.
    //  Vlevo seznam vsech apartmanu, vpravo formular pro pridani.
    //  Lze take smazat vybrany apartman.
    // ============================================================
    public partial class ApartmentsWindow : Window
    {
        public ApartmentsWindow()
        {
            InitializeComponent();
            RefreshList();
        }

        // === Naplneni seznamu ===
        private void RefreshList()
        {
            // Apartmany se v ListBoxu zobrazi pomoci sve metody ToString().
            List<Apartment> apartments = App.Booking.GetAllApartments();

            // Trik: nejdriv nastavime null a pak znovu seznam, aby se ListBox
            // spolehlive prekreslil i po zmenach.
            ApartmentsList.ItemsSource = null;
            ApartmentsList.ItemsSource = apartments;

            InfoLabel.Text = "Pocet apartmanu: " + apartments.Count;
        }

        // === Pridani noveho apartmanu ===
        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            // Veskera validace (prazdne pole, cislo, rozsah) probiha uvnitr logiky.
            ValidationResult result = App.Booking.AddApartment(
                NameBox.Text,
                AddressBox.Text,
                PriceBox.Text,
                CapacityBox.Text,
                DescriptionBox.Text);

            if (!result.IsValid)
            {
                InfoLabel.Text = result.ErrorMessage;
                return;
            }

            // Po uspechu vycistime formular a obnovime seznam.
            NameBox.Text = "";
            AddressBox.Text = "";
            PriceBox.Text = "";
            CapacityBox.Text = "";
            DescriptionBox.Text = "";
            RefreshList();
        }

        // === Smazani vybraneho apartmanu ===
        private void OnDeleteClick(object sender, RoutedEventArgs e)
        {
            Apartment selected = ApartmentsList.SelectedItem as Apartment;
            if (selected == null)
            {
                InfoLabel.Text = "Nejdrive vyberte apartman v seznamu.";
                return;
            }

            ValidationResult result = App.Booking.DeleteApartment(selected.Id);
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
