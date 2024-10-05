## Opis projektu
Aplikacja Katalog Piłkarzy to system umożliwiający zarządzanie informacjami o piłkarzach, drużynach oraz trenerach. Użytkownicy mogą dodawać dane o piłkarzach, a zalogowani je edytować.  

## Instalacja i wymagania
### Wymagania
- .NET 8.0
- SQLite
- Visual Studio 2022 lub nowszy (opcjonalnie)

### Instalacja
1. **Migracje bazy danych:**
   ```
   dotnet ef database update
   ```

2. **Uruchom aplikację:**
   ```
   dotnet run
   ```

## Konfiguracja
### Połączenie z bazą danych
W pliku appsettings.json jest sekcja ConnectionStrings. Domyślnie:
```
"ConnectionStrings": {
  "DefaultConnection": "Data Source=database.db"
}
```

Plik również jest w repozytorium.

### Testowi użytkownicy
Aplikacja zawiera testowego użytkownika do przetestowana aplikacji: test123/test123

## Opis działania aplikacji
Aplikacja Katalog Piłkarzy oferuje przyjazny interfejs użytkownika, który umożliwia wykonywanie następujących czynności:

1. Logowanie: Użytkownicy mogą się zalogować przy użyciu swoich danych logowania.
2. Przeglądanie drużyn: Użytkownicy mogą przeglądać listę drużyn oraz szczegóły dotyczące poszczególnych piłkarzy.
3. Dodawanie informacji: Wszyscy użytkownicy mogą dodawać nowych piłkarzy, drużyni i trenerów do bazy danych.
4. Edycja i usuwanie: Użytkownicy zalogowani mają możliwość edytowania lub usuwania istniejących piłkarzy.

## Polecenia SQL
Polecenia sql procedura1.sql procedura2.sql trigget.sql funkcja.sql to kolejne rzeczy z wymagań, nie miałem pomysłu na implementacje w projekcie z Entity Framework więc dołączam je do repozytorium. Można je będzie zaimplementować w przyszłości przy dodaniu kilku dodatkowych pól w bazie i rozszerzeniu aplikacji.