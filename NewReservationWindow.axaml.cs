# Rezervační systém apartmánů

Desktopová aplikace pro správu rezervací apartmánů. Umožňuje evidovat apartmány a hosty,
vytvářet rezervace, hlídat kolize termínů a počítat cenu za pobyt. Data se ukládají
do textových souborů ve složce AppData.

## Téma

Téma projektu je **rezervace apartmánů**. Systém pracuje se třemi typy objektů:
apartmán, host a rezervace.

## Funkce

- Správa apartmánů (přidání, smazání, seznam) – název, adresa, cena za noc, kapacita, popis
- Správa hostů (přidání, smazání, seznam) – jméno, příjmení, e-mail, telefon
- Vytváření rezervací s výběrem hosta, apartmánu a termínu
- Automatická kontrola kolize termínů – jeden apartmán nelze rezervovat dvakrát na stejné dny
- Automatický výpočet ceny (počet nocí × cena za noc)
- Potvrzení a zrušení rezervace
- Validace všech vstupů (prázdná pole, formát e-mailu, formát čísla, rozsahy, data)
- Ukládání dat do souborů `.txt` ve složce AppData

## Technologie

- C# / .NET 8
- Avalonia UI 11 (multiplatformní GUI framework)

## Spuštění

V kořenové složce projektu spusťte:

```
dotnet run
```

Potřebujete nainstalované **.NET SDK 8** nebo novější.

## Kde se ukládají data

Aplikace si při prvním spuštění vytvoří složku:

- Windows: `C:\Users\<jméno>\AppData\Roaming\ApartmentBooking\`
- Linux: `~/.config/ApartmentBooking/`

Uvnitř vzniknou soubory `guests.txt`, `apartments.txt`, `reservations.txt`
a případně `error.log`.

## Struktura projektu

```
ApartmentBooking/
├── Program.cs              vstupní bod aplikace
├── App.axaml(.cs)          spuštění aplikace + sdílená logika
├── Models/                 datové třídy (objekty)
│   ├── Guest.cs
│   ├── Apartment.cs
│   └── Reservation.cs
├── Services/               aplikační logika (oddělená od GUI)
│   ├── ValidationService.cs
│   ├── FileService.cs
│   └── BookingService.cs
└── Views/                  okna (GUI)
    ├── MainWindow.axaml(.cs)
    ├── NewReservationWindow.axaml(.cs)
    ├── ApartmentsWindow.axaml(.cs)
    └── GuestsWindow.axaml(.cs)
```

GUI nikdy nepracuje se soubory přímo a nevaliduje samo – veškerou logiku volá přes
třídu `BookingService`. To zajišťuje oddělení aplikační logiky od zobrazení.

## Formát dat

Každý záznam je jeden řádek, hodnoty oddělené znakem `|`. Řádky začínající `#`
jsou komentáře (hlavička souboru). Příklad `apartments.txt`:

```
# ApartmentBooking - Apartments
# Format: Id|Name|Address|PricePerNight|Capacity|IsAvailable|Description
1|Apartman Vltava|Praha 1, Kaprova 12|1800|2|True|Utulny apartman v centru.
```

## Rozdělení práce

- **Člen 1** – datové třídy (Models) a aplikační/datová vrstva (Services):
  ukládání do souborů, AppData, validace, hlavní logika rezervací.
- **Člen 2** – GUI: hlavní okno s přehledem rezervací a okno pro vytvoření rezervace.
- **Člen 3** – GUI: okno pro správu apartmánů a okno pro správu hostů.

## Poznámka k použití AI

Při vývoji projektu byly částečně využity nástroje umělé inteligence jako pomocník
(například při psaní opakujícího se kódu, kontrole a hledání chyb). Veškerému
odevzdanému kódu rozumíme a jsme schopni ho vysvětlit.
