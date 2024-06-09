# Robot Scout: Tiger Tiger

**Autore:** Dante Baiunco  
**Anno:** 5° anno ITIS G. Peano 2023/2024

## Descrizione
"Robot Scout: Tiger Tiger" è un'applicazione desktop sviluppata in C# utilizzando il motore Unity. L'applicazione interagisce con un database attraverso delle RESTful API fornite da un server scritto in Java, utilizzando JSON per lo scambio dei dati. Oltre alla gestione e visualizzazione dei dati, l'applicazione include un videogame integrato.

Il progetto completo è disponibile su [GitHub](https://github.com/PolloRequem/RobotTigerTigerEX).

## Funzionalità

### 1. Database
Il database contiene le seguenti tabelle:

- **Missioni:** `id`, `nome`, `robot`, `player`, `punteggio`, `dataInizio`, `dataFine`.
- **Ritrovamenti:** `id`, `missione`, `materiale`, `data`.
- **Materiali:** `id`, `colore`, `descrizione`.
- **Players:** `id`, `username`, `role`, `email`, `punteggioTotale`, `missioniCompletate`, `hash`, `salt`.
- **Robots:** `nome`, `seriale`, `nPorte`, `nRuote`.

#### Dettagli delle tabelle:

- **Players:** Ogni giocatore tiene traccia del proprio punteggio totale e delle missioni completate. Le password sono protette con crittografia hash e salt per una maggiore sicurezza.
- **Missioni:** Ogni missione inizia con punteggio 0 e senza una data di fine. I giocatori possono aggiungere ritrovamenti fino al completamento della missione, momento in cui vengono assegnati il punteggio e la data di fine.

### 2. Applicazione Desktop
L'applicazione gestisce missioni spaziali con robot, include un sistema di autenticazione con ruoli di "user" e "admin" e offre una LeaderBoard dei giocatori con più punti.

#### Dettagli funzionalità:

- **Profilo:** Visualizza e modifica i propri dati e le missioni iniziate.
- **Missions:** Visualizza tutte le missioni nel database.
- **Simulation:** Consente di completare missioni o esplorare nuove missioni o ritrovamenti esistenti.
- **Players:** Permette agli admin di visualizzare e gestire i giocatori, inclusa la possibilità di promuoverli, modificare i dettagli e cancellarli.

### 3. Web Service
Il servizio web, sviluppato in Java, utilizza l'architettura REST per l'interazione con l'applicazione desktop, e comprende tre parti principali:

- **JavaBean:** Classi per incapsulare i dati del database.
- **DAO (Data Access Object):** Classi per le operazioni CRUD sul database.
- **API:** Endpoint RESTful per autenticazione e gestione dati.

### 4. Perché ho scelto Unity?
- **Conoscenza approfondita:** Familiarità con Unity.
- **Interfaccia intuitiva:** Facilità nella creazione di interfacce utente.
- **Applicazione desktop:** Desiderio di creare un'app desktop eseguibile.
- **Integrazione di un videogioco:** Unity è ideale per sviluppare giochi.

### 5. Percorso del progetto
Il progetto è nato da un'esperienza PCTO, evolvendo verso un'applicazione che simula missioni spaziali gestite da robot. Originariamente orientato alla gestione di un robot fisico, il progetto si è poi trasformato in una simulazione virtuale e ha integrato elementi videoludici.

### 6. Documentazione Unity
- **UnityWebRequest:** Utilizzato per inviare richieste API al server.
- **Newtonsoft.Json:** Utilizzato per la serializzazione JSON.

## Come Provarlo

Per provare il progetto in locale, seguire questi passaggi:

1. **Scaricare il progetto:**
   - Scaricare la ZIP del progetto da [GitHub](https://github.com/PolloRequem/RobotTigerTigerEX).

2. **Scaricare il progetto JavaWebService:**
   - Trovato nella cartella omonima del progetto.

3. **Importare in NetBeans:**
   - Aprire il progetto con NetBeans e importare i jar necessari dal file del server.

4. **Configurare il server GlassFish:**
   - Aggiungere un server GlassFish versione 6.25 o inferiore.

5. **Hostare il DBMS:**
   - Utilizzare MySql con Xamp e importare il file .sql presente nel progetto.

6. **Installare l'applicazione:**
   - Installare la build dell'applicazione per il proprio sistema operativo.

Per eseguire il server da remoto, passare direttamente all'ultimo passaggio.

## Licenza
Questo progetto è concesso in licenza sotto i termini della licenza MIT. Vedi il file [LICENSE](https://github.com/PolloRequem/RobotTigerTigerEX/blob/main/LICENSE) per i dettagli.
