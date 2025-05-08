-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1:3306
-- Üretim Zamanı: 08 May 2025, 09:01:08
-- Sunucu sürümü: 9.1.0
-- PHP Sürümü: 8.3.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `ogrencikayit`
--
CREATE DATABASE IF NOT EXISTS `ogrencikayit` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
USE `ogrencikayit`;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `admin`
--

DROP TABLE IF EXISTS `admin`;
CREATE TABLE IF NOT EXISTS `admin` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Tablo döküm verisi `admin`
--

INSERT INTO `admin` (`id`, `username`, `password`, `created_at`) VALUES
(1, 'admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', '2025-05-07 10:58:15');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `cities`
--

DROP TABLE IF EXISTS `cities`;
CREATE TABLE IF NOT EXISTS `cities` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Tablo döküm verisi `cities`
--

INSERT INTO `cities` (`Id`, `Name`) VALUES
(1, 'Lefkoşa'),
(2, 'Mağusa'),
(3, 'Girne');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `departments`
--

DROP TABLE IF EXISTS `departments`;
CREATE TABLE IF NOT EXISTS `departments` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Tablo döküm verisi `departments`
--

INSERT INTO `departments` (`Id`, `Name`) VALUES
(1, 'Elektrik'),
(2, 'Bilişim'),
(3, 'Mobilya'),
(4, 'Makine'),
(5, 'Metal'),
(6, 'Motor');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ogrenciler`
--

DROP TABLE IF EXISTS `ogrenciler`;
CREATE TABLE IF NOT EXISTS `ogrenciler` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ogrenci_no` varchar(20) NOT NULL,
  `ad` varchar(50) NOT NULL,
  `soyad` varchar(50) NOT NULL,
  `dogum_tarihi` date NOT NULL,
  `cinsiyet` varchar(10) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `telefon` varchar(20) DEFAULT NULL,
  `adres` varchar(255) DEFAULT NULL,
  `bolum_id` int DEFAULT NULL,
  `sinif` varchar(10) DEFAULT NULL,
  `yil` varchar(20) DEFAULT NULL,
  `kayit_tarihi` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `kktc_kimlik_no` varchar(10) DEFAULT NULL,
  `veli_adi` varchar(100) DEFAULT NULL,
  `veli_telefon` varchar(20) DEFAULT NULL,
  `onceki_okul_id` int DEFAULT NULL,
  `okul_id` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `ogrenci_no` (`ogrenci_no`),
  KEY `okul_id` (`okul_id`),
  KEY `bolum_id` (`bolum_id`),
  KEY `onceki_okul_id` (`onceki_okul_id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Tablo döküm verisi `ogrenciler`
--

INSERT INTO `ogrenciler` (`id`, `ogrenci_no`, `ad`, `soyad`, `dogum_tarihi`, `cinsiyet`, `email`, `telefon`, `adres`, `bolum_id`, `sinif`, `yil`, `kayit_tarihi`, `kktc_kimlik_no`, `veli_adi`, `veli_telefon`, `onceki_okul_id`, `okul_id`) VALUES
(1, '476', 'Bilal Arda', 'Aksoy', '2007-11-22', 'Erkek', 'aabilal476@gmail.com', '05338220367', 'LütfiBiberoğlu Sokak', 2, '12', '2024-2025', '2025-05-07 12:17:52', '1234567890', 'Murat Aksoy', '05338445327', 1, 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `schools`
--

DROP TABLE IF EXISTS `schools`;
CREATE TABLE IF NOT EXISTS `schools` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `CityId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `CityId` (`CityId`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Tablo döküm verisi `schools`
--

INSERT INTO `schools` (`Id`, `Name`, `CityId`) VALUES
(1, 'SSEML', 1),
(2, 'Osman Örek Meslek Lisesi', 1),
(3, 'Dr. Fazıl Küçük Endüstri Meslek Lisesi', 2),
(4, 'Gazimağusa Meslek Lisesi', 2),
(5, 'Girne Turizm Meslek Lisesi', 3);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
