# ConferenceRooms

`ConferenceRooms` — ASP.NET Core Web API для керування конференц-залами та бронюваннями.

## Можливості

- перегляд списку залів;
- створення, оновлення та видалення залів;
- пошук доступних залів за датою, часом і місткістю;
- створення бронювання з вибором додаткових послуг;
- автоматичний розрахунок вартості бронювання;
- Swagger UI для тестування API.
- Звіт по завантаженості залів

## Технології

- .NET 8
- ASP.NET Core Web API
- Swagger / OpenAPI
- In-memory зберігання даних
- `PostgreSQL` (`Npgsql`)

## Вимоги

- `.NET SDK 8`
- `PostgreSQL` (локально або віддалено)

## Налаштування

Рядок підключення задається в `ConferenceRooms/appsettings.json`:

- `ConnectionStrings:ConferenceRoomsDb`

За замовчуванням:

- `Host=localhost;Port=5432;Database=conference_rooms;Username=postgres;Password=postgres`

## Запуск

1. Відкрити корінь репозиторію.
2. Переконатися, що PostgreSQL доступний.
3. Запустити застосунок:
   - `dotnet run --project ConferenceRooms/ConferenceRooms.csproj`
4. Відкрити Swagger:
   - `http://localhost:5000/swagger`
   - або `https://localhost:7148/swagger`

> Під час старту застосунок створює БД (`EnsureCreated`) і додає тестові дані (`DbSeeder`), якщо таблиця залів порожня.

## Основні API-ендпоїнти

### Rooms

- `GET /api/rooms` — список залів
- `POST /api/rooms` — створення залу
- `PUT /api/rooms/{id}` — оновлення залу
- `DELETE /api/rooms/{id}` — видалення залу
- `GET /api/rooms/available?start={dateTime}&end={dateTime}&capacity={int}` — пошук вільних залів

### Bookings

- `POST /api/bookings` — створення бронювання

### Reports

- `GET /api/reports/room-utilization?from={dateTime}&to={dateTime}` — звіт завантаженості

## Приклади тіл запитів

### `POST /api/rooms`

```json
{
  "name": "Room D",
  "capacity": 40,
  "baseHourlyRate": 2500,
  "services": [
    { "name": "Wi-Fi", "price": 300 },
    { "name": "Projector", "price": 500 }
  ]
}
```

### `POST /api/bookings`

```json
{
  "roomId": "00000000-0000-0000-0000-000000000000",
  "start": "2026-09-10T10:00:00Z",
  "durationHours": 2,
  "selectedServiceNames": ["Wi-Fi", "Projector"]
}
```