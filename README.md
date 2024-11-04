# Ketterä-ohjelmistoprojekti - GymApp

## Yhteenveto
Tämä projekti on Gym Management App eli kuntosalinhallintasovellus, joka on kehitetty Ketterä ohjelmistokehitysprojekti-kurssia varten. Sovellus tarjoaa  ominaisuudet kuntosalin hallintaan ja asiakkaiden seurantaan.

## Tekijät
- Miro Kuisma
- Jami Mäkelä
- Mikko Rautavirta
- Aleksi S Pulkkinen
- Noel Ihantoja
- Lauri Niemi

## 🚀Käytetyt Teknologiat

**Käyttöliittymä:** `.NET Windows Forms`

**Tietokanta:** `10.4.32-MariaDB`

**Palvelin:** `Apache/2.4.5`8 & `PHP/8.2.12`

## Kuvakaappaukset

![Sovelluksen kuvakaappaus](https://i.imgur.com/xELdyRb.png)

## Asennusohjeet
 1. Lataa ja asenna [𝑿𝑨𝑴𝑷𝑷 8.2.12](https://sourceforge.net/projects/xampp/files/XAMPP%20Windows/8.2.12/xampp-windows-x64-8.2.12-0-VS16-installer.exe).
 2. Asenna .NET Framework Windowsille.
 3. Avaa XAMPP ja käynnistä Apache-palvelin sekä MySQL.
 4. Lataa projektin tiedostoista viimeisin GymApp.sql-tiedosto jolla voit rakentaa tietokannan.
     ```bash
     https://github.com/MikkoCode/KetteraOhjelmistoProjekti/GymApp.sql
     ```
 6. Avaa phpMyAdmin selaimessa ja tuo viimeisin GymApp.sql tiedosto luodaksesi tietokannan
## Vaihtoehto 1: ##
 1. Kloonaa projekti haluamaasi kansioon:
     ```bash
     git clone https://github.com/MikkoCode/KetteraOhjelmistoProjekti.git
     ```
 2. Suorita komento "dotnet build" tai käytä ulkoista ohjelmointiympäristöä rakentaaksesi ohjelman (Muokkaa tiedostopolku oikein)
     ```bash
     dotnet build /path/to/project/GymApp.csproj
     ```
 3. Nyt voit siirtyä /bin/ alakansioon ja avata GymApp.exe-sovelluksen
## Vaihtoehto 2: ##
 1. Lataaa viimeisin GymApp.exe tämän projektin tiedostoista, ja suorita se
