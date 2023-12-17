# ApiGateway

Das ApiGateway ist die zentrale Schnittstelle zwischen dem Frontend und den verschiedenen Services in CreativeCharts. Es
wurde in C# entwickelt und nutzt das .NET 7.0 Framework.

## Funktionalität

Das ApiGateway ermöglicht die Kommunikation zwischen dem Frontend und den Microservices. Es routet Anfragen an die
entsprechenden Services und gewährleistet eine effiziente Datenübertragung. Zu den Hauptfunktionen gehören:

- Weiterleitung von Anfragen an die relevanten Services
- Sicherstellung der Authentifizierung und Autorisierung von Anfragen
- Fehlerhandling und Protokollierung von Anfragen und Antworten

## Einrichtung

**Voraussetzungen:**

- [.NET 7.0](https://dotnet.microsoft.com/download/dotnet/7.0) installieren.

**Cli-Kommando zum Herunterladen des ApiGateway-Repositorys und Starten des ApiGateway:**

```bash
git clone [ApiGateway-Repository-URL]
```

```bash
cd [ApiGateway-Verzeichnis]
```

```bash
dotnet run Program.cs
