-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Jun 15, 2018 at 06:14 AM
-- Server version: 5.7.19
-- PHP Version: 7.1.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `baseana`
--

-- --------------------------------------------------------

--
-- Table structure for table `comandos`
--

DROP TABLE IF EXISTS `comandos`;
CREATE TABLE IF NOT EXISTS `comandos` (
  `idComandos` int(11) NOT NULL AUTO_INCREMENT,
  `comandos` varchar(255) NOT NULL,
  `accion` varchar(255) NOT NULL,
  `respuesta` varchar(255) NOT NULL,
  PRIMARY KEY (`idComandos`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `comandos`
--

INSERT INTO `comandos` (`idComandos`, `comandos`, `accion`, `respuesta`) VALUES
(1, 'Hola Ana', '', 'Hola, señor'),
(2, 'Como estas', '', 'Bien, gracias'),
(3, 'abrir google', 'www.google.com', 'Google Abierto');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
