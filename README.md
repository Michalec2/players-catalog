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

# *Update pod projekt z programowania sieciowego*

## Integracja z zewnętrznymi API

Aplikacja Katalog Piłkarzy integruje się z zewnętrznym API **football-data.org**, które dostarcza dane na temat rozgrywek piłkarskich. API to pozwala na pobieranie szczegółowych informacji o rozgrywkach, takich jak nazwa, region, i daty rozpoczęcia sezonu.

### Użycie API w kontrolerze
W kontrolerze aplikacji wykorzystywany jest `HttpClient` do wysyłania zapytań do API. W nagłówkach zapytania dodawany jest klucz autoryzacyjny w postaci tokenu, który jest wymagany do uzyskania dostępu do danych.

Fragment kodu odpowiedzialny za integrację z API:
```csharp
HttpClient.DefaultRequestHeaders.Add("X-Auth-Token", "TOKEN-TUTAJ");

var response = await HttpClient.GetAsync("https://api.football-data.org/v4/competitions");
if (!response.IsSuccessStatusCode)
{
    var responseMessage = await response.Content.ReadAsStringAsync();
    return View("Error");
}

var apiContent = await response.Content.ReadAsStringAsync();
var apiCompetitions = JsonConvert.DeserializeObject<CompetitionsModel>(apiContent);
```

### Wymagania dotyczące tokenu
Aby móc korzystać z API, użytkownik musi podać **token autoryzacyjny**, który jest używany w nagłówkach zapytań. Token ten można uzyskać rejestrując się na stronie [football-data.org](https://www.football-data.org/). Po uzyskaniu tokenu, należy go dodać w kodzie aplikacji w miejscu oznaczonym jako `X-Auth-Token`. 

Bez poprawnego tokenu aplikacja nie będzie mogła pobierać danych z API.

## Dokumentacja API (Swagger)

Aplikacja udostępnia interfejs dokumentacji API w postaci Swaggera, który jest dostępny pod adresem `/swagger`. Dzięki temu użytkownicy mogą przeglądać dostępne endpointy, testować zapytania i sprawdzać odpowiedzi w prosty sposób.

Aby uzyskać dostęp do dokumentacji API, wystarczy uruchomić aplikację i przejść do:
```
http://localhost:5192/swagger
```