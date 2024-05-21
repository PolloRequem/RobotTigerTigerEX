-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Creato il: Mag 21, 2024 alle 23:19
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
-- Struttura della tabella `missions`
--

CREATE TABLE `missions` (
  `id` varchar(11) NOT NULL,
  `nome` varchar(20) NOT NULL,
  `robot` varchar(20) NOT NULL,
  `player` varchar(20) NOT NULL,
  `punteggio` int(11) DEFAULT NULL,
  `dataInizio` date NOT NULL DEFAULT current_timestamp(),
  `dataFine` date DEFAULT NULL,
  `completata` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `missions`
--

INSERT INTO `missions` (`id`, `nome`, `robot`, `player`, `punteggio`, `dataInizio`, `dataFine`, `completata`) VALUES
('109046975', 'dwe', 'Robot_6', 'BBB', NULL, '2024-05-19', NULL, 0),
('1234567890', 'Missione_1', 'Giovanni', 'Gennaro', NULL, '2024-05-18', NULL, 0),
('159834740', 'll', 'Robot_9', 'BBB', NULL, '2024-05-19', NULL, 0),
('188564387', 'www', 'Robot_2', 'BBB', NULL, '2024-05-19', NULL, 0),
('22222222', 'Mission_3', 'Francesco', 'Pippo', 13000, '2024-05-18', '2024-05-19', 1),
('348623676', 'qww', 'Robot_9', 'BBB', NULL, '2024-05-19', NULL, 0),
('459516017', 'SKS', 'Robot_9', 'BBB', NULL, '2024-05-21', NULL, 0),
('572075382', 'oo', 'Robot_1', 'BBB', NULL, '2024-05-21', NULL, 0),
('686781466', 'yy', 'Robot_6', 'BBB', NULL, '2024-05-21', NULL, 0),
('709646187', 'l', 'Robot_9', 'BBB', NULL, '2024-05-19', NULL, 0),
('744224609', 'mk', 'Robot_2', 'BBB', NULL, '2024-05-19', NULL, 0),
('795513646', 'Ms2', 'Robot_6', 'BBB', NULL, '2024-05-19', NULL, 0),
('808590522', 'jrpo', 'Esivalletto', 'BBB', NULL, '2024-05-18', NULL, 0);

-- --------------------------------------------------------

--
-- Struttura della tabella `players`
--

CREATE TABLE `players` (
  `id` int(11) NOT NULL,
  `username` varchar(20) NOT NULL,
  `role` varchar(10) NOT NULL DEFAULT 'user',
  `email` varchar(30) NOT NULL,
  `hash` varchar(100) NOT NULL,
  `salt` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `players`
--

INSERT INTO `players` (`id`, `username`, `role`, `email`, `hash`, `salt`) VALUES
(2, 'BBB', 'admin', 'dante@1.com', 'UUsVth6ikposqTlB2rHJwRt8L2VV3yqGyuGtXWTUv5A=', 'KWLTQdoiUZ6udc9LmYs8Dw=='),
(1, 'dante', 'user', 'dante@peano.it', '1', '1');

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
('1', 1, '2023-06-26', 3428),
('1', 2, '2023-06-26', 9146),
('1', 3, '2023-06-26', 3767),
('109046975', 0, '2023-06-26', 1084),
('109046975', 1, '0000-00-00', 3656),
('109046975', 5, '0000-00-00', 7371),
('1234567890', 1, '2024-05-20', 323),
('159834740', 6, '0000-00-00', 2927),
('2', 0, '2023-06-28', 8405),
('2', 1, '2023-06-28', 4993),
('2', 2, '2023-06-28', 7848),
('2', 3, '2023-06-28', 9807),
('3', 1, '2023-06-12', 1),
('3', 2, '2023-06-12', 17),
('3', 3, '2023-06-12', 14),
('3', 4, '2023-06-12', 16),
('31722371', 1, '0000-00-00', 7009),
('37822371', 1, '0000-00-00', 4151),
('3782371', 1, '0000-00-00', 6349);

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
-- Indici per le tabelle `missions`
--
ALTER TABLE `missions`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `nome` (`nome`);

--
-- Indici per le tabelle `players`
--
ALTER TABLE `players`
  ADD PRIMARY KEY (`username`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indici per le tabelle `ritrovamenti`
--
ALTER TABLE `ritrovamenti`
  ADD PRIMARY KEY (`missione`,`materiale`),
  ADD KEY `materiale` (`materiale`);

--
-- Indici per le tabelle `robots`
--
ALTER TABLE `robots`
  ADD PRIMARY KEY (`nome`,`seriale`);

--
-- AUTO_INCREMENT per le tabelle scaricate
--

--
-- AUTO_INCREMENT per la tabella `players`
--
ALTER TABLE `players`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
