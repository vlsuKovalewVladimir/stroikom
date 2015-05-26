-- MySQL Script generated by MySQL Workbench
-- 05/20/15 15:19:29
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema db_stroikom
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `db_stroikom` ;

-- -----------------------------------------------------
-- Schema db_stroikom
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `db_stroikom` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `db_stroikom` ;

-- -----------------------------------------------------
-- Table `db_stroikom`.`relationship`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_stroikom`.`relationship` ;

CREATE TABLE IF NOT EXISTS `db_stroikom`.`relationship` (
  `id_relationship` INT NOT NULL AUTO_INCREMENT COMMENT 'отношение (клиен или поставщик)',
  `relationship` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_relationship`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_stroikom`.`partner`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_stroikom`.`partner` ;

CREATE TABLE IF NOT EXISTS `db_stroikom`.`partner` (
  `id_partner` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `adress` VARCHAR(255) NOT NULL,
  `data` DATE NOT NULL,
  `phone` VARCHAR(11) NOT NULL,
  `relationship_id` INT NOT NULL,
  `inn` VARCHAR(12) NOT NULL,
  `bik` VARCHAR(9) NULL,
  `director` VARCHAR(150) NOT NULL,
  PRIMARY KEY (`id_partner`),
  INDEX `fk_partner_relationship_idx` (`relationship_id` ASC),
  CONSTRAINT `fk_partner_relationship`
    FOREIGN KEY (`relationship_id`)
    REFERENCES `db_stroikom`.`relationship` (`id_relationship`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_stroikom`.`goods`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_stroikom`.`goods` ;

CREATE TABLE IF NOT EXISTS `db_stroikom`.`goods` (
  `id_goods` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `article` VARCHAR(45) NULL,
  `description` VARCHAR(255) NULL,
  PRIMARY KEY (`id_goods`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_stroikom`.`module`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_stroikom`.`module` ;

CREATE TABLE IF NOT EXISTS `db_stroikom`.`module` (
  `id_module` INT NOT NULL AUTO_INCREMENT,
  `little_module` VARCHAR(10) NOT NULL,
  `full_module` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_module`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_stroikom`.`status`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_stroikom`.`status` ;

CREATE TABLE IF NOT EXISTS `db_stroikom`.`status` (
  `id_status` INT NOT NULL AUTO_INCREMENT,
  `status` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_status`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_stroikom`.`storage`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_stroikom`.`storage` ;

CREATE TABLE IF NOT EXISTS `db_stroikom`.`storage` (
  `id_storage` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(100) NOT NULL,
  `ardess` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`id_storage`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_stroikom`.`post`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_stroikom`.`post` ;

CREATE TABLE IF NOT EXISTS `db_stroikom`.`post` (
  `id_post` INT NOT NULL AUTO_INCREMENT,
  `post` VARCHAR(45) NOT NULL,
  `discription` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`id_post`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_stroikom`.`personnel`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_stroikom`.`personnel` ;

CREATE TABLE IF NOT EXISTS `db_stroikom`.`personnel` (
  `id_personnel` INT NOT NULL AUTO_INCREMENT,
  `lastname` VARCHAR(100) NOT NULL,
  `firstname` VARCHAR(100) NOT NULL,
  `soname` VARCHAR(100) NOT NULL,
  `dtr` DATE NOT NULL,
  `gender` TINYINT(1) NOT NULL COMMENT 'пол(true=man)',
  `adress` VARCHAR(255) NOT NULL,
  `phone` VARCHAR(45) NULL,
  `post_id` INT NOT NULL,
  `password` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_personnel`),
  INDEX `fk_personnel_post1_idx` (`post_id` ASC),
  CONSTRAINT `fk_personnel_post1`
    FOREIGN KEY (`post_id`)
    REFERENCES `db_stroikom`.`post` (`id_post`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_stroikom`.`order_or_sale`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_stroikom`.`order_or_sale` ;

CREATE TABLE IF NOT EXISTS `db_stroikom`.`order_or_sale` (
  `id_order_or_sale` INT NOT NULL AUTO_INCREMENT,
  `date_order_or_sale` DATE NOT NULL,
  `status_id` INT NOT NULL,
  `partner_id` INT NOT NULL,
  `period_date` DATE NOT NULL COMMENT 'Срок выполнения',
  `storage_id` INT NOT NULL,
  `is_order` TINYINT(1) NOT NULL DEFAULT 1 COMMENT 'Если true то поставка иначе продажа\n0-false \n1-true',
  `personnel_id` INT NOT NULL,
  `comment` VARCHAR(255) NULL,
  PRIMARY KEY (`id_order_or_sale`),
  INDEX `fk_order_status1_idx` (`status_id` ASC),
  INDEX `fk_order_partner1_idx` (`partner_id` ASC),
  INDEX `fk_order_storage1_idx` (`storage_id` ASC),
  INDEX `fk_order_and_sale_personnel1_idx` (`personnel_id` ASC),
  CONSTRAINT `fk_order_status1`
    FOREIGN KEY (`status_id`)
    REFERENCES `db_stroikom`.`status` (`id_status`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_partner1`
    FOREIGN KEY (`partner_id`)
    REFERENCES `db_stroikom`.`partner` (`id_partner`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_storage1`
    FOREIGN KEY (`storage_id`)
    REFERENCES `db_stroikom`.`storage` (`id_storage`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_and_sale_personnel1`
    FOREIGN KEY (`personnel_id`)
    REFERENCES `db_stroikom`.`personnel` (`id_personnel`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_stroikom`.`order_storage_sale_goods`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_stroikom`.`order_storage_sale_goods` ;

CREATE TABLE IF NOT EXISTS `db_stroikom`.`order_storage_sale_goods` (
  `id_goods` INT NOT NULL AUTO_INCREMENT,
  `goods_id` INT NOT NULL,
  `count` INT NOT NULL,
  `module_id` INT NOT NULL,
  `price_of_unit` DOUBLE NOT NULL COMMENT 'Цена за одну шт',
  `comment` VARCHAR(255) NULL,
  `order_storage_sale` INT NOT NULL COMMENT '1 - поставка\n2 - склад\n3 - отгрузка',
  `order_or_sale_id` INT NOT NULL,
  `is_delete` TINYINT(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id_goods`),
  INDEX `fk_order_goods_goods1_idx` (`goods_id` ASC),
  INDEX `fk_order_goods_module1_idx` (`module_id` ASC),
  INDEX `fk_order_storage_sale_goods_order_or_sale1_idx` (`order_or_sale_id` ASC),
  CONSTRAINT `fk_order_goods_goods1`
    FOREIGN KEY (`goods_id`)
    REFERENCES `db_stroikom`.`goods` (`id_goods`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_goods_module1`
    FOREIGN KEY (`module_id`)
    REFERENCES `db_stroikom`.`module` (`id_module`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_storage_sale_goods_order_or_sale1`
    FOREIGN KEY (`order_or_sale_id`)
    REFERENCES `db_stroikom`.`order_or_sale` (`id_order_or_sale`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_stroikom`.`operation`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_stroikom`.`operation` ;

CREATE TABLE IF NOT EXISTS `db_stroikom`.`operation` (
  `id_operation` INT NOT NULL AUTO_INCREMENT,
  `operation_vid` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`id_operation`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_stroikom`.`cash`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_stroikom`.`cash` ;

CREATE TABLE IF NOT EXISTS `db_stroikom`.`cash` (
  `id_cash` INT NOT NULL AUTO_INCREMENT,
  `discription` VARCHAR(255) NOT NULL,
  `date` DATETIME NOT NULL,
  `sum` DOUBLE NOT NULL,
  `operation_id` INT NOT NULL,
  `dogovor` VARCHAR(255) NOT NULL,
  `order_or_sale_id` INT NOT NULL,
  PRIMARY KEY (`id_cash`),
  INDEX `fk_cash_operation1_idx` (`operation_id` ASC),
  INDEX `fk_cash_order_or_sale1_idx` (`order_or_sale_id` ASC),
  CONSTRAINT `fk_cash_operation1`
    FOREIGN KEY (`operation_id`)
    REFERENCES `db_stroikom`.`operation` (`id_operation`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_cash_order_or_sale1`
    FOREIGN KEY (`order_or_sale_id`)
    REFERENCES `db_stroikom`.`order_or_sale` (`id_order_or_sale`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_stroikom`.`task`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `db_stroikom`.`task` ;

CREATE TABLE IF NOT EXISTS `db_stroikom`.`task` (
  `id_task` INT NOT NULL AUTO_INCREMENT,
  `task` VARCHAR(255) NOT NULL,
  `start_date` DATETIME NOT NULL,
  `time` INT NOT NULL COMMENT 'time храниться в часах!',
  `performance` TINYINT(1) NOT NULL,
  `personnel_id` INT NOT NULL,
  PRIMARY KEY (`id_task`),
  INDEX `fk_task_personnel1_idx` (`personnel_id` ASC),
  CONSTRAINT `fk_task_personnel1`
    FOREIGN KEY (`personnel_id`)
    REFERENCES `db_stroikom`.`personnel` (`id_personnel`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table `db_stroikom`.`relationship`
-- -----------------------------------------------------
START TRANSACTION;
USE `db_stroikom`;
INSERT INTO `db_stroikom`.`relationship` (`id_relationship`, `relationship`) VALUES (1, 'Клиент');
INSERT INTO `db_stroikom`.`relationship` (`id_relationship`, `relationship`) VALUES (2, 'Поставщик');

COMMIT;


-- -----------------------------------------------------
-- Data for table `db_stroikom`.`partner`
-- -----------------------------------------------------
START TRANSACTION;
USE `db_stroikom`;
INSERT INTO `db_stroikom`.`partner` (`id_partner`, `name`, `adress`, `data`, `phone`, `relationship_id`, `inn`, `bik`, `director`) VALUES (1, 'ООО Пальмира', 'Владимир, ул Северная д 45', '2013.10.15', '89106523365', 2, '123456789123', '123456789', 'Иванов А.С.');
INSERT INTO `db_stroikom`.`partner` (`id_partner`, `name`, `adress`, `data`, `phone`, `relationship_id`, `inn`, `bik`, `director`) VALUES (2, 'ИП Кузин', 'Владимир, ул Строителей дом 45', '2010.12.12', '89046548642', 2, '645124356194', '642531214', 'Кузин А.С.');
INSERT INTO `db_stroikom`.`partner` (`id_partner`, `name`, `adress`, `data`, `phone`, `relationship_id`, `inn`, `bik`, `director`) VALUES (3, 'ОАО РДЖ', 'Владимир, ул Спасская дом 35', '2010.01.01', '86542619546', 1, '845167913256', '456453213', 'Васин П.М.');
INSERT INTO `db_stroikom`.`partner` (`id_partner`, `name`, `adress`, `data`, `phone`, `relationship_id`, `inn`, `bik`, `director`) VALUES (4, 'Ассоль ООО', 'Суздаль, ул Муромская дом 17', '2010.03.03', '86451231346', 2, '456543453453', '456453424', 'Петров П.Н.');
INSERT INTO `db_stroikom`.`partner` (`id_partner`, `name`, `adress`, `data`, `phone`, `relationship_id`, `inn`, `bik`, `director`) VALUES (5, 'ООО Марио', 'Муром, ул Владимирская д 126', '2005.06.01', '89654213124', 1, '564561236989', '454565412', 'Ковалев В.Е.');
INSERT INTO `db_stroikom`.`partner` (`id_partner`, `name`, `adress`, `data`, `phone`, `relationship_id`, `inn`, `bik`, `director`) VALUES (6, 'МОНОЛИТ', 'Москва, ул Сибиряка д 23', '1990.04.18', '86495312534', 1, '465463234655', '464545622', 'Власов П.С.');

COMMIT;


-- -----------------------------------------------------
-- Data for table `db_stroikom`.`goods`
-- -----------------------------------------------------
START TRANSACTION;
USE `db_stroikom`;
INSERT INTO `db_stroikom`.`goods` (`id_goods`, `name`, `article`, `description`) VALUES (1, 'Гвозьди', 'Г-228', 'Гвозьди обыкновенные');
INSERT INTO `db_stroikom`.`goods` (`id_goods`, `name`, `article`, `description`) VALUES (2, 'Доски', 'Д-321', 'Из дерева');
INSERT INTO `db_stroikom`.`goods` (`id_goods`, `name`, `article`, `description`) VALUES (3, 'Цемент-А35', 'АР-435', 'Особо прочный');
INSERT INTO `db_stroikom`.`goods` (`id_goods`, `name`, `article`, `description`) VALUES (4, 'Шурупы', 'УК-56', 'Мелкие');
INSERT INTO `db_stroikom`.`goods` (`id_goods`, `name`, `article`, `description`) VALUES (5, 'Дюпеля', 'МНК-847', 'Красные');
INSERT INTO `db_stroikom`.`goods` (`id_goods`, `name`, `article`, `description`) VALUES (6, 'Молоток', 'ПР-657', 'Цельный');
INSERT INTO `db_stroikom`.`goods` (`id_goods`, `name`, `article`, `description`) VALUES (7, 'Плиточный клей(водостойкий)', 'УМН-21', 'Марки \"STAR\"');
INSERT INTO `db_stroikom`.`goods` (`id_goods`, `name`, `article`, `description`) VALUES (8, 'Краска', 'УН-45', 'Синего цвета');
INSERT INTO `db_stroikom`.`goods` (`id_goods`, `name`, `article`, `description`) VALUES (9, 'Кисточки', 'МУ-32', 'Тоненькие');
INSERT INTO `db_stroikom`.`goods` (`id_goods`, `name`, `article`, `description`) VALUES (10, 'Профлист-21', 'ТР-34', 'Для теплиц, бань, сараев');

COMMIT;


-- -----------------------------------------------------
-- Data for table `db_stroikom`.`module`
-- -----------------------------------------------------
START TRANSACTION;
USE `db_stroikom`;
INSERT INTO `db_stroikom`.`module` (`id_module`, `little_module`, `full_module`) VALUES (1, 'кг', 'килограмм');
INSERT INTO `db_stroikom`.`module` (`id_module`, `little_module`, `full_module`) VALUES (2, 'шт', 'штук');
INSERT INTO `db_stroikom`.`module` (`id_module`, `little_module`, `full_module`) VALUES (3, 'т', 'тонн');
INSERT INTO `db_stroikom`.`module` (`id_module`, `little_module`, `full_module`) VALUES (4, 'л', 'литр');
INSERT INTO `db_stroikom`.`module` (`id_module`, `little_module`, `full_module`) VALUES (5, 'уп', 'упаковка');
INSERT INTO `db_stroikom`.`module` (`id_module`, `little_module`, `full_module`) VALUES (6, 'куб', 'кубы');

COMMIT;


-- -----------------------------------------------------
-- Data for table `db_stroikom`.`status`
-- -----------------------------------------------------
START TRANSACTION;
USE `db_stroikom`;
INSERT INTO `db_stroikom`.`status` (`id_status`, `status`) VALUES (1, 'Заказан у поставщика');
INSERT INTO `db_stroikom`.`status` (`id_status`, `status`) VALUES (2, 'Транспортировка на склад');
INSERT INTO `db_stroikom`.`status` (`id_status`, `status`) VALUES (3, 'Товар на складе');
INSERT INTO `db_stroikom`.`status` (`id_status`, `status`) VALUES (4, 'Товар куплен');
INSERT INTO `db_stroikom`.`status` (`id_status`, `status`) VALUES (5, 'Товар выдан');

COMMIT;


-- -----------------------------------------------------
-- Data for table `db_stroikom`.`storage`
-- -----------------------------------------------------
START TRANSACTION;
USE `db_stroikom`;
INSERT INTO `db_stroikom`.`storage` (`id_storage`, `name`, `ardess`) VALUES (1, 'Центральный склад', 'Владимир, ул. Горького д 116-117');
INSERT INTO `db_stroikom`.`storage` (`id_storage`, `name`, `ardess`) VALUES (2, 'Северный склад', 'Владимир, ул. Северная д 8');
INSERT INTO `db_stroikom`.`storage` (`id_storage`, `name`, `ardess`) VALUES (3, 'Южный склад', 'Владимир, ул Мостостроевская д 3');

COMMIT;


-- -----------------------------------------------------
-- Data for table `db_stroikom`.`post`
-- -----------------------------------------------------
START TRANSACTION;
USE `db_stroikom`;
INSERT INTO `db_stroikom`.`post` (`id_post`, `post`, `discription`) VALUES (1, 'Директор', 'full ');
INSERT INTO `db_stroikom`.`post` (`id_post`, `post`, `discription`) VALUES (2, 'Логист', 'кроме пользователей');
INSERT INTO `db_stroikom`.`post` (`id_post`, `post`, `discription`) VALUES (3, 'Кладовщик', 'изменение статуса товара в запупках, склад и продажи ');

COMMIT;


-- -----------------------------------------------------
-- Data for table `db_stroikom`.`personnel`
-- -----------------------------------------------------
START TRANSACTION;
USE `db_stroikom`;
INSERT INTO `db_stroikom`.`personnel` (`id_personnel`, `lastname`, `firstname`, `soname`, `dtr`, `gender`, `adress`, `phone`, `post_id`, `password`) VALUES (1, 'Иванов', 'Иван', 'Иванович', '2003.05.05', 1, 'Муром, ул Маяковского д 7 кв 7', '256245', 1, '1234');
INSERT INTO `db_stroikom`.`personnel` (`id_personnel`, `lastname`, `firstname`, `soname`, `dtr`, `gender`, `adress`, `phone`, `post_id`, `password`) VALUES (2, 'Васильева', 'Маргарита', 'Павловна', '2004.04.04', 0, 'Москва, ул Васина д 5 стр 8', '456456', 2, '1234');
INSERT INTO `db_stroikom`.`personnel` (`id_personnel`, `lastname`, `firstname`, `soname`, `dtr`, `gender`, `adress`, `phone`, `post_id`, `password`) VALUES (3, 'Кузин', 'Михаил', 'Михайлович', '2005.06.06', 1, 'Владимир, ул Северная д 6 кв 2', '125646', 3, '1234');
INSERT INTO `db_stroikom`.`personnel` (`id_personnel`, `lastname`, `firstname`, `soname`, `dtr`, `gender`, `adress`, `phone`, `post_id`, `password`) VALUES (4, 'Мулина', 'Раиса', 'Петровна', '1992.07.21', 0, 'Суздаль, ул Ленина д 5', '456248', 2, '1234');
INSERT INTO `db_stroikom`.`personnel` (`id_personnel`, `lastname`, `firstname`, `soname`, `dtr`, `gender`, `adress`, `phone`, `post_id`, `password`) VALUES (5, 'Василец', 'Андрей', 'Петрович', '2009.09.09', 1, 'Владимир, ул Студенческая д 5 кв 12', '125645', 3, '1234');

COMMIT;


-- -----------------------------------------------------
-- Data for table `db_stroikom`.`order_or_sale`
-- -----------------------------------------------------
START TRANSACTION;
USE `db_stroikom`;
INSERT INTO `db_stroikom`.`order_or_sale` (`id_order_or_sale`, `date_order_or_sale`, `status_id`, `partner_id`, `period_date`, `storage_id`, `is_order`, `personnel_id`, `comment`) VALUES (1, '2015.05.19', 1, 1, '2015.05.23', 1, 1, 1, 'Поставки');
INSERT INTO `db_stroikom`.`order_or_sale` (`id_order_or_sale`, `date_order_or_sale`, `status_id`, `partner_id`, `period_date`, `storage_id`, `is_order`, `personnel_id`, `comment`) VALUES (2, '2015.05.18', 2, 2, '2015.06.01', 2, 1, 2, 'Поставки');
INSERT INTO `db_stroikom`.`order_or_sale` (`id_order_or_sale`, `date_order_or_sale`, `status_id`, `partner_id`, `period_date`, `storage_id`, `is_order`, `personnel_id`, `comment`) VALUES (3, '2015.04.30', 3, 4, '2015.05.18', 2, 1, 4, 'на складе');
INSERT INTO `db_stroikom`.`order_or_sale` (`id_order_or_sale`, `date_order_or_sale`, `status_id`, `partner_id`, `period_date`, `storage_id`, `is_order`, `personnel_id`, `comment`) VALUES (4, '2015.01.01', 1, 2, '2015.02.02', 1, 1, 1, 'Поставки');
INSERT INTO `db_stroikom`.`order_or_sale` (`id_order_or_sale`, `date_order_or_sale`, `status_id`, `partner_id`, `period_date`, `storage_id`, `is_order`, `personnel_id`, `comment`) VALUES (5, '2015.03.03', 2, 2, '2015.04.04', 2, 1, 2, 'Поставки');
INSERT INTO `db_stroikom`.`order_or_sale` (`id_order_or_sale`, `date_order_or_sale`, `status_id`, `partner_id`, `period_date`, `storage_id`, `is_order`, `personnel_id`, `comment`) VALUES (6, '2014.04.05', 4, 3, '2014.05.05', 3, 0, 4, 'Продажа');
INSERT INTO `db_stroikom`.`order_or_sale` (`id_order_or_sale`, `date_order_or_sale`, `status_id`, `partner_id`, `period_date`, `storage_id`, `is_order`, `personnel_id`, `comment`) VALUES (7, '2015.06.06', 5, 5, '2015.07.07', 3, 0, 2, 'Продажа');

COMMIT;


-- -----------------------------------------------------
-- Data for table `db_stroikom`.`order_storage_sale_goods`
-- -----------------------------------------------------
START TRANSACTION;
USE `db_stroikom`;
INSERT INTO `db_stroikom`.`order_storage_sale_goods` (`id_goods`, `goods_id`, `count`, `module_id`, `price_of_unit`, `comment`, `order_storage_sale`, `order_or_sale_id`, `is_delete`) VALUES (1, 7, 50, 5, 290, NULL, 1, 1, DEFAULT);
INSERT INTO `db_stroikom`.`order_storage_sale_goods` (`id_goods`, `goods_id`, `count`, `module_id`, `price_of_unit`, `comment`, `order_storage_sale`, `order_or_sale_id`, `is_delete`) VALUES (2, 8, 10, 1, 110, NULL, 1, 2, DEFAULT);
INSERT INTO `db_stroikom`.`order_storage_sale_goods` (`id_goods`, `goods_id`, `count`, `module_id`, `price_of_unit`, `comment`, `order_storage_sale`, `order_or_sale_id`, `is_delete`) VALUES (3, 4, 10, 1, 100, NULL, 1, 3, DEFAULT);
INSERT INTO `db_stroikom`.`order_storage_sale_goods` (`id_goods`, `goods_id`, `count`, `module_id`, `price_of_unit`, `comment`, `order_storage_sale`, `order_or_sale_id`, `is_delete`) VALUES (4, 5, 50, 1, 120, NULL, 1, 3, DEFAULT);
INSERT INTO `db_stroikom`.`order_storage_sale_goods` (`id_goods`, `goods_id`, `count`, `module_id`, `price_of_unit`, `comment`, `order_storage_sale`, `order_or_sale_id`, `is_delete`) VALUES (5, 6, 100, 2, 250, NULL, 1, 3, DEFAULT);
INSERT INTO `db_stroikom`.`order_storage_sale_goods` (`id_goods`, `goods_id`, `count`, `module_id`, `price_of_unit`, `comment`, `order_storage_sale`, `order_or_sale_id`, `is_delete`) VALUES (6, 9, 1000, 2, 40, NULL, 1, 2, DEFAULT);
INSERT INTO `db_stroikom`.`order_storage_sale_goods` (`id_goods`, `goods_id`, `count`, `module_id`, `price_of_unit`, `comment`, `order_storage_sale`, `order_or_sale_id`, `is_delete`) VALUES (7, 10, 50, 2, 600, NULL, 1, 2, DEFAULT);
INSERT INTO `db_stroikom`.`order_storage_sale_goods` (`id_goods`, `goods_id`, `count`, `module_id`, `price_of_unit`, `comment`, `order_storage_sale`, `order_or_sale_id`, `is_delete`) VALUES (8, 4, 0, 1, 100, NULL, 2, 3, 1);
INSERT INTO `db_stroikom`.`order_storage_sale_goods` (`id_goods`, `goods_id`, `count`, `module_id`, `price_of_unit`, `comment`, `order_storage_sale`, `order_or_sale_id`, `is_delete`) VALUES (9, 5, 20, 1, 120, NULL, 2, 3, DEFAULT);
INSERT INTO `db_stroikom`.`order_storage_sale_goods` (`id_goods`, `goods_id`, `count`, `module_id`, `price_of_unit`, `comment`, `order_storage_sale`, `order_or_sale_id`, `is_delete`) VALUES (10, 6, 50, 2, 250, NULL, 2, 3, DEFAULT);
INSERT INTO `db_stroikom`.`order_storage_sale_goods` (`id_goods`, `goods_id`, `count`, `module_id`, `price_of_unit`, `comment`, `order_storage_sale`, `order_or_sale_id`, `is_delete`) VALUES (11, 4, 10, 1, 100, NULL, 3, 7, DEFAULT);
INSERT INTO `db_stroikom`.`order_storage_sale_goods` (`id_goods`, `goods_id`, `count`, `module_id`, `price_of_unit`, `comment`, `order_storage_sale`, `order_or_sale_id`, `is_delete`) VALUES (12, 5, 20, 1, 120, NULL, 3, 7, DEFAULT);
INSERT INTO `db_stroikom`.`order_storage_sale_goods` (`id_goods`, `goods_id`, `count`, `module_id`, `price_of_unit`, `comment`, `order_storage_sale`, `order_or_sale_id`, `is_delete`) VALUES (13, 6, 50, 2, 250, NULL, 3, 6, DEFAULT);
INSERT INTO `db_stroikom`.`order_storage_sale_goods` (`id_goods`, `goods_id`, `count`, `module_id`, `price_of_unit`, `comment`, `order_storage_sale`, `order_or_sale_id`, `is_delete`) VALUES (14, 1, 30, 1, 140, NULL, 1, 4, DEFAULT);
INSERT INTO `db_stroikom`.`order_storage_sale_goods` (`id_goods`, `goods_id`, `count`, `module_id`, `price_of_unit`, `comment`, `order_storage_sale`, `order_or_sale_id`, `is_delete`) VALUES (15, 2, 5, 6, 500, NULL, 1, 5, DEFAULT);
INSERT INTO `db_stroikom`.`order_storage_sale_goods` (`id_goods`, `goods_id`, `count`, `module_id`, `price_of_unit`, `comment`, `order_storage_sale`, `order_or_sale_id`, `is_delete`) VALUES (16, 3, 30, 5, 260, NULL, 1, 5, DEFAULT);

COMMIT;


-- -----------------------------------------------------
-- Data for table `db_stroikom`.`operation`
-- -----------------------------------------------------
START TRANSACTION;
USE `db_stroikom`;
INSERT INTO `db_stroikom`.`operation` (`id_operation`, `operation_vid`) VALUES (1, 'Поступление ДС из банка');
INSERT INTO `db_stroikom`.`operation` (`id_operation`, `operation_vid`) VALUES (2, 'Оплата покупателя');
INSERT INTO `db_stroikom`.`operation` (`id_operation`, `operation_vid`) VALUES (3, 'Прочие доходы');

COMMIT;


-- -----------------------------------------------------
-- Data for table `db_stroikom`.`cash`
-- -----------------------------------------------------
START TRANSACTION;
USE `db_stroikom`;
INSERT INTO `db_stroikom`.`cash` (`id_cash`, `discription`, `date`, `sum`, `operation_id`, `dogovor`, `order_or_sale_id`) VALUES (1, 'Заказ клиента', '2015.05.19', 200, 1, 'Договор купли продажи от 21.04.25', 1);
INSERT INTO `db_stroikom`.`cash` (`id_cash`, `discription`, `date`, `sum`, `operation_id`, `dogovor`, `order_or_sale_id`) VALUES (2, 'Вознаграждени от партнера', '2015.05.18', 1500, 2, 'Договор о поставках агента', 2);

COMMIT;


-- -----------------------------------------------------
-- Data for table `db_stroikom`.`task`
-- -----------------------------------------------------
START TRANSACTION;
USE `db_stroikom`;
INSERT INTO `db_stroikom`.`task` (`id_task`, `task`, `start_date`, `time`, `performance`, `personnel_id`) VALUES (1, 'Купить молоко', '2001.04.05', 30, 0, 1);
INSERT INTO `db_stroikom`.`task` (`id_task`, `task`, `start_date`, `time`, `performance`, `personnel_id`) VALUES (2, 'Выкинуть мусор', '2010.05.05', 5, 1, 2);
INSERT INTO `db_stroikom`.`task` (`id_task`, `task`, `start_date`, `time`, `performance`, `personnel_id`) VALUES (3, 'Купить бумагу', '2015.05.19', 3, 0, 1);
INSERT INTO `db_stroikom`.`task` (`id_task`, `task`, `start_date`, `time`, `performance`, `personnel_id`) VALUES (DEFAULT, 'Написать отчет по продажам', '2015.01.01', 15, 0, 3);
INSERT INTO `db_stroikom`.`task` (`id_task`, `task`, `start_date`, `time`, `performance`, `personnel_id`) VALUES (DEFAULT, 'Закупить товатов', '2015.03.03', 60, 1, 2);

COMMIT;
