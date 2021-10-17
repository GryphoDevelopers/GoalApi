require('dotenv/config')
const database = {
    PRODUCTION: {
        host: process.env.PROD_DATABASE_HOST,
        port: process.env.PROD_DATABASE_PORT,
        username: process.env.PROD_DATABASE_USER,
        password: process.env.PROD_DATABASE_PASSWORD,
        database: process.env.PROD_DATABASE_NAME
    },
    DEVELOPMENT: {
        host: process.env.DEV_DATABASE_HOST,
        port: process.env.DEV_DATABASE_PORT,
        username: process.env.DEV_DATABASE_USER,
        password: process.env.DEV_DATABASE_PASSWORD,
        database: process.env.DEV_DATABASE_NAME
    }
}
module.exports = {
    type: "mysql",
    ...database[process.env.NODE_ENV],
    entities: ["./src/domain/entity/*.ts"],
    autoSchemaSync: true,
    migrationsTableName: "custom_migration_table",
    migrations: ["src/migrations/*.ts"],
    cli: {
        migrationsDir: "src/migrations"
    },
};
