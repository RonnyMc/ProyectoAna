-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Sep 03, 2019 at 05:23 PM
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
  `respuesta` varchar(500) NOT NULL,
  `respuestaPregunta` varchar(200) NOT NULL,
  PRIMARY KEY (`idComandos`)
) ENGINE=MyISAM AUTO_INCREMENT=68 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `comandos`
--

INSERT INTO `comandos` (`idComandos`, `comandos`, `accion`, `respuesta`, `respuestaPregunta`) VALUES
(18, 'Listo', '', 'Muy bien, Ahora dime, ¿Qué figuras geométricas conoces?', ''),
(17, '¿Qué clase haremos hoy?', 'C:\\VIDEOSLISTOS\\figuras.mp4', 'Hoy veremos la clase del conteo de figuras geometricas, si estas listo solo dime, listo', ''),
(9, 'Hola', 'C:\\VIDEOSLISTOS\\hola.mp4', 'Ey, Hola', ''),
(10, '¿Cómo estas?', '', 'Muy bien, Gracias', ''),
(11, 'abrir youtube', 'www.youtube.com', 'youtube is open now', ''),
(19, 'circulo', 'C:\\VIDEOSLISTOS\\circulo.mp4', 'Muy bien, este es el círculo, y no tiene esquinas. Ahora dime otra figura geométrica.', ''),
(20, 'triangulo', 'C:\\VIDEOSLISTOS\\triangulo.mp4', 'Perfecto, Este es un triangulo y tiene 3 lados, Sigue asi, dime uno mas.', ''),
(21, 'rombo', 'C:\\\\VIDEOSLISTOS\\\\rombo.mp4', 'Bien, este es el rombo, y tiene 4 lados tambien', ''),
(22, 'cuadrado', 'C:\\VIDEOSLISTOS\\cuadrado.mp4', 'Perfecto, este es el cuadrado y esta formado de 4 lados iguales', ''),
(23, 'Hola Ana', 'C:\\VIDEOSLISTOS\\pi.mp4', 'Hola mi nombre es Ana. Soy un asistente virtual Mis creadores son Anthony y Ronny y crearon ANA HOLOGRAPHIC. Somos de Perú en la región de LA LIBERTAD, ciudad de Trujillo. Estoy diseñado con el objetivo de mejorar el aprendizaje en estudiantes de primaria.', ''),
(24, 'Primera participacion', 'C:\\VIDEOSLISTOS\\1.mp4', '¿Cuántas figuras puedes ver en esta imágen?', 'Siete'),
(25, 'Segunda participación', 'C:\\VIDEOSLISTOS\\casa.mp4', '¿Cuántas figuras geométricas ves?', 'cinco'),
(29, 'Tercera Participación', 'C:\\VIDEOSLISTOS\\hombre.mp4', 'Ahora dime ¿Cuántas figuras geométricas hay aqui?', 'Siete'),
(30, 'Participación cuatro', 'C:\\VIDEOSLISTOS\\pez.mp4', 'Cuantas figuras geometricas ves?', 'seis'),
(33, 'examen uno', 'C:\\VIDEOSLISTOS\\practica1.mp4', 'Bien, ¿Cuántos circulos ves en esta imagen?', 'cuatro'),
(35, 'examen dos', 'C:\\VIDEOSLISTOS\\practica2.mp4', '¿Cuántos triangulos ves?', 'cuatro'),
(37, 'examen tres', 'C:\\VIDEOSLISTOS\\practica3.mp4', '¿Cuántas figuras geometricas puedes ver en total?', 'siete'),
(40, '¿Cuántos años tienes?', '', 'Desde mi creacion, puedo decir que tengo 1 año.', ''),
(41, '¿De dónde eres?', '', 'Yo Soy de Perú, y ya conozco Estados Unidos, Bueno solo La universidad estatal de Michigan ', ''),
(52, 'Gracias Ana', '', 'Un Placer, de nada', ''),
(53, 'Adios Ana', 'C:\\VIDEOSLISTOS\\hola.mp4', 'Fue un placer, espero haberte ayudado', ''),
(55, 'Muestrame la Luna', 'C:\\VIDEOSLISTOS\\luna.mp4', 'La Luna es un cuerpo astronómico que orbita el planeta Tierra y es el único satélite natural permanente de la Tierra.', ''),
(56, 'Muestrame un eclipse lunar', 'C:\\VIDEOSLISTOS\\eclipse.mp4', 'Un eclipse lunar es un evento astronómico que sucede cuando la Tierra se interpone entre el Sol y la Luna, generando un cono de sombra que oscurece a la Luna.', ''),
(57, 'mercurio', 'C:\\VIDEOSLISTOS\\mercury.mp4', 'Mercurio es el planeta más cercano al Sol, por lo que es el primer planeta del Sistema Solar. Lleva el nombre del dios mensajero romano. En la mitología, el dios era conocido por ser rápido: ¡Mercurio es el más rápido de todos los planetas en orbitar el Sol, porque tiene la ruta más pequeña que tiene que tomar!', ''),
(58, 'venus', 'C:\\VIDEOSLISTOS\\venus.mp4', 'Venus es el segundo planeta desde el sol. Lleva el nombre de La diosa romana de la belleza y el amor. Venus es casi el mismo tamaño que la Tierra, pero aparte del tamaño de los dos planetas son ¡muy diferente!', ''),
(60, 'tierra', 'C:\\VIDEOSLISTOS\\earth.mp4', 'La Tierra es el único planeta conocido que tiene formas de vida en el Sistema solar. Es el tercer planeta desde el Sol. Es el único planeta que no lleva el nombre de un dios.', ''),
(61, 'martes', 'C:\\VIDEOSLISTOS\\mars.mp4', 'Marte es el cuarto planeta desde el sol. Nombrado por el Dios romano de la guerra, también se le conoce como el \"Planeta Rojo\". Es El último de los planetas interiores.', ''),
(62, 'jupiter', 'C:\\VIDEOSLISTOS\\jupiter.mp4', 'Júpiter es el primero de los planetas exteriores, y el quinto planeta.\r\ndel sol. Lleva el nombre del rey de los dioses romanos. Eso Es el más grande de todos los planetas.', ''),
(63, 'saturno', 'C:\\VIDEOSLISTOS\\saturn.mp4', 'Saturno es el sexto planeta desde el Sol. Lleva el nombre del dios romano de la agricultura. Es más conocido por su gran anillos visibles', ''),
(64, 'urano', 'C:\\VIDEOSLISTOS\\uranus.mp4', 'Urano es el séptimo planeta desde el Sol. El unico planeta llamado así por un dios griego, su nombre proviene del dios del  cielo.', ''),
(65, 'neptuno', 'C:\\VIDEOSLISTOS\\neptune.mp4', 'Neptuno es el octavo y más lejano planeta del Sol. Es llamado así por el dios romano del mar. Es el más pequeño de los planetas exteriores y un gigante gaseoso.', '');

-- --------------------------------------------------------

--
-- Table structure for table `respuestas`
--

DROP TABLE IF EXISTS `respuestas`;
CREATE TABLE IF NOT EXISTS `respuestas` (
  `idRespuesta` int(11) NOT NULL AUTO_INCREMENT,
  `idComando` int(11) NOT NULL,
  `respuesta` varchar(200) NOT NULL,
  PRIMARY KEY (`idRespuesta`)
) ENGINE=MyISAM AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `respuestas`
--

INSERT INTO `respuestas` (`idRespuesta`, `idComando`, `respuesta`) VALUES
(8, 29, 'Siete'),
(9, 30, 'seis'),
(6, 24, 'Siete'),
(7, 25, 'cinco'),
(10, 33, 'cuatro'),
(11, 35, 'cuatro'),
(12, 37, 'siete');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
