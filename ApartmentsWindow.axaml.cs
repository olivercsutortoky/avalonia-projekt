<Window xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        x:Class="ApartmentBooking.Views.ApartmentsWindow"
        Width="720" Height="520"
        WindowStartupLocation="CenterOwner"
        Title="Sprava apartmanu">

	<!-- Grid se dvema sloupci: vlevo seznam (*), vpravo formular (300px). -->
	<Grid ColumnDefinitions="*,300" Margin="15">

		<!-- LEVA STRANA: seznam apartmanu -->
		<Grid Grid.Column="0" RowDefinitions="Auto,*,Auto" Margin="0,0,15,0">
			<TextBlock Grid.Row="0" Text="Apartmany" FontSize="18" FontWeight="Bold"/>
			<ListBox Grid.Row="1" x:Name="ApartmentsList" Margin="0,10,0,10"/>
			<Button Grid.Row="2" Content="Smazat vybrany" Click="OnDeleteClick"/>
		</Grid>

		<!-- PRAVA STRANA: formular pro pridani -->
		<StackPanel Grid.Column="1" Spacing="6">
			<TextBlock Text="Novy apartman" FontSize="18" FontWeight="Bold"/>

			<TextBlock Text="Nazev:"/>
			<TextBox x:Name="NameBox"/>

			<TextBlock Text="Adresa:"/>
			<TextBox x:Name="AddressBox"/>

			<TextBlock Text="Cena za noc (Kc):"/>
			<TextBox x:Name="PriceBox"/>

			<TextBlock Text="Kapacita (osob):"/>
			<TextBox x:Name="CapacityBox"/>

			<TextBlock Text="Popis:"/>
			<TextBox x:Name="DescriptionBox" AcceptsReturn="True" Height="50"/>

			<Button Content="Pridat apartman" Click="OnAddClick"/>
			<TextBlock x:Name="InfoLabel" Foreground="DarkRed" TextWrapping="Wrap"/>
			<Button Content="Zavrit" Click="OnCloseClick"/>
		</StackPanel>
	</Grid>
</Window>
