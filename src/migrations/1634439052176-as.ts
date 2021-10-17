import {MigrationInterface, QueryRunner} from "typeorm";

export class as1634439052176 implements MigrationInterface {
    name = 'as1634439052176'

    public async up(queryRunner: QueryRunner): Promise<void> {
        await queryRunner.query(`CREATE TABLE \`user\` (\`id\` char(36) NOT NULL, \`isDeleted\` tinyint NOT NULL, \`name\` varchar(255) NOT NULL, \`surname\` varchar(255) NOT NULL, \`password\` varchar(255) NOT NULL, \`phone\` varchar(255) NOT NULL, \`email\` varchar(255) NOT NULL, PRIMARY KEY (\`id\`, \`isDeleted\`)) ENGINE=InnoDB`);
        await queryRunner.query(`CREATE TABLE \`address\` (\`id\` char(36) NOT NULL, \`isDeleted\` tinyint NOT NULL, \`number\` varchar(255) NOT NULL, \`postalCode\` int NOT NULL, \`country\` varchar(255) NOT NULL, \`state\` varchar(255) NOT NULL, \`complement\` varchar(255) NOT NULL, \`district\` varchar(255) NOT NULL, \`street\` varchar(255) NOT NULL, \`userId\` char(36) NULL, \`userIsDeleted\` tinyint NULL, PRIMARY KEY (\`id\`, \`isDeleted\`)) ENGINE=InnoDB`);
        await queryRunner.query(`ALTER TABLE \`address\` ADD CONSTRAINT \`FK_68b31b97870f65f319d943ce23b\` FOREIGN KEY (\`userId\`, \`userIsDeleted\`) REFERENCES \`user\`(\`id\`,\`isDeleted\`) ON DELETE NO ACTION ON UPDATE NO ACTION`);
    }

    public async down(queryRunner: QueryRunner): Promise<void> {
        await queryRunner.query(`ALTER TABLE \`address\` DROP FOREIGN KEY \`FK_68b31b97870f65f319d943ce23b\``);
        await queryRunner.query(`DROP TABLE \`address\``);
        await queryRunner.query(`DROP TABLE \`user\``);
    }

}
