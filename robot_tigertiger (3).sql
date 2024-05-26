-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Creato il: Mag 26, 2024 alle 22:56
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
('109046944', 'h', 'Robot_2', 'aaa', 1000, '2024-05-25', '2024-05-03', 0),
('109046975', 'dwe', 'Robot_6', 'BBB', 1000, '2024-05-19', NULL, 0),
('1234567890', 'Missione_1', 'Giovanni', 'Gennaro', NULL, '2024-05-18', NULL, 0),
('159834740', 'll', 'Robot_9', 'BBB', NULL, '2024-05-19', NULL, 0),
('188564387', 'www', 'Robot_2', 'BBB', NULL, '2024-05-19', NULL, 0),
('22222222', 'Mission_3', 'Francesco', 'Pippo', 13000, '2024-05-18', '2024-05-19', 1),
('269447289', 'Prova', 'Robot_6', 'BBB', NULL, '2024-05-22', NULL, 0),
('348623676', 'qww', 'Robot_9', 'BBB', NULL, '2024-05-19', NULL, 0),
('380346358', 'SUDOKU', 'Robot_2', 'BBB', NULL, '2024-05-21', NULL, 0),
('383940702', 'EZIVALLE', 'Robot_9', 'BBB', NULL, '2024-05-22', NULL, 0),
('396532861', 'rr', 'Robot_6', 'BBB', NULL, '2024-05-22', NULL, 0),
('459516017', 'SKS', 'Robot_9', 'BBB', NULL, '2024-05-21', NULL, 0),
('461365384', 'DD', 'Robot_9', 'aaa', 1000, '2024-05-25', '2024-05-04', 0),
('572075382', 'oo', 'Robot_1', 'BBB', NULL, '2024-05-21', NULL, 0),
('584879021', 'AMission1', 'Robot_2', 'aaa', NULL, '2024-05-23', NULL, 0),
('686781466', 'yy', 'Robot_6', 'BBB', 2400, '2024-05-21', NULL, 0),
('709646187', 'l', 'Robot_9', 'BBB', 3000, '2024-05-19', '2024-05-04', 0),
('744224609', 'mk', 'Robot_2', 'BBB', 2400, '2024-05-19', '2024-05-03', 0),
('795513646', 'Ms2', 'Robot_6', 'BBB', NULL, '2024-05-19', NULL, 0),
('805598334', 'rew', 'Robot_2', 'BBB', NULL, '2024-05-22', NULL, 0),
('808590522', 'jrpo', 'Esivalletto', 'BBB', NULL, '2024-05-18', NULL, 0),
('853209315', 'AXO', 'Robot_2', 'BBB', NULL, '2024-05-22', NULL, 0),
('853708831', 'EzivallettoP', 'Robot_2', 'aaa', NULL, '2024-05-26', NULL, 0),
('933243068', 'Mission2AAA', 'Robot_9', 'aaa', 3000, '2024-05-23', '2024-05-08', 0),
('966023419', 'Ver3', 'Robot_2', 'BBB', NULL, '2024-05-22', NULL, 0);

-- --------------------------------------------------------

--
-- Struttura della tabella `players`
--

CREATE TABLE `players` (
  `id` int(11) NOT NULL,
  `username` varchar(15) NOT NULL,
  `role` varchar(10) NOT NULL DEFAULT 'user',
  `email` varchar(30) NOT NULL,
  `hash` varchar(100) NOT NULL,
  `salt` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `players`
--

INSERT INTO `players` (`id`, `username`, `role`, `email`, `hash`, `salt`) VALUES
(8, 'dante', 'admin', 'baiunco.dante@gmail.com', 'OPZ0y8UAHAjT8jyoRR+/zNIaR0rd1DNvwBNslert+UY=', '1j41jBQa2Xg3sMmyEiASKw=='),
(9, 'andrea', 'user', 'munarin.andrea@peano.it', 'tfjBbXjURDr/is2mKQxamMPU/KG9KLmGKqZBBO+49rU=', 'I7qaEJgxOy+iigTWrPX6Gw=='),
(10, 'aaa', 'admin', 'ABCD', 'VjARezfkiQkh4vzYhZ/op7SKKvhSoWp8a5nk3tg4cgM=', '2Ns7GDDJAIQpVXFLD+DTFg=='),
(13, 'dummy77', 'user', 'dummy3@gmail.com', 'hFdjGPocS8MVxVkIN2frYUUsW0uYqO7ybLDzLIQNlLY=', 'JcgRjSje7lwY5hyrjQI5wQ==');

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
('1234567890', 6, '0000-00-00', 4030),
('159834740', 6, '0000-00-00', 2927),
('188564387', 6, '0000-00-00', 8341),
('2', 0, '2023-06-28', 8405),
('2', 1, '2023-06-28', 4993),
('2', 2, '2023-06-28', 7848),
('2', 3, '2023-06-28', 9807),
('269447289', 3, '0000-00-00', 4220),
('269447289', 6, '0000-00-00', 2663),
('3', 1, '2023-06-12', 1),
('3', 2, '2023-06-12', 17),
('3', 3, '2023-06-12', 14),
('3', 4, '2023-06-12', 16),
('31722371', 1, '0000-00-00', 7009),
('37822371', 1, '0000-00-00', 4151),
('3782371', 1, '0000-00-00', 6349),
('380346358', 5, '0000-00-00', 9594),
('383940702', 7, '0000-00-00', 7095),
('459516017', 5, '0000-00-00', 8728),
('459516017', 6, '0000-00-00', 5497),
('459516017', 8, '0000-00-00', 6299),
('461365384', 7, '0000-00-00', 9943),
('584879021', 5, '0000-00-00', 3685),
('805598334', 6, '0000-00-00', 642),
('853209315', 5, '0000-00-00', 1910),
('853708831', 7, '0000-00-00', 4337),
('933243068', 2, '0000-00-00', 2281),
('933243068', 8, '0000-00-00', 8031),
('966023419', 6, '0000-00-00', 5911);

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
  ADD PRIMARY KEY (`id`) USING BTREE,
  ADD UNIQUE KEY `username` (`username`) USING BTREE;

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
