-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : Dim 11 sep. 2022 à 20:56
-- Version du serveur :  5.7.31
-- Version de PHP : 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `projet_delta_v11`
--

-- --------------------------------------------------------

--
-- Structure de la table `articles`
--

DROP TABLE IF EXISTS `articles`;
CREATE TABLE IF NOT EXISTS `articles` (
  `IdArticles` varchar(10) NOT NULL,
  `Designation` varchar(255) NOT NULL,
  `pu_USD_piece` decimal(65,2) NOT NULL DEFAULT '0.00',
  `pu_CDF_piece` decimal(65,2) NOT NULL DEFAULT '0.00',
  `pu_USD_type` decimal(65,2) NOT NULL DEFAULT '0.00',
  `pu_CDF_type` decimal(65,2) NOT NULL DEFAULT '0.00',
  `nbrePce` int(100) NOT NULL,
  `qte_piece_type` int(100) NOT NULL,
  `qte_type` decimal(65,2) NOT NULL DEFAULT '0.00',
  `taux` int(100) NOT NULL,
  `qte_critique_piece` int(100) NOT NULL,
  `qte_critique_type` int(100) NOT NULL,
  `etatArticle` bit(1) NOT NULL,
  `dateCreation` date NOT NULL,
  `dateSortie` date NOT NULL,
  `typeArticleID` int(11) NOT NULL,
  `RayonID` varchar(15) NOT NULL,
  `categorieID` varchar(15) NOT NULL,
  `UtilisateurID` int(11) NOT NULL,
  `EtablissementID` varchar(15) NOT NULL,
  `codeID` varchar(15) NOT NULL,
  PRIMARY KEY (`IdArticles`),
  KEY `EtablissementID` (`EtablissementID`),
  KEY `categorieID` (`categorieID`),
  KEY `RayonID` (`RayonID`),
  KEY `typeArticleID` (`typeArticleID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `articlesdepot`
--

DROP TABLE IF EXISTS `articlesdepot`;
CREATE TABLE IF NOT EXISTS `articlesdepot` (
  `IdArticles` varchar(10) NOT NULL,
  `Designation` varchar(255) NOT NULL,
  `pu_USD_piece` decimal(65,2) NOT NULL DEFAULT '0.00',
  `pu_CDF_piece` decimal(65,2) NOT NULL DEFAULT '0.00',
  `pu_USD_type` decimal(65,2) NOT NULL DEFAULT '0.00',
  `pu_CDF_type` decimal(65,2) NOT NULL DEFAULT '0.00',
  `nbrePce` int(100) NOT NULL,
  `qte_piece_type` int(100) NOT NULL,
  `qte_type` decimal(65,2) NOT NULL DEFAULT '0.00',
  `taux` int(100) NOT NULL,
  `qte_critique_piece` int(100) NOT NULL,
  `qte_critique_type` int(100) NOT NULL,
  `etatArticle` bit(1) NOT NULL,
  `dateCreation` date NOT NULL,
  `dateSortie` date NOT NULL,
  `typeArticleID` int(11) NOT NULL,
  `RayonID` varchar(15) NOT NULL,
  `UtilisateurID` int(11) NOT NULL,
  `categorieID` varchar(15) NOT NULL,
  `EtablissementID` varchar(15) NOT NULL,
  `codeID` varchar(15) NOT NULL,
  PRIMARY KEY (`IdArticles`),
  KEY `EtablissementID` (`EtablissementID`),
  KEY `categorieID` (`categorieID`),
  KEY `RayonID` (`RayonID`),
  KEY `typeArticleID` (`typeArticleID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `bon_entree_depot`
--

DROP TABLE IF EXISTS `bon_entree_depot`;
CREATE TABLE IF NOT EXISTS `bon_entree_depot` (
  `numBE_Dep` varchar(50) NOT NULL,
  `UtilisateurId` int(11) NOT NULL,
  `TransactionDate` date NOT NULL,
  `HeureTransaction` varchar(12) NOT NULL,
  `provenance` varchar(100) NOT NULL,
  `numConteneur` varchar(100) NOT NULL,
  `moyen_transport` varchar(100) NOT NULL,
  `puTotal` decimal(65,2) NOT NULL DEFAULT '0.00',
  `transporteur` varchar(100) NOT NULL,
  `EtablissementId` varchar(20) NOT NULL,
  PRIMARY KEY (`numBE_Dep`),
  KEY `EtablissementId` (`EtablissementId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `bon_sortievers_magasin`
--

DROP TABLE IF EXISTS `bon_sortievers_magasin`;
CREATE TABLE IF NOT EXISTS `bon_sortievers_magasin` (
  `numBS_MAG` varchar(20) NOT NULL,
  `TransactionDate` date NOT NULL,
  `HeureTransaction` varchar(12) NOT NULL,
  `provenance` varchar(20) NOT NULL,
  `destination` varchar(20) NOT NULL,
  `transporteur` varchar(100) NOT NULL,
  `moyen_transport` varchar(100) NOT NULL,
  `TotalPu` decimal(65,2) NOT NULL DEFAULT '0.00',
  `IdUtilisateur` int(11) NOT NULL,
  PRIMARY KEY (`numBS_MAG`),
  KEY `provenance` (`provenance`),
  KEY `destination` (`destination`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `bon_transfert`
--

DROP TABLE IF EXISTS `bon_transfert`;
CREATE TABLE IF NOT EXISTS `bon_transfert` (
  `numBon_Transfert` varchar(20) NOT NULL,
  `provenanceTransf` varchar(50) NOT NULL,
  `destinationTransf` varchar(50) NOT NULL,
  `transporteur` varchar(100) NOT NULL,
  `puTotal_CDF_piece` decimal(65,2) NOT NULL DEFAULT '0.00',
  `dateTransf` date NOT NULL,
  `HeureTrans` varchar(12) NOT NULL,
  `Taux` int(11) NOT NULL,
  `idUtilisateur` int(11) NOT NULL,
  PRIMARY KEY (`numBon_Transfert`),
  KEY `provenanceTransf` (`provenanceTransf`),
  KEY `destinationTransf` (`destinationTransf`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `caisse`
--

DROP TABLE IF EXISTS `caisse`;
CREATE TABLE IF NOT EXISTS `caisse` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomCaisse` varchar(15) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `categorie`
--

DROP TABLE IF EXISTS `categorie`;
CREATE TABLE IF NOT EXISTS `categorie` (
  `numCat` varchar(20) NOT NULL,
  `nomCategorie` varchar(50) NOT NULL,
  PRIMARY KEY (`numCat`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `client`
--

DROP TABLE IF EXISTS `client`;
CREATE TABLE IF NOT EXISTS `client` (
  `idClient` varchar(15) NOT NULL,
  `nomClient` varchar(100) NOT NULL,
  `montantTotalCDF` decimal(65,2) NOT NULL DEFAULT '0.00',
  `montantTotalUSD` decimal(65,2) NOT NULL DEFAULT '0.00',
  `TvaCDF` decimal(65,2) NOT NULL DEFAULT '0.00',
  `TvaUSD` decimal(65,2) NOT NULL DEFAULT '0.00',
  `TotalAPayerCDF` decimal(65,2) NOT NULL DEFAULT '0.00',
  `TotalAPayerUSD` decimal(65,2) NOT NULL DEFAULT '0.00',
  `taux` int(11) NOT NULL,
  `typePayement` int(1) NOT NULL,
  `refFact` int(11) NOT NULL,
  `TransactionDate` date NOT NULL,
  `UtilisateurID` int(11) NOT NULL,
  `caisseID` int(11) NOT NULL,
  `codeEtabID` varchar(20) NOT NULL,
  PRIMARY KEY (`idClient`),
  KEY `codeEtabID` (`codeEtabID`),
  KEY `caisseID` (`caisseID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `declassement`
--

DROP TABLE IF EXISTS `declassement`;
CREATE TABLE IF NOT EXISTS `declassement` (
  `idMvt` int(11) NOT NULL AUTO_INCREMENT,
  `dateTrans` date NOT NULL,
  `codeArticle` varchar(20) NOT NULL,
  `typeArticleID` int(11) NOT NULL,
  `categorieID` varchar(20) NOT NULL,
  `nbrePce` int(100) NOT NULL,
  `qteMv` int(100) NOT NULL,
  `qteTypeMv` decimal(65,2) NOT NULL DEFAULT '0.00',
  `pu_Sortie` decimal(65,2) NOT NULL DEFAULT '0.00',
  `puStock` decimal(65,2) NOT NULL DEFAULT '0.00',
  `montantMv` decimal(65,2) NOT NULL DEFAULT '0.00',
  `montantStock` decimal(65,2) NOT NULL DEFAULT '0.00',
  `motif` varchar(100) NOT NULL,
  `transporteur` varchar(100) NOT NULL,
  `codeEtab` varchar(20) NOT NULL,
  `taux` int(11) NOT NULL,
  `user` int(11) NOT NULL,
  PRIMARY KEY (`idMvt`),
  KEY `codeArticle` (`codeArticle`),
  KEY `typeArticleID` (`typeArticleID`),
  KEY `categorieID` (`categorieID`),
  KEY `codeEtab` (`codeEtab`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `declassementdepot`
--

DROP TABLE IF EXISTS `declassementdepot`;
CREATE TABLE IF NOT EXISTS `declassementdepot` (
  `idMvt` int(11) NOT NULL AUTO_INCREMENT,
  `dateTrans` date NOT NULL,
  `codeArticle` varchar(20) NOT NULL,
  `typeArticleID` int(11) NOT NULL,
  `nbrePce` int(100) NOT NULL,
  `qteMv` int(100) NOT NULL,
  `qteTypeMv` decimal(65,2) NOT NULL DEFAULT '0.00',
  `pu_Sortie` decimal(65,2) NOT NULL DEFAULT '0.00',
  `puStock` decimal(65,2) NOT NULL DEFAULT '0.00',
  `montantMv` decimal(65,2) NOT NULL DEFAULT '0.00',
  `montantStock` decimal(65,2) NOT NULL DEFAULT '0.00',
  `motif` varchar(100) NOT NULL,
  `transporteur` varchar(100) NOT NULL,
  `taux` int(20) NOT NULL,
  `user` int(20) NOT NULL,
  `categorieID` varchar(20) NOT NULL,
  `codeEtab` varchar(20) NOT NULL,
  PRIMARY KEY (`idMvt`),
  KEY `codeArticle` (`codeArticle`),
  KEY `typeArticleID` (`typeArticleID`),
  KEY `codeEtab` (`codeEtab`),
  KEY `categorieID` (`categorieID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `detailbon_transfert`
--

DROP TABLE IF EXISTS `detailbon_transfert`;
CREATE TABLE IF NOT EXISTS `detailbon_transfert` (
  `numDetailBon_Transf` int(11) NOT NULL AUTO_INCREMENT,
  `numBon_Transf` varchar(20) NOT NULL,
  `provenanceBT` varchar(20) NOT NULL,
  `destinationTransf` varchar(20) NOT NULL,
  `codeMvt` varchar(20) NOT NULL,
  `typeArticleID` int(11) NOT NULL,
  `pu_CDF_piece` decimal(65,2) NOT NULL DEFAULT '0.00',
  `pu_CDF_piece_stock` decimal(65,2) NOT NULL DEFAULT '0.00',
  `qte_piece_type` int(100) NOT NULL,
  `qte_type` decimal(65,2) NOT NULL DEFAULT '0.00',
  `dateTransf` date NOT NULL,
  PRIMARY KEY (`numDetailBon_Transf`),
  KEY `numBon_Transf` (`numBon_Transf`),
  KEY `provenanceBT` (`provenanceBT`),
  KEY `destinationTransf` (`destinationTransf`),
  KEY `typeArticleID` (`typeArticleID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `detailsbe_depot`
--

DROP TABLE IF EXISTS `detailsbe_depot`;
CREATE TABLE IF NOT EXISTS `detailsbe_depot` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `numBE` varchar(20) NOT NULL,
  `provenance` varchar(100) NOT NULL,
  `ArticleID` varchar(20) NOT NULL,
  `pu_USD_piece` decimal(65,2) NOT NULL DEFAULT '0.00',
  `pu_CDF_piece` decimal(65,2) NOT NULL DEFAULT '0.00',
  `qte_piece_type` int(100) NOT NULL,
  `qte_type` int(100) NOT NULL,
  `taux` int(20) NOT NULL,
  `typeId` int(11) NOT NULL,
  `etatArriveeArticle` varchar(100) NOT NULL,
  `etablissementID` varchar(20) NOT NULL,
  `dateJour` date NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `ArticleID` (`ArticleID`),
  KEY `typeId` (`typeId`),
  KEY `etablissementID` (`etablissementID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `detailsbsvers_magasin`
--

DROP TABLE IF EXISTS `detailsbsvers_magasin`;
CREATE TABLE IF NOT EXISTS `detailsbsvers_magasin` (
  `idBS` int(11) NOT NULL AUTO_INCREMENT,
  `numBS` varchar(20) NOT NULL,
  `provenance` varchar(20) NOT NULL,
  `destination` varchar(20) NOT NULL,
  `IDArticle` varchar(20) NOT NULL,
  `codeMvt` varchar(20) NOT NULL,
  `pu_USD_piece` decimal(65,2) NOT NULL DEFAULT '0.00',
  `pu_CDF_piece` decimal(65,2) NOT NULL DEFAULT '0.00',
  `qte_piece_type` int(100) NOT NULL,
  `qte_type` decimal(65,2) NOT NULL DEFAULT '0.00',
  `taux` int(100) NOT NULL,
  `typeId` int(11) NOT NULL,
  `dateSortie` date NOT NULL,
  PRIMARY KEY (`idBS`),
  KEY `IDArticle` (`IDArticle`),
  KEY `typeId` (`typeId`),
  KEY `numBS` (`numBS`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `devise`
--

DROP TABLE IF EXISTS `devise`;
CREATE TABLE IF NOT EXISTS `devise` (
  `idDevise` int(11) NOT NULL AUTO_INCREMENT,
  `Devise` varchar(100) NOT NULL,
  PRIMARY KEY (`idDevise`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `etablissement`
--

DROP TABLE IF EXISTS `etablissement`;
CREATE TABLE IF NOT EXISTS `etablissement` (
  `codeEtab` varchar(15) NOT NULL,
  `nomEtab` varchar(150) NOT NULL,
  `adresseEtab` varchar(255) NOT NULL,
  `registreCommercial` varchar(50) NOT NULL,
  `villeEtab` varchar(150) NOT NULL,
  `dateCreationEtab` date NOT NULL,
  `etatEtab` bit(1) NOT NULL DEFAULT b'1',
  `pictures` blob NOT NULL,
  `idCodeEtab` varchar(15) NOT NULL,
  `connected` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`codeEtab`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `etablissement`
--

INSERT INTO `etablissement` (`codeEtab`, `nomEtab`, `adresseEtab`, `registreCommercial`, `villeEtab`, `dateCreationEtab`, `etatEtab`, `pictures`, `idCodeEtab`, `connected`) VALUES
('ETAB66700', 'BndMobetisoft', 'AV.MANIEMA,12314, C/LUBUMBASHI', 'A15204', 'Lubumbashi', '2022-05-28', b'1', 0x89504e470d0a1a0a0000000d49484452000000d40000006d08020000005679d8f20000000467414d410000b18f0bfc6105000000097048597300000ec300000ec301c76fa8640000071349444154785eed9cbd6ddc4c10865588c3af0a95a04855a80007ea40f98506dc802ab8c4502582d4810343812140803efeeccfbbb3b3cb25efc8117def03053eeedfccecc325ef025f7d126204e52366503e6206e52366503e6206e52366503e6206e52366503e6206e52366503e6206e52366503e6206e52366503e6206e52366503e6206e52366503e6206e52366503e6206e52366503e6206e52366503e6206e52366503e6206e52366503e6206e52366503e6206e52366503e6206e52366503e6206e52366503e6206e52366503e6206e52366503e6206e523665cac7cc7bb9ea3fbd4f17cb8beeab93e3cbb2b4472bc1b4a14c0fa2dc048be9885d55ecb3a3aa89e8abf3325a795cb44be249513ef9ec568f6513d05d8adb13ef1c289f5b239f9d0be26f9d094331b02b16c711fcc4ebde378e831b92fd447d49083147141f976211f763fb37c30f599a55698bf5361c416f74506dcf2dafaf3d311ec41bef40179d66d9828ef5981b5a63d870aad1e5801f5d08bcc4a47e7ebcb97aab7d6b1b7a57a136b61c256e2cd516f798c5ffc0b47d2b3633ad189a20130f759950ea045ad5cdfddb9a8a6520de1b706df5e19bdefbc74dca02a16f2a559548a9ca53be99e94b55266987c98d67d9ed6bb8d795b35d07e0ba493378d9b5199ac34e9a536c66175b6974fa4512c82ac56b96bde13d16d8231c3b4628e96fdccf7238ec29fb0e552a722d7addc2e4b2a8383a27aaba4b3b57cf98ee92550ee34a5635a5c578bace2cac0387d6950696b3a20b671b4b25d8133eed580284c29cac5959988f7ace96c2b5f967d47558d48966a329798245f277648278781d9aa62493129b4c2c87220f5bdc2c9958a04e252a5f944984d95d10a3e413d9d36b6942f4fbc47963a14e2fa70883511b962b5b4323456331fba60605930984c0b1281ae25f764f9b47e69f827546682a974dad850be90f6f5e108754cf2803ecfc50dc15dd0aba06b9ea16c5fcbc864cda27ac92e9784721427092871899eb2c74995d10697b663399bc997689594c0670217fb4bf03129056e6aa10838bde82216c988b363334e08c114d7c1868e429881a96df5ed5da31e09d664a4b06431e28e7a1430b230f77c36922f863e469e54abbb04a9b992420f74af563d4f61684f6c922d23b11d26c735fd304c40c4814d3dfa4a913cf7043f9d5b452c8cb14516540626d246c79153e9cc6013f962623e72bd66901994096b51a99ea7b297130556e2ecc1ed4ec92751fa96e27454c28546584959a26f3dad32305c1b5d0d72395bc817138b3584743c905629d9e90a2f2f30b4cf5c7324ae5cfba6f4f97cec09d76076a9b26f9233c09038663aca132a53995ca4338ff5e58b918beaaa451c28d509ae675b35001df2f6d60aa723cb5102626a18a3c61fe6994e1497c4f41dbe199bd428a143d65e6beb694e672e6bcb171353775c05924df3aa9778a286d5e6d028a3c425b569a13d0c4dc6b8abeaea6aa2b1678c251d2d54171d6ad94d34cae44770ee6a3ab35957be453116dd2bdf83d8525aa81c4b18ab0c4d2a8f8b42283298a42925e988730f4bc3c0104aece4c7aaa9c2d0799589cd625c00a696948634b2aa7c10b69ab846b623295809d73c5d3e87124eb8541e8a2be668e35261035936857e30a5125e1c24e6c3389b2b0383b2f03cade9cc674df920b3f2de0a30d3c220ad18ad95c01d72340c5546d5131221b6eeab98347307baabebcfad0cf4af56a1359db96c23dfdde1b9b65700ee737d83ff7d14e707ce55974ceead59fb0bc75cf026bb74f9f2a3ec9c1501b5cf7694cde4abc947b6a1f589bb2a94ef22f902c75e07e5bb40f0696ee81ee5bb44e0dc337dafa67cc40cca47cca07c97ccd3dbcded9f9b9f1feee3d650be4be3f5efcd7fbfbfc5bfb75fae617b28df65e215fcfee42e5840f9b6e6f1f1f1e1e1c17d388df7efc91936fefdf9f1ea9a2bfcba1f3adffe7d71174ca07c5bd39977d5f6bf491471eaf47ff0d07c7a7317efdfdd95125fe2d8eba07c3bc39d76dd17855135f8bae09b26be407cfcb81d1c353ef63a28dfae18cebcfeb47bf939ca171fb2e527a9fa74568f3defa5fb6b7a829f00e5db23feb9e90f39a757ee937f408f4f67b0307334b1d93dc1291fc98077bef097ff62e28e317c0ae7e765cf937b8207235f5e3fbabfe19f5ec4c9f7c82550bedd217fa8d3dfde9ca0208d372f35297c4d517ff05bd1bc0ecab737f0495a7acfcb4fb8681e1e7bd13ced15705df33a28dfbe48dff60af2f9773bef0d9857b8981d7bae7545f33a28df9e90bf9278815275dc79e64eb851d09bfb37f86d2fbc0ebe6b3fbb282f8beb40f976847f4ac64764bc321ad35be88dece48bdf82e3c5a7f1ec4cd42c7d5c19cab71be4b137e02fa231f026170ec5e4218b33645f5f9497bfb5a07c7bc12bb5fed37033281f3183f21133281f3183f21133281f3183f21133281f3183f21133281f3183f21133281f3183f21133281f3183f21133281f3183f21133281f3183f21133281f3183f211233e3fff071ee40b679c8ba90d0000000049454e44ae426082, 'ETAB66700', 0);

-- --------------------------------------------------------

--
-- Structure de la table `facture`
--

DROP TABLE IF EXISTS `facture`;
CREATE TABLE IF NOT EXISTS `facture` (
  `idFacture` int(11) NOT NULL AUTO_INCREMENT,
  `ClientID` varchar(20) NOT NULL,
  `ArticleID` varchar(20) NOT NULL,
  `typeArticleID` int(11) NOT NULL,
  `Quantite` int(100) NOT NULL,
  `PU_Sortie_CDF` decimal(65,2) NOT NULL DEFAULT '0.00',
  `PU_Stock_CDF` decimal(65,2) NOT NULL DEFAULT '0.00',
  `PU_Sortie_USD` decimal(65,2) NOT NULL DEFAULT '0.00',
  `PU_Stock_USD` decimal(65,2) NOT NULL DEFAULT '0.00',
  `TotalPrix_Sortie_CDF` decimal(65,2) NOT NULL DEFAULT '0.00',
  `TotalPrix_Stock_CDF` decimal(65,2) NOT NULL DEFAULT '0.00',
  `TotalPrix_Sortie_USD` decimal(65,2) NOT NULL DEFAULT '0.00',
  `TotalPrix_Stock_USD` decimal(65,2) NOT NULL DEFAULT '0.00',
  `refFact` int(11) NOT NULL,
  `CaisseID` int(11) NOT NULL,
  `DeviseID` int(11) NOT NULL,
  `TransactionDate` date NOT NULL,
  `EtablissementID` varchar(20) NOT NULL,
  PRIMARY KEY (`idFacture`),
  KEY `ClientID` (`ClientID`),
  KEY `ArticleID` (`ArticleID`),
  KEY `typeArticleID` (`typeArticleID`),
  KEY `CaisseID` (`CaisseID`),
  KEY `DeviseID` (`DeviseID`),
  KEY `EtablissementID` (`EtablissementID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `fstk`
--

DROP TABLE IF EXISTS `fstk`;
CREATE TABLE IF NOT EXISTS `fstk` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codeEtab` varchar(20) NOT NULL,
  `IdArticle` varchar(20) NOT NULL,
  `qteInitiale` int(100) NOT NULL DEFAULT '0',
  `qteEntree` int(100) NOT NULL DEFAULT '0',
  `qteVendue` int(100) NOT NULL DEFAULT '0',
  `qteTransf` int(100) NOT NULL DEFAULT '0',
  `qteDeclasse` int(100) NOT NULL DEFAULT '0',
  `qteFinale` int(100) NOT NULL DEFAULT '0',
  `dateJour` date NOT NULL,
  `userId` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `codeEtab` (`codeEtab`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `fstkdepot`
--

DROP TABLE IF EXISTS `fstkdepot`;
CREATE TABLE IF NOT EXISTS `fstkdepot` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codeEtab` varchar(20) NOT NULL,
  `IdArticle` varchar(20) NOT NULL,
  `qteInitiale` int(100) NOT NULL DEFAULT '0',
  `qteEntree` int(100) NOT NULL DEFAULT '0',
  `qteVendue` int(100) NOT NULL DEFAULT '0',
  `qteTransf` int(100) NOT NULL DEFAULT '0',
  `qteDeclasse` int(100) NOT NULL DEFAULT '0',
  `qteFinale` int(100) NOT NULL DEFAULT '0',
  `dateJour` date NOT NULL,
  `userId` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `codeEtab` (`codeEtab`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `param`
--

DROP TABLE IF EXISTS `param`;
CREATE TABLE IF NOT EXISTS `param` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `ProductKey` varchar(50) NOT NULL,
  `TrialExpiryDate` timestamp NOT NULL,
  `verifyName` varchar(50) NOT NULL,
  `verifyKey` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `parametres`
--

DROP TABLE IF EXISTS `parametres`;
CREATE TABLE IF NOT EXISTS `parametres` (
  `param` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`param`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `parametres`
--

INSERT INTO `parametres` (`param`) VALUES
(1);

-- --------------------------------------------------------

--
-- Structure de la table `rayons`
--

DROP TABLE IF EXISTS `rayons`;
CREATE TABLE IF NOT EXISTS `rayons` (
  `idRayon` varchar(15) NOT NULL,
  `nomRayon` varchar(50) NOT NULL,
  `EtablissementCode` varchar(20) NOT NULL,
  PRIMARY KEY (`idRayon`),
  KEY `EtablissementCode` (`EtablissementCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `stock`
--

DROP TABLE IF EXISTS `stock`;
CREATE TABLE IF NOT EXISTS `stock` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codeEtab` varchar(20) NOT NULL,
  `codeArticle` varchar(20) NOT NULL,
  `PU_USD` decimal(65,2) NOT NULL DEFAULT '0.00',
  `PU_CDF` decimal(65,2) NOT NULL DEFAULT '0.00',
  `NbreParType` int(100) NOT NULL,
  `QtePce` int(100) NOT NULL,
  `QteType` decimal(65,2) NOT NULL DEFAULT '0.00',
  `QtePce_Crit` int(100) NOT NULL,
  `QteType_Crit` int(100) NOT NULL,
  `taux` int(11) NOT NULL,
  `dateJour` date NOT NULL,
  `userId` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `codeEtab` (`codeEtab`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `stockdepot`
--

DROP TABLE IF EXISTS `stockdepot`;
CREATE TABLE IF NOT EXISTS `stockdepot` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codeEtab` varchar(20) NOT NULL,
  `codeArticle` varchar(20) NOT NULL,
  `PU_USD` decimal(65,2) NOT NULL DEFAULT '0.00',
  `PU_CDF` decimal(65,2) NOT NULL DEFAULT '0.00',
  `NbreParType` int(100) NOT NULL,
  `QtePce` int(100) NOT NULL,
  `QteType` decimal(65,2) NOT NULL DEFAULT '0.00',
  `QtePce_Crit` int(100) NOT NULL,
  `QteType_Crit` int(100) NOT NULL,
  `taux` int(11) NOT NULL,
  `dateJour` date NOT NULL,
  `userId` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `codeEtab` (`codeEtab`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `supp`
--

DROP TABLE IF EXISTS `supp`;
CREATE TABLE IF NOT EXISTS `supp` (
  `no` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `supp`
--

INSERT INTO `supp` (`no`) VALUES
(1);

-- --------------------------------------------------------

--
-- Structure de la table `typearticle`
--

DROP TABLE IF EXISTS `typearticle`;
CREATE TABLE IF NOT EXISTS `typearticle` (
  `idType` int(11) NOT NULL AUTO_INCREMENT,
  `nomType` varchar(50) NOT NULL,
  PRIMARY KEY (`idType`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur`
--

DROP TABLE IF EXISTS `utilisateur`;
CREATE TABLE IF NOT EXISTS `utilisateur` (
  `id` int(100) NOT NULL AUTO_INCREMENT,
  `prenomUtilisateur` varchar(50) NOT NULL,
  `nomUtilisateur` varchar(50) NOT NULL,
  `loginUtilisateur` varchar(255) NOT NULL,
  `passUtilisateur` varchar(255) NOT NULL,
  `typeUtilisateur` varchar(15) NOT NULL,
  `etatCompte` bit(1) NOT NULL DEFAULT b'1',
  `dateCreation` date NOT NULL,
  `heureCreation` varchar(12) NOT NULL,
  `logged` varchar(12) NOT NULL,
  `etablissement` varchar(10) NOT NULL,
  `picture` blob NOT NULL,
  `idCode` varchar(15) NOT NULL,
  `AsConnected` tinyint(1) NOT NULL DEFAULT '0',
  `modifpassword` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `etablissement` (`etablissement`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `utilisateur`
--

INSERT INTO `utilisateur` (`id`, `prenomUtilisateur`, `nomUtilisateur`, `loginUtilisateur`, `passUtilisateur`, `typeUtilisateur`, `etatCompte`, `dateCreation`, `heureCreation`, `logged`, `etablissement`, `picture`, `idCode`, `AsConnected`, `modifpassword`) VALUES
(1, 'Daudet', 'KAMBALA', 'Daudet', '4a7d1ed414474e4033ac29ccb8653d9b', 'Administrateur', b'1', '2022-05-28', '11:20:08', '11:30:58', 'ETAB66700', 0x89504e470d0a1a0a0000000d49484452000000bc000000a908020000001e30c0d40000000467414d410000b18f0bfc6105000000097048597300000ec300000ec301c76fa8640000053949444154785eeddc4b6e1b41108361df2cdb9c33e7c941b2ce051201030c84df8fb6bafa51ac26f06d18d8126758dee6eddf5fb3d7309b35319b35319b35319b35319b35319b35311bfcf8f9fb43f8b1a330db0527f205fce209980f878378093eaa30e663e102bae1634b623e13860fc287d7c37c204c3e04bea218e6a360e9e1f07565301f051bcf806fac81f91c5877127c690dcc87c0b453e1ab0b603e01465d0005d43197873997410d69ccb561c8c5504617736d58713194d1c55c1826dc029544311786fdb6402551cc5561bc8d504c117349986d3bd493c35c1236db0ef5e4309784cdb6433d39ccf560b02450520b733d582b0994d4c25c0fd6ca033d853017839d52415521ccc560a7545055087331d829155415c25c09464a0885553057828512426115cc9560a18450580573255828211456c15c09164a0885553057828572426709cc65609bb4505b027319d8262dd496c05c06b6490bb5253097816dd2426d09cc65609bb4505b027319d8262dd496c05c06b6490bb5253097816dd2426d09cc65609bb4505b027319d8262dd496c05c06b6490bb5253097816dd2426d09cc95609e9cd0590273259827211456c15c09164a0885553057828512426115cc9560a184505805732558281bb415c25c0c764a0555853017839d52415521ccc560a7545055087331d829155415c25c0c764a0555853017839d52415521cc2561aded504f0e7349d86c3bd493c35c1236db0ef5e4305785d936423145cc8561bc5dd04a117361186f0b5412c55c1b265c0c657431d786151743195dcce561c86550431af30930e70228a08ef91018752a7c7501cce7c0b493e04b6b603e07d69de1edd79f077c6f01cc47c1c6c33dbee2ba9b62d7c37c88e715b1f410f717dd2add0df309deef87c9839e3f196adc0d73799fcd86e1bbe163e1ba57f5d3612eec3b83e1025e828ffa82fadd30d7f39d5b790f07f135fcee37e9de0d73311de702b88f1b7eac8fe8dd3097719d4bfe55244a02730d724b6815662e40ee626e2ab599d5899ecb4de2e299455def5afd622ef91f84594ea5737996f98998b5943c975bda47631652fb622e399f9159c5091773cbf6b0ccf91d752ecff23c357372c75ecc838fa6c7c91773b9dec0f697c09c53929795c7de57c19c90cfe53d1fcda7ae73f1c57c68e36b614ec5e7f2858d7f4ecc79f8629a76dd0d73061bff8614ad7f5dccdbf962faac7c69cc7bf95cba5d7f6c6b5e20f346cb9eb9b0b38ec61733c4f51a67bf49e6f5d63ce75166bf4fe6f57c2e93cc7bb1cc8bcdfe9b38dca477cbbc922f6681196f987981eb567c316bcc78cfccb3f956d61bfece99a7f2c56c34f0cd33cfe38bd94bef687c2edb0dfca3659ec4479381d2d10cbc710b1a3204f3583e976cb21f8d2f26a7f828cc03f962d20a4ec33c908f26b3c73addffdd24f3288f4e3e9accae81faee8639ee6ae38b492ef27fdb3207f95c54e43a1afc8be5e4a3b197f968ec653e1a7b998fc65e96e268ae063e1a15898ea6af84ad17d98bb95ba484ad17d98bb95ba484ad17d98bb95ba484ad17d98bb95ba484ad17d98bb95ba484ad17d98bb95ba484ad17d98bb95ba484ad17d98b3922d2c356ba97ea1b8b3922d2c3560a2ec51c11ac62cb0497628eb8ab74b7b105e21b3107c50bd96cf18d98e3e29d6c9e21eb30c7ddb582cd6cb851d3300f31aa9c0d347014e6510656b4b8b173300ff45c744857eb306305e6b1d0f8829fb119f0ce2ff8996ecc33a0baad8745829827c133d832186208e6d9f04836095efb58cc664dcc664dcc664dcc664dcc664dcc664dcc664dcc664dcc664dcc664dcc664dcc664dcc664dcc664dcc664dcc664dcc664dcc660d7fdffe03138766651a07ae380000000049454e44ae426082, 'ETAB66700', 0, 0);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `articles`
--
ALTER TABLE `articles`
  ADD CONSTRAINT `articles_ibfk_1` FOREIGN KEY (`EtablissementID`) REFERENCES `etablissement` (`codeEtab`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articles_ibfk_3` FOREIGN KEY (`categorieID`) REFERENCES `categorie` (`numCat`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articles_ibfk_4` FOREIGN KEY (`typeArticleID`) REFERENCES `typearticle` (`idType`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `articlesdepot`
--
ALTER TABLE `articlesdepot`
  ADD CONSTRAINT `articlesdepot_ibfk_1` FOREIGN KEY (`categorieID`) REFERENCES `categorie` (`numCat`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articlesdepot_ibfk_2` FOREIGN KEY (`typeArticleID`) REFERENCES `typearticle` (`idType`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articlesdepot_ibfk_4` FOREIGN KEY (`RayonID`) REFERENCES `rayons` (`idRayon`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articlesdepot_ibfk_5` FOREIGN KEY (`EtablissementID`) REFERENCES `etablissement` (`codeEtab`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `bon_entree_depot`
--
ALTER TABLE `bon_entree_depot`
  ADD CONSTRAINT `bon_entree_depot_ibfk_1` FOREIGN KEY (`EtablissementId`) REFERENCES `etablissement` (`codeEtab`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `bon_sortievers_magasin`
--
ALTER TABLE `bon_sortievers_magasin`
  ADD CONSTRAINT `bon_sortievers_magasin_ibfk_1` FOREIGN KEY (`destination`) REFERENCES `etablissement` (`codeEtab`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `bon_sortievers_magasin_ibfk_2` FOREIGN KEY (`provenance`) REFERENCES `etablissement` (`codeEtab`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `bon_transfert`
--
ALTER TABLE `bon_transfert`
  ADD CONSTRAINT `bon_transfert_ibfk_1` FOREIGN KEY (`destinationTransf`) REFERENCES `etablissement` (`codeEtab`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `bon_transfert_ibfk_2` FOREIGN KEY (`provenanceTransf`) REFERENCES `etablissement` (`codeEtab`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `client`
--
ALTER TABLE `client`
  ADD CONSTRAINT `client_ibfk_1` FOREIGN KEY (`caisseID`) REFERENCES `caisse` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `client_ibfk_3` FOREIGN KEY (`codeEtabID`) REFERENCES `etablissement` (`codeEtab`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `declassement`
--
ALTER TABLE `declassement`
  ADD CONSTRAINT `declassement_ibfk_1` FOREIGN KEY (`categorieID`) REFERENCES `categorie` (`numCat`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `declassement_ibfk_2` FOREIGN KEY (`codeArticle`) REFERENCES `articles` (`IdArticles`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `declassement_ibfk_3` FOREIGN KEY (`codeEtab`) REFERENCES `etablissement` (`codeEtab`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `declassement_ibfk_4` FOREIGN KEY (`typeArticleID`) REFERENCES `typearticle` (`idType`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `declassementdepot`
--
ALTER TABLE `declassementdepot`
  ADD CONSTRAINT `declassementdepot_ibfk_1` FOREIGN KEY (`typeArticleID`) REFERENCES `typearticle` (`idType`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `declassementdepot_ibfk_2` FOREIGN KEY (`codeArticle`) REFERENCES `articlesdepot` (`IdArticles`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `declassementdepot_ibfk_3` FOREIGN KEY (`codeEtab`) REFERENCES `etablissement` (`codeEtab`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `declassementdepot_ibfk_4` FOREIGN KEY (`categorieID`) REFERENCES `categorie` (`numCat`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `detailbon_transfert`
--
ALTER TABLE `detailbon_transfert`
  ADD CONSTRAINT `detailbon_transfert_ibfk_1` FOREIGN KEY (`typeArticleID`) REFERENCES `typearticle` (`idType`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `detailbon_transfert_ibfk_2` FOREIGN KEY (`numBon_Transf`) REFERENCES `bon_transfert` (`numBon_Transfert`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `detailbon_transfert_ibfk_3` FOREIGN KEY (`provenanceBT`) REFERENCES `etablissement` (`codeEtab`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `detailbon_transfert_ibfk_4` FOREIGN KEY (`destinationTransf`) REFERENCES `etablissement` (`codeEtab`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `detailsbe_depot`
--
ALTER TABLE `detailsbe_depot`
  ADD CONSTRAINT `detailsbe_depot_ibfk_1` FOREIGN KEY (`ArticleID`) REFERENCES `articlesdepot` (`IdArticles`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `detailsbe_depot_ibfk_2` FOREIGN KEY (`etablissementID`) REFERENCES `etablissement` (`codeEtab`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `detailsbe_depot_ibfk_3` FOREIGN KEY (`typeId`) REFERENCES `typearticle` (`idType`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `detailsbsvers_magasin`
--
ALTER TABLE `detailsbsvers_magasin`
  ADD CONSTRAINT `detailsbsvers_magasin_ibfk_1` FOREIGN KEY (`IDArticle`) REFERENCES `articlesdepot` (`IdArticles`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `detailsbsvers_magasin_ibfk_2` FOREIGN KEY (`typeId`) REFERENCES `typearticle` (`idType`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `detailsbsvers_magasin_ibfk_3` FOREIGN KEY (`numBS`) REFERENCES `bon_sortievers_magasin` (`numBS_MAG`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `facture`
--
ALTER TABLE `facture`
  ADD CONSTRAINT `facture_ibfk_1` FOREIGN KEY (`ClientID`) REFERENCES `client` (`idClient`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `facture_ibfk_2` FOREIGN KEY (`ArticleID`) REFERENCES `articles` (`IdArticles`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `facture_ibfk_3` FOREIGN KEY (`typeArticleID`) REFERENCES `typearticle` (`idType`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `facture_ibfk_4` FOREIGN KEY (`CaisseID`) REFERENCES `caisse` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `facture_ibfk_5` FOREIGN KEY (`DeviseID`) REFERENCES `devise` (`idDevise`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `facture_ibfk_6` FOREIGN KEY (`EtablissementID`) REFERENCES `etablissement` (`codeEtab`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `fstk`
--
ALTER TABLE `fstk`
  ADD CONSTRAINT `fstk_ibfk_1` FOREIGN KEY (`codeEtab`) REFERENCES `etablissement` (`codeEtab`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `fstkdepot`
--
ALTER TABLE `fstkdepot`
  ADD CONSTRAINT `fstkdepot_ibfk_1` FOREIGN KEY (`codeEtab`) REFERENCES `etablissement` (`codeEtab`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `stock`
--
ALTER TABLE `stock`
  ADD CONSTRAINT `stock_ibfk_1` FOREIGN KEY (`codeEtab`) REFERENCES `etablissement` (`codeEtab`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `stockdepot`
--
ALTER TABLE `stockdepot`
  ADD CONSTRAINT `stockdepot_ibfk_1` FOREIGN KEY (`codeEtab`) REFERENCES `etablissement` (`codeEtab`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `utilisateur`
--
ALTER TABLE `utilisateur`
  ADD CONSTRAINT `utilisateur_ibfk_1` FOREIGN KEY (`etablissement`) REFERENCES `etablissement` (`codeEtab`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
