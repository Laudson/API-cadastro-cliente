# Host: localhost  (Version 5.5.5-10.1.21-MariaDB)
# Date: 2018-01-05 10:17:24
# Generator: MySQL-Front 6.0  (Build 2.20)


#
# Structure for table "cad_cliente"
#

DROP TABLE IF EXISTS `cad_cliente`;
CREATE TABLE `cad_cliente` (
  `Codigo` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(255) DEFAULT NULL,
  `DataCadastro` date NOT NULL DEFAULT '0000-00-00',
  `Ativo` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

#
# Data for table "cad_cliente"
#


#
# Structure for table "cad_usuario"
#

DROP TABLE IF EXISTS `cad_usuario`;
CREATE TABLE `cad_usuario` (
  `Codigo` int(11) NOT NULL AUTO_INCREMENT,
  `Usuario` varchar(255) DEFAULT NULL,
  `Senha` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

#
# Data for table "cad_usuario"
#

