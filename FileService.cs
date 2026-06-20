<Window xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        x:Class="ApartmentBooking.Views.NewReservationWindow"
        Width="450" Height="560"
        WindowStartupLocation="CenterOwner"
        Title="Nova rezervace">

	<!-- ScrollViewer umozni rolovat, kdyby se obsah nevesel do okna. -->
	<ScrollViewer>
		<StackPanel Margin="20" Spacing="8">
			<TextBlock Text="Nova rezervace" FontSize="20" FontWeight="Bold"/>

			<TextBlock Text="Host:"/>
			<!-- ComboBox = rozbalovaci seznam. Naplnime ho v kodu objekty Guest. -->
			<ComboBox x:Name="GuestCombo" HorizontalAlignment="Stretch"
			          SelectionChanged="OnVyberZmenen"/>

			<TextBlock Text="Apartman:"/>
			<ComboBox x:Name="ApartmentCombo" HorizontalAlignment="Stretch"
			          SelectionChanged="OnVyberZmenen"/>

			<TextBlock Text="Prijezd:"/>
			<!-- DatePicker = vyber data z kalendare. -->
			<DatePicker x:Name="CheckInPicker" SelectedDateChanged="OnDatumZmeneno"/>

			<TextBlock Text="Odjezd:"/>
			<DatePicker x:Name="CheckOutPicker" SelectedDateChanged="OnDatumZmeneno"/>

			<TextBlock Text="Poznamka:"/>
			<TextBox x:Name="NotesBox" AcceptsReturn="True" Height="60"/>

			<TextBlock x:Name="PriceLabel" Text="Cena: -" FontWeight="Bold"/>
			<!-- Cervena chybova hlaska. TextWrapping zalomi dlouhy text. -->
			<TextBlock x:Name="ErrorLabel" Foreground="Red" TextWrapping="Wrap"/>

			<StackPanel Orientation="Horizontal" Spacing="10">
				<Button Content="Ulozit" Click="OnUlozitClick"/>
				<Button Content="Zrusit" Click="OnZrusitClick"/>
			</StackPanel>
		</StackPanel>
	</ScrollViewer>
</Window>
