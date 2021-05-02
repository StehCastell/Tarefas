CREATE TABLE `tarefas`.`tarefa` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `titulo` VARCHAR(45) NOT NULL,
  `descricao` VARCHAR(45) NOT NULL,
  `observacao` VARCHAR(45) NULL,
  `realizador` VARCHAR(45) NOT NULL,
  `tempoestimado` DOUBLE NOT NULL,
  `datahorainicio` DATETIME NOT NULL,
  `datahorafim` DATETIME NOT NULL,
  `status` INT NOT NULL,
  PRIMARY KEY (`id`));