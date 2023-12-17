GlobalConfiguration definiert globale Einstellungen, die für alle Routen gelten.

Routes definiert spezifische Pfade, die das API-Gateway zu den entsprechenden Microservices weiterleitet.

**DownstreamPathTemplate**

ist der Pfad, der von Ihrem Microservice erwartet wird.


**DownstreamScheme**

gibt das Protokoll an, das verwendet wird (in diesem Fall HTTP).


**DownstreamHostAndPorts**

definiert den Host und Port, auf dem Ihr Microservice läuft.


**UpstreamPathTemplate**

ist der Pfad, den der Client aufruft.


**UpstreamHttpMethod**

definiert die HTTP-Methoden, die für den Pfad zulässig sind.
