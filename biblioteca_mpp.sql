-- phpMyAdmin SQL Dump
-- version 3.4.5
-- http://www.phpmyadmin.net
--
-- Gazda: localhost
-- Timp de generare: 02 May 2014 la 00:05
-- Versiune server: 5.5.16
-- Versiune PHP: 5.3.8

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Baza de date: `biblioteca_mpp`
--

-- --------------------------------------------------------

--
-- Structura de tabel pentru tabelul `abonati`
--

CREATE TABLE IF NOT EXISTS `abonati` (
  `IDUser` varchar(8) NOT NULL,
  `Nume` varchar(64) NOT NULL,
  PRIMARY KEY (`IDUser`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Salvarea datelor din tabel `abonati`
--

INSERT INTO `abonati` (`IDUser`, `Nume`) VALUES
('user0001', 'userul unu'),
('user0002', 'al doilea user');

-- --------------------------------------------------------

--
-- Structura de tabel pentru tabelul `carti`
--

CREATE TABLE IF NOT EXISTS `carti` (
  `CodCarte` varchar(32) NOT NULL,
  `Titlu` varchar(32) NOT NULL,
  `Autor` varchar(32) DEFAULT NULL,
  `NrExemplare` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`CodCarte`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Salvarea datelor din tabel `carti`
--

INSERT INTO `carti` (`CodCarte`, `Titlu`, `Autor`, `NrExemplare`) VALUES
('08080', 'titluuuuuuuu', 'autoooooooor', 7),
('3124125', 'titlu carte 1', 'autor unu', 3),
('45262', 'titlu carte 2', 'alt autor', 1),
('c2313', 'alt titlu de carteeee', 'unnn autor', 5);

-- --------------------------------------------------------

--
-- Structura de tabel pentru tabelul `imprumuturi`
--

CREATE TABLE IF NOT EXISTS `imprumuturi` (
  `IDUser` varchar(8) NOT NULL DEFAULT '',
  `CodCarte` varchar(32) NOT NULL DEFAULT '',
  PRIMARY KEY (`CodCarte`,`IDUser`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Salvarea datelor din tabel `imprumuturi`
--

INSERT INTO `imprumuturi` (`IDUser`, `CodCarte`) VALUES
('user0001', '08080'),
('user0001', '3124125'),
('user0001', 'c2313');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
