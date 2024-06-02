-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Creato il: Giu 02, 2024 alle 21:57
-- Versione del server: 10.4.32-MariaDB
-- Versione PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `robot_tigertiger`
--
CREATE DATABASE IF NOT EXISTS `robot_tigertiger` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `robot_tigertiger`;

-- --------------------------------------------------------

--
-- Struttura della tabella `materiali`
--

CREATE TABLE `materiali` (
  `id` int(11) NOT NULL,
  `colore` varchar(30) NOT NULL,
  `descrizione` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `materiali`
--

INSERT INTO `materiali` (`id`, `colore`, `descrizione`) VALUES
(0, 'rosso', 'ferro'),
(1, 'verde', 'ambra'),
(2, 'blu', 'acqua'),
(3, 'giallo', 'calcite'),
(4, 'magenta', ''),
(5, 'orange', 'ciao'),
(6, 'white', ''),
(7, 'black', 'alt'),
(8, 'viola', ''),
(9, 'grigio', ''),
(10, 'grigio chiaro', ''),
(11, 'grigio scuro', ''),
(12, 'ciano', ''),
(13, 'marrone', '');

-- --------------------------------------------------------

--
-- Struttura della tabella `missions`
--

CREATE TABLE `missions` (
  `id` varchar(11) NOT NULL,
  `nome` varchar(20) NOT NULL,
  `robot` varchar(20) NOT NULL,
  `player` varchar(20) NOT NULL,
  `punteggio` int(11) DEFAULT 0,
  `dataInizio` date NOT NULL DEFAULT current_timestamp(),
  `dataFine` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `missions`
--

INSERT INTO `missions` (`id`, `nome`, `robot`, `player`, `punteggio`, `dataInizio`, `dataFine`) VALUES
('268633334', 'MissioneDiD', 'Robot_1', 'd', 0, '2024-06-02', NULL),
('974981352', 'Missione1', 'Robot_9', 'dante', 0, '2024-06-02', NULL);

-- --------------------------------------------------------

--
-- Struttura della tabella `players`
--

CREATE TABLE `players` (
  `id` int(11) NOT NULL,
  `username` varchar(15) NOT NULL,
  `role` varchar(10) NOT NULL DEFAULT 'user',
  `email` varchar(30) NOT NULL,
  `totalPoints` int(11) DEFAULT NULL,
  `missionsCompleted` int(11) DEFAULT 0,
  `hash` varchar(100) NOT NULL,
  `salt` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `players`
--

INSERT INTO `players` (`id`, `username`, `role`, `email`, `totalPoints`, `missionsCompleted`, `hash`, `salt`) VALUES
(8, 'dante', 'admin', 'baiunco.dante@gmail.com', 41950, 12, 'OPZ0y8UAHAjT8jyoRR+/zNIaR0rd1DNvwBNslert+UY=', '1j41jBQa2Xg3sMmyEiASKw=='),
(9, 'd', 'user', 'd', 1000, 1, 'tfjBbXjURDr/is2mKQxamMPU/KG9KLmGKqZBBO+49rU=', 'I7qaEJgxOy+iigTWrPX6Gw=='),
(10, 'aaa', 'admin', 'ABCD', 0, 0, 'VjARezfkiQkh4vzYhZ/op7SKKvhSoWp8a5nk3tg4cgM=', '2Ns7GDDJAIQpVXFLD+DTFg=='),
(13, 'dummy77', 'user', 'dummy3@gmail.com', 0, 0, 'hFdjGPocS8MVxVkIN2frYUUsW0uYqO7ybLDzLIQNlLY=', 'JcgRjSje7lwY5hyrjQI5wQ==');

-- --------------------------------------------------------

--
-- Struttura della tabella `ritrovamenti`
--

CREATE TABLE `ritrovamenti` (
  `missione` varchar(11) NOT NULL,
  `materiale` int(11) NOT NULL,
  `dataInizio` date NOT NULL,
  `parziali` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `ritrovamenti`
--

INSERT INTO `ritrovamenti` (`missione`, `materiale`, `dataInizio`, `parziali`) VALUES
('974981352', 3, '2024-06-02', 754),
('974981352', 6, '2024-06-02', 891),
('268633334', 2, '2024-06-02', 3519),
('268633334', 4, '2024-06-02', 3375);

-- --------------------------------------------------------

--
-- Struttura della tabella `robots`
--

CREATE TABLE `robots` (
  `nome` varchar(11) NOT NULL,
  `seriale` varchar(11) NOT NULL,
  `nPorte` int(2) NOT NULL,
  `nRuote` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `robots`
--

INSERT INTO `robots` (`nome`, `seriale`, `nPorte`, `nRuote`) VALUES
('Robot_1', '111', 2, 2),
('Robot_2', '222', 4, 4),
('Robot_6', '66', 2, 4),
('Robot_9', '999', 2, 2);

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `materiali`
--
ALTER TABLE `materiali`
  ADD PRIMARY KEY (`id`);

--
-- Indici per le tabelle `missions`
--
ALTER TABLE `missions`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `nome` (`nome`),
  ADD KEY `fk_player` (`player`),
  ADD KEY `fk_robot` (`robot`) USING BTREE;

--
-- Indici per le tabelle `players`
--
ALTER TABLE `players`
  ADD PRIMARY KEY (`id`) USING BTREE,
  ADD UNIQUE KEY `username` (`username`) USING BTREE;

--
-- Indici per le tabelle `ritrovamenti`
--
ALTER TABLE `ritrovamenti`
  ADD KEY `fk_missione` (`missione`),
  ADD KEY `fk_materiale` (`materiale`);

--
-- Indici per le tabelle `robots`
--
ALTER TABLE `robots`
  ADD PRIMARY KEY (`nome`,`seriale`);

--
-- AUTO_INCREMENT per le tabelle scaricate
--

--
-- AUTO_INCREMENT per la tabella `materiali`
--
ALTER TABLE `materiali`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT per la tabella `players`
--
ALTER TABLE `players`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- Limiti per le tabelle scaricate
--

--
-- Limiti per la tabella `missions`
--
ALTER TABLE `missions`
  ADD CONSTRAINT `fk_player` FOREIGN KEY (`player`) REFERENCES `players` (`username`),
  ADD CONSTRAINT `fk_robot` FOREIGN KEY (`robot`) REFERENCES `robots` (`nome`);

--
-- Limiti per la tabella `ritrovamenti`
--
ALTER TABLE `ritrovamenti`
  ADD CONSTRAINT `fk_materiale` FOREIGN KEY (`materiale`) REFERENCES `materiali` (`id`),
  ADD CONSTRAINT `fk_missione` FOREIGN KEY (`missione`) REFERENCES `missions` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
