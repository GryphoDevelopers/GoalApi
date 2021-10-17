import { router } from './src/router'
import * as dotenv from 'dotenv'
import express from 'express';
//config
dotenv.config()
const app = express();
const port = process.env.APP_PORT;
//imp
app.use(express.json());
app.use(express.urlencoded({ extended: true}))
app.use('/api', router)
app.listen(port, () => {
    console.log(`The application is listening on port ${port}!`);
})