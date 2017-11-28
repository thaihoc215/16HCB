/*
Navicat MySQL Data Transfer

Source Server         : mysql-local
Source Server Version : 50524
Source Host           : 127.0.0.1:3306
Source Database       : ts2015

Target Server Type    : MYSQL
Target Server Version : 50524
File Encoding         : 65001

Date: 2017-10-26 19:44:45
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for products
-- ----------------------------
/*DROP TABLE IF EXISTS `products`;*/
create database ts2015;
use ts2015;
CREATE TABLE `products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8 NOT NULL,
  `code` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `imagePath` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `price` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of products
-- ----------------------------
INSERT INTO `products` VALUES ('1', '3D Camera', 'CAM01', 'logo.jpg', '1500');
INSERT INTO `products` VALUES ('2', 'External Hard Drive', 'USB02', 'logo.jpg', '800');
INSERT INTO `products` VALUES ('3', 'Wrist Watch', 'WATCH01', 'logo.jpg', '300');
