import { databaseAuthModel } from "../models/env/databaseAuth"
import { Dialect, Sequelize } from 'sequelize'

export const useGoalContext = () => {
    const databaseAuth = (): databaseAuthModel => {
        if (process.env.ENV?.trim() === "DEVELOPMENT")
            return new databaseAuthModel(
                process.env.DEV_DATABASE_NAME,
                process.env.DEV_DATABASE_HOST,
                process.env.DEV_DATABASE_USER,
                process.env.DEV_DATABASE_PASSWORD)
        return new databaseAuthModel(
            process.env.PROD_DATABASE_NAME,
            process.env.PROD_DATABASE_HOST,
            process.env.PROD_DATABASE_USER,
            process.env.PROD_DATABASE_PASSWORD)
    }
    const databaseConnect = () : Sequelize => {
        let credentials: databaseAuthModel = databaseAuth();
        return new Sequelize(
            credentials.databaseName,
            credentials.databaseUser,
            credentials.databasePassword, {
                host : credentials.databaseHost,
                dialect: 'mysql'
            })
    }

    return {
        databaseAuth,
        databaseConnect
    }
}